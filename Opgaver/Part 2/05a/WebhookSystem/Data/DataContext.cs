using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Xml.Linq;
using System.Xml.Schema;
using WebhookSystem.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebhookSystem.Data
{

    public static class DataContext
    {
        private static readonly string filePath;

        static DataContext()
        {
            filePath = AppDomain.CurrentDomain.BaseDirectory + "/Data/DB.json";
        }

        public static List<UserWebhookDTO> GetWebhooks(WebhookType? webhookType = null)
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath);
                return new List<UserWebhookDTO>();
            }
            var file = File.ReadAllText(filePath);
            var data = JsonSerializer.Deserialize<List<UserWebhookDTO>>(file);

            if (webhookType != null)
            {
                data = data.Where(x => x.EventTypes.Contains(webhookType.Value)).ToList();
            }

            return data;
        }
        public static void SaveUsers(UserWebhookDTO dto)
        {
            var users = GetWebhooks();

            users.Add(dto);

            File.WriteAllText(filePath, JsonSerializer.Serialize(users));
        }

        public static void UpdateUser(UserWebhookDTO dto)
        {
            var users = GetWebhooks();
            var user = users.FirstOrDefault(x => x.Id == dto.Id);
            if (user == null)
            {
                return;
            }
            user.Name = dto.Name;
            user.Url = dto.Url;
            user.Events = dto.Events;
            user.HTTPMethod = dto.HTTPMethod;


            File.WriteAllText(filePath, JsonSerializer.Serialize(users));
        }

        public static async void SendEvent(string message, WebhookType type)
        {
            var users = GetWebhooks(type);
            users = users.Where(x => x.EventTypes.Contains(type)).ToList();

            var client = new HttpClient();
            var requests = new List<Task<HttpResponseMessage>>();
            var webhookDTO = new WebhookDTO() { Data = message };
            var content = new StringContent(JsonSerializer.Serialize(webhookDTO), Encoding.UTF8, "application/json");

            foreach (var user in users)
            {
                switch (user.HTTPMethodEnum)
                {

                    case HTTPType.Post:
                        requests.Add(client.PostAsJsonAsync(user.Url, webhookDTO));
                        break;
                    case HTTPType.Put:
                        requests.Add(client.PutAsJsonAsync(user.Url, webhookDTO));
                        break;
                    case HTTPType.Delete:
                        requests.Add(client.DeleteAsync(user.Url));
                        break;
                    case HTTPType.Get:
                        requests.Add(client.GetAsync(user.Url));
                        break;
                    default:
                    case HTTPType.Unknown:
                        throw new Exception("invalid http protocol");
                }
            }
            await Task.WhenAll(requests);
            foreach (var item in requests)
            {
                var response = await item;
                Console.WriteLine(await response.Content.ReadAsStringAsync());
            }
        }
        public static void DeleteUsers()
        {
            var users = new List<UserWebhookDTO>();
            File.WriteAllText(filePath, JsonSerializer.Serialize(users));
        }
        public static void DeleteUser(Guid id)
        {
            var users = GetWebhooks().Where(x => x.Id != id).ToList();
            File.WriteAllText(filePath, JsonSerializer.Serialize(users));
        }


    }
}

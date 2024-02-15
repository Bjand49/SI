using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using FiletypeAPI.Models;

namespace FiletypeAPI
{
    public class MeMapper : ClassMap<Me>
    {
        public MeMapper()
        {
            Map(m => m.FirstName).Name("FirstName").Index(0);
            Map(m => m.LastName).Name("LastName").Index(1);
            Map(m => m.Email).Name("Email").Index(2);
            Map(m => m.Hobbies).Name("Hobbies").Convert(row =>
            {
                var hobbies = row.Row.GetField("Hobbies").Split(',');
                return hobbies;
            });
        }
    }
}

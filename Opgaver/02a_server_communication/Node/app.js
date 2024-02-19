import express from "express";

const app = express();
const LOCALPORT = 8080;
const REMOTEURL = "http://localhost:5146/";

app.get("/xml", async (req, res) => {
    const response = await fetch(REMOTEURL + "xml");
    const data = await response.json();
    res.send(data);
})
app.get("/json", async (req, res) => {
    const response = await fetch(REMOTEURL + "json");
    const data = await response.json();
    res.send(data);
})
app.get("/csv", async (req, res) => {
    const response = await fetch(REMOTEURL + "csv");
    const data = await response.json();
    res.send(data);
})
app.get("/yaml", async (req, res) => {
    const response = await fetch(REMOTEURL + "yaml");
    const data = await response.json();
    res.send(data);
})
app.get("/txt", async (req, res) => {
    const response = await fetch(REMOTEURL + "txt");
    const data = await response.json();
    res.send(data);
})
app.listen(LOCALPORT, () => console.log("server is running on port", LOCALPORT));

import express from "express";

const port = 8080;
const app = express();
let clients = [];
app.get("/events/subscribe", (req, res) => {
    res.setHeader('Content-Type', 'application/json');
    res.setHeader('Cache-Control', 'no-cache');
    res.setHeader('Connection', 'keep-alive');
    clients.push(res);
});

app.get("/events/publish", (req, res) => {
    const newData = { data: "This is the newly created data" };
    clients.forEach((x) => x.send(newData));
    
    clients = [];
    res.status(204).end();

});

app.listen(port, () => console.log("server is running on ", port));
import express from "express";

const port = 8080;
const app = express();

app.use(express.static("public"))

app.get("/synchronizeTime", (req, res) => {
    res.writeHead(200, {
        "Content-Type": "text/event-stream",
        "Cache-Control": "no-cache",
        "Connection": "keep-alive"
    });
    setInterval(()=>sendTimeToClient(res), 1000);
});

app.listen(port, () => console.log("server is running on ", port));

function sendTimeToClient(res) {
    const time = new Date().toISOString();
    res.write(`data: ${time}\n\n`)

}
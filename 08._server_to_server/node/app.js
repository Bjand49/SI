import express from "express";

const app = express();
const PORT = 8080;

app.get("/requestFastAPI", async (req, res) => {
    let data = '';
    const response = await fetch("http://localhost:8000/fastapiData");
    data = await response.json();
    res.send(data);
})
app.get("/expressData", async (req, res) => {
    res.send({"message":"Hello bombastic pythonman, this is express"})
})
app.listen(PORT, () => console.log("server is running on port", PORT));

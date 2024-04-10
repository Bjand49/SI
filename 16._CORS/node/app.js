import express from "express";
import cors from "cors";

const app = express();
const port = 8080;

app.use(cors());

app.use((req, res, next) => {
    res.header("Access-Control-Allow-Origin", "*");
    res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type, Accept");
    next();
});
app.get("/timestamp", (req,res) => {
    res.send({time: new Date()})
})
app.listen(port, () => console.log("server is running on ", port));
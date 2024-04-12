import express from "express"

const app = express();

app.use(express.static("public"))
app.use(express.static("videos"))

const PORT = 8080;
app.listen(PORT, () => console.log("system up and running on ", PORT));
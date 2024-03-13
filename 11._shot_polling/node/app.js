import express from "express"

const app = express();
const port = 8080;

app.use(express.static("public"))

const randomNumbers = [];

app.get("/randomNumbers", (req, res) => {
    res.send({ data: randomNumbers });
})

app.get("/simulateNewRandomNumbers", (req, res) => {
    const newnumber = getRandomInt(1,337);
    randomNumbers.push(newnumber);
    res.send({ data: newnumber,randomNumbers: randomNumbers });
})

app.listen(port, () => console.log("server is running:", port))

function getRandomInt(min, max) {
    return Math.floor(Math.random() * (max - min + 1) + min);
}
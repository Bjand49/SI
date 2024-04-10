import express from "express";
import multer from "multer"
const app = express();
const port = 8080;

app.use(express.urlencoded({ extended: true }));

const upload = multer({ dest: '/uploads/' });

app.post("/form", (req, res) => {
    console.log(req.body);
    delete req.body.password;
    res.send(req.body);
});

app.post("/fileform", upload.single('pic'), (req, res) => {
    console.log(req.body);
    res.send({});
});

app.listen(port, () => console.log("server is running on ", port));
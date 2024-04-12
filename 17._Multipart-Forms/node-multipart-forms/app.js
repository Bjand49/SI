import { error } from "console";
import express from "express";
import multer from "multer"

const app = express();
const port = 8080;

app.use(express.urlencoded({ extended: true }));
const storage = multer.diskStorage({
    destination: function (req, file, cb) {
        cb(null, './uploads/')
    },
    filename: function (req, file, cb) {
        const uniquePrefix = Date.now() + '-' + Math.round(Math.random() * 1E9)
        cb(null, uniquePrefix + '-' + file.originalname)
    }
})


import path from "path"
console.log(path.sep)

const upload = multer({
    limits: {
        fileSize: 1 * 1024 * 1024
    },
    storage: storage,
    fileFilter
});

function fileFilter(req, file, cb) {
    const validtypes = ["image/jpeg", "image/jpg", "image/png", "image/svg",];
    if (!validtypes.includes(file.mimetype)) {
        cb(new Error("filetype is nogo: " + file.mimetype));
    }
    else{
        cb(null,true);
    }
}

app.post("/form", (req, res) => {
    console.log(req.body);
    delete req.body.password;
    res.send(req.body);
});


app.post("/fileform", upload.single('file'), (req, res) => {
    console.log(req.body);
    res.send({});
});

app.listen(port, () => console.log("server is running on ", port));
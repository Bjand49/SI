from fastapi import FastAPI
import emoji

app = FastAPI()

@app.get("/")
def main():
    return {"reply":"hejsi"}

@app.get("/bandeord")
def root():
    return emoji.emojize(":face_with_symbols_on_mouth:")

@app.get("/firstroute")
def first():
    return "my first route omg wow"
from fastapi import FastAPI, Form
from typing import Annotated

app = FastAPI()



@app.post("/form")
def _(username: Annotated[str, Form()], password: Annotated[str, Form(min_length=8)]):
    return {"username": username}

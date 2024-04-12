from fastapi import FastAPI, Form, UploadFile, File
from typing import Annotated, Optional
import aiofiles
app = FastAPI()

@app.post("/form")
def _(username: Annotated[str, Form()], password: Annotated[str, Form(min_length=8)]):
    return {"username": username}

@app.post("/fileform1")
def create_file(file: Annotated[bytes, File(...)]):
    with open('file','wb') as filething:
         filething.write(file)
         
    return {"file_size": len(file)}

@app.post("/fileform")
async def file_form(file: UploadFile = File(...),description: Optional[str] = Form(None)):
    # print(file)
    # content = await file.read()
    safename = file.filename.replace("/","_").replace("\\","_")
    # with open(safename,'wb') as filething:
    #     filething.write(content)
    with open(safename,'wb') as f:
        while content := await file.read(1024):
            f.write(content)
            
    async with aiofiles.open("aio" + safename,'wb') as fp:
        while content := await file.read(1024):
            await fp.write(content)
    return {"filename": file.filename}
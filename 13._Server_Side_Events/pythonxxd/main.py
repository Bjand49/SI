from fastapi import FastAPI, Request
from fastapi.templating import Jinja2Templates
from datetime import datetime
from fastapi.responses import StreamingResponse
import asyncio

app = FastAPI()

tempates = Jinja2Templates(directory="templates")

@app.get("/")
def serve_root_page(request: Request):
    return tempates.TemplateResponse("index.html",{"request":request})

async def date_generator():
    while True:
        now = datetime.now().strftime("%Y-%m-%d %H:%M%S")
        yield f"data: {now}\n\n"
        await asyncio.sleep(1)

@app.get("/sse")
def sse():
    return StreamingResponse(date_generator(),media_type="text/event-stream")
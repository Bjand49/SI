from fastapi import FastAPI, Request

app = FastAPI()

@app.post('/githubwebhookjson')
async def github_webhook_json(request: Request):
    print(await request.body())
    return
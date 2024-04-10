import { WebSocket } from "ws"

const webSocketClient = new WebSocket("ws://localhost:8080");

webSocketClient.on("open", ()=>{
    webSocketClient.send("New connection: thisnis a message fro node.js")
    console.log("started")
    webSocketClient.on("message", (message) => {
        console.log(`the message: ${message}`)
    })
})

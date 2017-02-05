using UnityEngine;
using System.Collections;
using WebSocketSharp;
using WebSocketSharp.Net;
using WebSocketSharp.Server;

public class serverEnd : MonoBehaviour
{

    WebSocketServer server;

    void Start()
    {
        server = new WebSocketServer(8888);

        server.AddWebSocketService<Echo>("/");
        server.Start();

    }

    void OnDestroy()
    {
        server.Stop();
        server = null;
    }

}

public class Echo : WebSocketBehavior
{
    protected override void OnMessage(MessageEventArgs e)
    {
        Sessions.Broadcast(e.Data);
    }
}
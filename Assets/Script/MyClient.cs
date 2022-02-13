using BestHTTP.SignalRCore;
using BestHTTP.SignalRCore.Encoders;
using System;
using UnityEngine;

public class MyClient : MonoBehaviour
{
    private HubConnection hub;
    // Start is called before the first frame update
    async void Start()
    {
        hub = new HubConnection(new Uri("http://35.185.136.223:80/MyHub"), new JsonProtocol(new LitJsonEncoder()));
        //hub = new HubConnection(new Uri("http://127.0.0.1:5277/MyHub"), new JsonProtocol(new LitJsonEncoder()));
        hub.OnConnected += (HubConnection obj) => { Debug.Log("Connected"); };
        hub.OnReconnected += (HubConnection obj) => { Debug.Log("Reconnected"); };

        hub.OnClosed += hub => { Debug.Log("Closed"); };
        hub.OnReconnecting += (HubConnection arg1, string arg2) => { Debug.Log("Reconnecting"); };
        hub.OnError += (HubConnection arg1, string arg2) => { Debug.Log("Error"); };

        await hub.ConnectAsync();

        hub.On<string>("ReceiveMessage", msg => { Debug.Log("Receive: "+msg); });
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            System.Diagnostics.Stopwatch stopwatch = System.Diagnostics.Stopwatch.StartNew();            
            while (stopwatch.ElapsedMilliseconds < 10000)
            {}
        }
    }
}

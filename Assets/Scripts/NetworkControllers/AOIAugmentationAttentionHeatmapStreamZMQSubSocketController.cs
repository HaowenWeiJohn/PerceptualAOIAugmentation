using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Net.Sockets;
using UnityEngine.WSA;
using System.ServiceModel.Channels;
using System.Net.WebSockets;
using LSL;

public class AOIAugmentationAttentionHeatmapStreamZMQSubSocketController : MonoBehaviour
{



    [Header("ZMQ Socket Info")]
    public string addresss = "tcp://localhost:5557";
    public string topic = "AOIAugmentationAttentionHeatmapStreamZMQInlet";

    [Header("ZMQ Socket Data")]
    public bool message_received = false;
    public List<byte[]> recieveBytes = new List<byte[]> { };

    SubscriberSocket socket;
    // the time to wait for a message to arrive, this is non blocking
    private System.TimeSpan waitTime = new System.TimeSpan(0, 0, 0);




    // Start is called before the first frame update
    void Start()
    {
        AsyncIO.ForceDotNet.Force();
        socket = new SubscriberSocket();

        socket.Connect(addresss);
        socket.Subscribe(topic);
    }

    void Update()
    {
        //// receive message
        //ReceiveMessage();
        //if (message_received)
        //{
        //    ProcessMessage();
        //}
    }

    public bool ReceiveMessage()
    {

        message_received = socket.TryReceiveMultipartBytes(waitTime, ref recieveBytes);
        if (message_received)
        {
            message_received = true;
        }
        else
        {
            message_received = false;
        }

        return message_received;
    }


    //void ProcessMessage()
    //{

    //}


    private void OnDestroy()
    {
        socket.Dispose();
        NetMQConfig.Cleanup();
    }

}

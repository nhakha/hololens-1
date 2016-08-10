using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
#if !UNITY_EDITOR
using Windows.Networking;
using Windows.Networking.Sockets;
using Windows.Storage.Streams;
#endif
using System.Text;

public class WebsocketController : MonoBehaviour {

    public Text log;
    public Text instruction;
    // Check if InitializeObjet script works completed
    public bool isExecuted = true;
    
    private string _data = "";
    // Check if program can receive data
    private bool isBeginReceiving = false;
    // Check if program receive data completely
    private bool isReceived = false;
    private bool isConnected = false;

#if !UNITY_EDITOR
    private StreamSocket socket;
    private HostName hostName;
#endif

    // Use this for initialization
    void Start()
    {
        log.text = "";
#if !UNITY_EDITOR
        socket = new StreamSocket();
#endif
    }

    void Update()
    {
#if !UNITY_EDITOR
        // If user press Q
        if (Input.GetKeyDown(KeyCode.Q) && !isConnected)
        {
            Connect();

            instruction.text = "";

            if(socket.Information.LocalAddress == null)
            {
                log.text = "Failed to connect.";
            }
            else
            {
                isConnected = true;
                log.text = "Connected.";
                isBeginReceiving = true;
            }
        }
        // If user press W
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Close();
        }
        // If received data and Initialize Object script works done
        else if (isReceived && isExecuted)
        {
            isReceived = false;
            isExecuted = false;
            isBeginReceiving = true;

            // Set data for InitializeObject Script
            GameObject ws = GameObject.Find("Initiation");
            InitializeObject initiationScript = ws.GetComponent<InitializeObject>();
            initiationScript.data = _data;
            initiationScript.isDataIn = true;

            _data = "";
        }
        // If program can receive data (when Initialize Object script works is done and send data to this script is done)
        // or when after program connects server.
        else if (isBeginReceiving && isExecuted)
        {
            Receive();

            if (_data != "")
            {
                isReceived = true;
                log.text = "Received data.";
                isBeginReceiving = false;
            }
         }
#endif
    }

#if !UNITY_EDITOR
    public async void Connect()
    {
        try
        {
            Debug.Log("Trying to connect ...");

            hostName = new HostName("localhost");
            // Try to connect
            await socket.ConnectAsync(hostName, "4444");
        }
        catch
        {
            Debug.Log("Connect failed.");
        }
    }

    private void Receive()
    {
        try
        {
            Debug.Log("Trying to receive data ...");

            // Convert stream socket in Window Runtime to Stream in .NET
            Stream streamIn = socket.InputStream.AsStreamForRead();
            byte[] data = new byte[1024];
            // Get length of input byte array
            int byteCount = streamIn.Read(data, 0, 1024);
            // Convert byte array to string
            _data = Encoding.UTF8.GetString(data, 0, byteCount);
        }
        catch
        {
            Debug.Log("Receive failed.");
        }
    }

    private void Close()
    {
        socket.Dispose();
        socket = null;
    }
#endif
}

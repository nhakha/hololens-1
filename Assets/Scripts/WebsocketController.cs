using UnityEngine;
using UnityEngine.UI;
using nsoftware.IPWorksWS;

public class WebsocketController : MonoBehaviour {

    public Text log;
    public Text instruction;

    private Wsclient wsclient1;
    private string _data;
    private string status;
    // Check receive data
    private bool flag;

    // Use this for initialization
    void Start () {
        flag = false;
        _data = "";
        log.text = "";

        wsclient1 = new Wsclient();
        // Set events for wsclient1
        wsclient1.OnConnected += new Wsclient.OnConnectedHandler(this.wsclient1_OnConnected);
        wsclient1.OnDisconnected += new Wsclient.OnDisconnectedHandler(this.wsclient1_OnDisconnected);
        wsclient1.OnDataIn += new Wsclient.OnDataInHandler(this.wsclient1_OnDataIn);
    }

    void Update()
    {
        log.text = status;
        // If user press Q
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Connect();
            instruction.text = "";
        }
        // If user press W
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Disconnect();
        }
        // If received data
        else if (flag)
        {
            GameObject ws = GameObject.Find("Initiation");
            InitializeObject initiationScript = ws.GetComponent<InitializeObject>();
            initiationScript.data = _data;
            initiationScript.isDataIn = true;
            flag = false;
        }
    }

    private void wsclient1_OnConnected(object sender, nsoftware.IPWorksWS.WsclientConnectedEventArgs e)
    {
        // Check if connection is success or fail
        status = (e.StatusCode == 0 ? "Connected." : "Failed to connect.");
    }

    private void wsclient1_OnDisconnected(object sender, nsoftware.IPWorksWS.WsclientDisconnectedEventArgs e)
    {
        status = "Disconnected.";
    }

    private void wsclient1_OnDataIn(object sender, WsclientDataInEventArgs e)
    {
        flag = true;
        _data = e.Text;
    }

    private void Connect()
    {
        wsclient1.Timeout = 10;
        wsclient1.Connect("ws://localhost:4444");
    }

    private void Disconnect()
    {
        wsclient1.Disconnect();
        log.text = "Disconnected.";
    }
}

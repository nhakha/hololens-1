using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

// Containing list time and vector of object
public class Object
{
    //public List<double> timeList;
    public List<Vector3> vectorList;
}

// Containing sequence time and id of object
public class MovingSequence
{
    public double time;
    public int id;
    // Check if at this 'time', object whether created
    public bool isStart;
}

public class InitializeObject : MonoBehaviour {

    public string data;
    // Check if receiving data
    public bool isDataIn;
    public Text log;

    private int id;
    private float x, y, z;
    private double time;
    
    private List<Object> objects;
    private List<GameObject> gameObjects;
    private List<MovingSequence> sequence;

    // Index of sequence array
    private int index;
    // Check whether setting data for object to move
    private bool isSet;

    private string errorText;

    // Use this for initialization
    void Start()
    {
        errorText = "";

        data = "";
        isDataIn = false;

        objects = new List<Object>();
        sequence = new List<MovingSequence>();
        gameObjects = new List<GameObject>();
        x = 0;
        y = 0;
        z = 0;
        
        index = 1;
        
        //System.Diagnostics.Process.Start(Application.dataPath + "/Resources/WSServer.lnk");
        //System.Diagnostics.Process.Start(Application.dataPath + "/Resources/WSClient.lnk");
    }
	
	// Update is called once per frame
	void Update()
    {
        if(errorText != "")
        {
            log.text = errorText;
            errorText = "";
        }

        // If receiving data
        if(isDataIn)
        {
            initializeObjects();
            isDataIn = false;
        }
        
        // If array sequence has data
        if(sequence != null)
        {
            if (index < sequence.Count)
            {
                if (isSet)
                {
                    isSet = false;
                    // If at this time, the position of object isn't the first position
                    // (the position where object created)
                    if(!sequence[index].isStart)
                    {
                        double moveTime = sequence[index].time - sequence[index - 1].time;
                        // If moveTime = 0, object isn't enough time to move
                        // -> set moveTime = 1 to object can move
                        if (moveTime == 0)
                            moveTime = 1;
                        gameObjects[sequence[index].id - 1].GetComponent<ObjectController>().moveTime = moveTime;
                        // Set flag = true to object can move
                        gameObjects[sequence[index].id - 1].GetComponent<ObjectController>().flag = true;
                    }
                    index++;
                }
                // If flag == false -> moving object is completed
                // flag == true -> object is moving
                else if (!gameObjects[sequence[index - 1].id - 1].GetComponent<ObjectController>().flag
                    || (sequence[index - 1].time == sequence[index].time))
                {
                    isSet = true;
                }
            }
            else
            {
                index = 1;
                GameObject ws = GameObject.Find("WebSocket");
                WebsocketController wsScript = ws.GetComponent<WebsocketController>();
                wsScript.isExecuted = true;
            }
        }
	}

    //public void TakeDamage(float Damage)
    //{
    //    if (gameObject != null)
    //    {
    //        // Do something  
    //        Destroy(gameObject);
    //    }
    //}

    void initializeObjects()
    {
        // Reading data and initialize data of array
        readFile();

        // Create objects in array 'gameObjects' which don't contain in array 'objects'
        for (int i = gameObjects.Count; gameObjects.Count < objects.Count; i++)
        {
            // Initialize prefab of cube (clone objects)
            GameObject tmp = Instantiate(Resources.Load("Prefabs")) as GameObject;

            // Adding script ObjectController for instantiated object
            tmp.AddComponent<ObjectController>();

            // Setting valuable of script ObjectController
            tmp.GetComponent<ObjectController>().vectorList = new List<Vector3>();
            tmp.GetComponent<ObjectController>().vectorList = objects[i].vectorList;
            //tmp.GetComponent<ObjectController>().timeList = new List<double>();
            //tmp.GetComponent<ObjectController>().timeList = objects[i].timeList;

            tmp.transform.position = objects[i].vectorList[0];
            tmp.SetActive(true);

            gameObjects.Add(tmp);
        }
    }

    void readFile()
    {
//        string data = @"object_id1 x=3 y=10 z=5 17:05:59
//object_id1 x=5 y=10 z=5 17:06:00
//object_id1 x=7 y=10 z=5 17:06:01
//object_id1 x=9 y=10 z=5 17:06:02
//object_id1 x=9 y=7 z=5 17:06:03
//object_id1 x=9 y=5 z=5 17:06:04
//object_id1 x=9 y=3 z=5 17:06:05
//object_id1 x=9 y=1 z=5 17:06:06
//object_id1 x=7 y=1 z=5 17:06:07
//object_id1 x=5 y=1 z=5 17:06:08
//object_id1 x=3 y=1 z=5 17:06:09
//object_id1 x=3 y=3 z=5 17:06:10
//object_id1 x=3 y=5 z=5 17:06:11
//object_id1 x=3 y=7 z=5 17:06:12
//object_id1 x=3 y=10 z=5 17:06:13
//object_id2 x=10 y=3 z=5 17:06:14
//object_id2 x=10 y=5 z=5 17:06:15
//object_id1 x=3 y=10 z=5 17:06:15
//object_id1 x=9 y=10 z=10 17:06:16
//object_id1 x=9 y=7 z=10 17:06:17
//object_id3 x=11 y=3 z=10 17:06:19
//object_id3 x=11 y=5 z=10 17:06:20
//object_id1 x=9 y=5 z=10 17:06:21
//object_id2 x=10 y=7 z=5 17:06:22
//object_id2 x=10 y=10 z=5 17:06:23
//object_id1 x=9 y=3 z=10 17:06:24
//object_id1 x=9 y=1 z=10 17:06:25
//object_id3 x=11 y=7 z=10 17:06:26
//object_id3 x=11 y=1 z=10 17:06:27";
        string tmp = null;
        // Check for setting data
        // 1 = setting for id
        // 2 = x
        // 3 = y
        // 4 = z
        // 5 = time
        // 6 = initialize array or adding valuable for array
        int valFlag = 1;
        // Index of array setting valuable
        // -1 if array isn't containing valuable of id
        int idx = -1;
        
        for (int i = 0; i < data.Length; i++)
        {
            if(data[i] != ' ' && data[i] != '\r' && data[i] != '\n' && data[i] != '.')
            {
                tmp += data[i];
            }
            else
            {
                if(tmp != null)
                {
                    try
                    {
                        // Set value of time, x, y, z, id, array
                        setValues(tmp, ref valFlag, ref idx);
                    }
                    catch
                    {
                        errorText = "Datas in wrong format.";
                    }
                    tmp = null;
                }
            }
        }
        
        if(tmp != null)
        {
            try
            {
                // Because loop out before setting completedly
                // Set value of time
                setValues(tmp, ref valFlag, ref idx);
                // Set value of array
                setValues(tmp, ref valFlag, ref idx);
            }
            catch
            {
                errorText = "Datas in wrong format.";
            }
        }
    }

    void setValues(string value, ref int valFlag, ref int idx)
    {
        switch (valFlag)
        {
            case 1:
                // Cut string and set value of id
                id = int.Parse(value.Substring(value.Length - 1));
                idx = checkID(id);
                break;
            case 2:
                // Cut string and parse float for x
                x = float.Parse(value.Substring(2));
                break;
            case 3:
                y = float.Parse(value.Substring(2));
                break;
            case 4:
                z = float.Parse(value.Substring(2));
                break;
            case 5:
                // Convert string to seconds
                time = System.TimeSpan.Parse(value).TotalSeconds;

                // Set array
                valFlag = 0;

                MovingSequence movsequence = new MovingSequence();
                movsequence.id = id;
                movsequence.time = time;

                // If array isn't containg id
                if (idx == -1)
                {
                    movsequence.isStart = true;

                    // Initiatlize
                    Object objct = new Object();
                    objct.vectorList = new List<Vector3>();
                    //objct.timeList = new List<double>();

                    //objct.timeList.Add(time);
                    objct.vectorList.Add(new Vector3(x, y, z));

                    objects.Add(objct);
                }
                else
                {
                    movsequence.isStart = false;

                    // Add valuable for array if id contains in array
                    //objects[sequence[idx].id - 1].timeList.Add(time);
                    objects[sequence[idx].id - 1].vectorList.Add(new Vector3(x, y, z));
                }

                sequence.Add(movsequence);

                break;
        }
        valFlag++;
    }

    // Return index of array where id (which input) compare with id of sequence
    // -1 if array doesn't contain id
    int checkID(int id)
    {
        for(int i = sequence.Count - 1; i >= 0; i--)
        {
            if (id == sequence[i].id)
                return i;
        }
        return -1;
    }
}

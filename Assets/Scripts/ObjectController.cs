using System.Collections.Generic;
using UnityEngine;

public class ObjectController : MonoBehaviour
{
    public List<Vector3> vectorList;
    public List<double> timeList;
    // Check if object can move
    public bool flag;
    
    private int index;
    private bool isMoving;
    
    private double moveTime;
    private double startTime;
    private double endTime;
    private Vector3 originalPosition;
    private Vector3 moveToPosition;

    // Use this for initialization
    void Start()
    {
        index = 1;
        flag = false;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (flag && index < vectorList.Count)
        {
            // If object is moving
            if (isMoving && Time.time < endTime)
            {
                transform.position = Vector3.Lerp(originalPosition, moveToPosition, (Time.time - (float)startTime) / (float)moveTime);
            }
            // If moving object is completed
            else if (isMoving)
            {
                isMoving = false;
                index++;
            }
            // If object doesn't move
            else if (!isMoving)
            {
                moveTime = timeList[index] - timeList[index - 1];
                startTime = Time.time;
                endTime = Time.time + moveTime;

                originalPosition = vectorList[index - 1];
                moveToPosition = vectorList[index];
                
                isMoving = true;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;

//DateTime.Now.ToString() + ":" + DateTime.Now.Millisecond.ToString()

public class WriteToTextFile : MonoBehaviour
{
    string filePath;
    public DateTime startTime;
    private void Start() {
        InvokeRepeating("writeToFile", 0.98f, 1.0f);
        startTime = DateTime.Now;
    }
    void writeToFile(){
        filePath = Application.persistentDataPath+ "/" + "data.txt";
        StreamWriter writer = new StreamWriter(filePath, true);
        TimeSpan currentTime = System.DateTime.Now - startTime;
        writer.WriteLine(currentTime.Minutes.ToString() + ":" + currentTime.Seconds.ToString() + ";" + GPS.Instance.latitude.ToString() + ";" + GPS.Instance.longitude.ToString() + ";" + GyroScopeScript.Instance.gyro.attitude.ToString());
        writer.Close();
    }
}

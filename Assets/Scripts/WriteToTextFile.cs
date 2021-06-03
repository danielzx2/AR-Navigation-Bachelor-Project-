using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class WriteToTextFile : MonoBehaviour
{
    string [] coords;
    string filePath, fileName;
    public Text status;
    void Start(){
        fileName = System.DateTime.Now.ToString();
        filePath = Application.persistentDataPath + "/" + fileName;
        status.text = "Write to File";
    }
    void writeCoordinates(){
        coords = new string[3];
        coords[0] = "Latitude: " + CalculateDistance.Instance.current.Latitude.ToString() + " ";
        coords[1] = "Longitude: " + CalculateDistance.Instance.current.Longitude.ToString() + " ";
        coords[2] = "At: " +  System.DateTime.Now;
        
        for (int i = 0; i < coords.Length; i++)
        {
            coords[i] = "";
        }
    }

    public void writeToFile(){
        writeCoordinates();
        File.WriteAllLines(filePath, coords);
        if(File.Exists(filePath)){
            status.text = "Write Complete!";
        }
        else
        {
            status.text = "Write Failed";
        }
    }

    void Update(){
        writeToFile();
    }
}

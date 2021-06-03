using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TextWriter : MonoBehaviour
{
    
    void Start()
    {
        CreateText();
    }

    void CreateText(){
        string path = Application.dataPath + "/Log.txt";
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Navigation \n");
            string content = System.DateTime.Now.Second + "\n";
            File.AppendAllText(path, content);
        }
    }

    void Update()
    {
        CreateText();
    }
}

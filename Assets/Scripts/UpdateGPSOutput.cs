using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateGPSOutput : MonoBehaviour
{
    public static UpdateGPSOutput Instance {get; set;}
    public Text coordniates;
    public Text Cardinal;
    public string zeroSeconds = "";
    public string zeroMinute = "";

    private void Update(){
        if(System.DateTime.Now.Second < 10){
            zeroSeconds = "0";
        }
        else
        {
            zeroSeconds = "";
        }

        if(System.DateTime.Now.Minute < 10){
            zeroMinute = "0";
        }
        else
        {
            zeroMinute = "";
        }
        coordniates.text =  "Latitude: " + GPS.Instance.latitude.ToString() + "\n" +  "Longitude: " + GPS.Instance.longitude.ToString() + "\n" + "Checked at: " + System.DateTime.Now.Hour.ToString() + ":"  + zeroMinute + System.DateTime.Now.Minute.ToString() + ":" + zeroSeconds + System.DateTime.Now.Second.ToString() + "\n" + "Gyroscope: " + GyroScopeScript.Instance.gyro.attitude.ToString();
    }
    
}

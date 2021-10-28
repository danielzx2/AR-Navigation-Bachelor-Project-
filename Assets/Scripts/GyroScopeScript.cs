using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroScopeScript : MonoBehaviour
{
    public static GyroScopeScript Instance {get; set;}
    private bool gyroEnabled;
    public Gyroscope gyro;
    public string gyroStats;

    private GameObject cameraContainer;
    private Quaternion rot;

    private void Start(){
        cameraContainer = new GameObject("Camera Container");
        cameraContainer.transform.position = transform.position;
        transform.SetParent(cameraContainer.transform);

        Instance = this;
        gyroEnabled = EnableGyro();
    }

    private bool EnableGyro(){
        if(SystemInfo.supportsGyroscope){
            gyro = Input.gyro;
            gyro.enabled = true;

            cameraContainer.transform.rotation = Quaternion.Euler(90f,90f,0f);
            rot = new Quaternion(0,0,1,0);

            return true;
        }

        return false;
    }

    private void Update(){
        if(gyroEnabled){
            transform.localRotation = gyro.attitude * rot;
            gyroStats = gyro.attitude.eulerAngles.ToString();
        }
    }

}

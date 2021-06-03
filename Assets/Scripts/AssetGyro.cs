using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssetGyro : MonoBehaviour

{
    public static AssetGyro Instance {get; set;}
    public Gyroscope gyroscope;
    public Vector3 result;
    public float angle;
    void Start()
    {
        if(SystemInfo.supportsGyroscope)
        {
            DontDestroyOnLoad(gameObject);
            gyroscope = Input.gyro;
            gyroscope.enabled = true;
        }
        transform.eulerAngles = new Vector3(0, 0, 0);
    }
    void Update()
    {  
      transform.eulerAngles = new Vector3(0, (CalculateDistance.Instance.directionAngle + 135), 0);
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CalculateDistance : MonoBehaviour

{

    public static CalculateDistance Instance { set; get; }
    // Insert a set of coordinates in the format of (Latitude, Longitude) into the tuples below. Coordinates can be taken from Google Maps.
    public (float Latitude, float Longitude) start = (0f, 0f);
    public (float Latitude, float Longitude) checkpoint1 = (0f, 0f);
    public (float Latitude, float Longitude) checkpoint2 = (0f, 0f);
    public (float Latitude, float Longitude) checkpoint3 = (0f, 0f);
    public (float Latitude, float Longitude) checkpoint4 = (0f, 0f);
    public (float Latitude, float Longitude) checkpoint5 = (0f, 0f);
    public (float Latitude, float Longitude) destination = (0f, 0f);

    (float, float)[] listOfPOIs = new (float, float)[6];
    
    public (float Latitude, float Longitude) current;
    
    public int POI;
    public bool played;
    const float radius = 6378.16f; // The Radius of the Earth
    public float result;
    public float directionAngle;
    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
        listOfPOIs[0] = checkpoint1;
        listOfPOIs[1] = checkpoint2;
        listOfPOIs[2] = checkpoint3;
        listOfPOIs[3] = checkpoint4;
        listOfPOIs[4] = checkpoint5;
        listOfPOIs[5] = destination;
        POI = 0;
        distance(current, listOfPOIs[0]);
        angle(current, listOfPOIs[0]);
    }

    public void angle((float, float) current, (float, float) dest){
        float length = dest.Item2 - start.Item2;
        float height = dest.Item1 - start.Item1;

        float hypotenuse = pythagora(length,height);
        float numerator = (hypotenuse * hypotenuse) + (length * length) - (height * height);
        float denominator = (2 * hypotenuse * length);

        float finalRadian = Mathf.Acos(numerator/denominator);

        directionAngle = finalRadian * Mathf.Rad2Deg;

        if(length < 0 || height < 0){
            directionAngle -=  360f;
        }

    }

    private float radian(float a){
        return a * Mathf.PI / 180;
    }

    private float pythagora(float a, float b){
        float ab = Mathf.Pow(a, 2f) + Mathf.Pow(b, 2f);
        float c = Mathf.Sqrt(ab);
        return c;
    }

    private void distance((float, float) current, (float, float) dest){
        float xDifference = radian(dest.Item2 - current.Item2);
        float yDifference = radian(dest.Item1 - current.Item1);

        float a = (Mathf.Sin(yDifference / 2) * Mathf.Sin(yDifference / 2) + Mathf.Cos(radian(current.Item1)) * Mathf.Cos(radian(current.Item2)) * (Mathf.Sin(xDifference / 2) * Mathf.Sin(xDifference / 2)));

        float angle = 2 * Mathf.Atan2(Mathf.Sqrt(a), Mathf.Sqrt(1 - a));

        result = angle * radius;

    }

    public void changePOI(){
       if (played == true)
       {
           played = false;
       }
       POI += 1;
       if (POI == 5)
       {
           SceneManager.LoadScene("DestinationInfo");
       } 
    }

    // Update is called once per frame
    void Update()
    {
        current.Latitude = GPS.Instance.latitude;
        current.Longitude = GPS.Instance.longitude;
        distance(current, listOfPOIs[POI]);
        angle(current, listOfPOIs[POI]);
    }
}

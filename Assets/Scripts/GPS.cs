using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GPS : MonoBehaviour
{
    public static GPS Instance { set; get; }
    public float latitude;
    public float longitude;


    private void Start(){
        Instance = this;
        DontDestroyOnLoad(gameObject);
        StartCoroutine(StartLocationService());
    }

    private IEnumerator StartLocationService()
    {
        if(!Input.location.isEnabledByUser){
            //Debug.Log("User has not enabled GPS Permissions");
            yield break;
        }

        Input.location.Start();
        int maxwait = 1;
        while(Input.location.status == LocationServiceStatus.Initializing && maxwait > 0){
            yield return new WaitForSeconds(1);
            maxwait--;
        }

        if(maxwait <= 0){
            //Debug.Log("Timed Out");
            yield break;
        }

        if(Input.location.status == LocationServiceStatus.Failed){
            //Debug.Log("Unable to determine device location");
            yield break;
        }

        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;

        digitalFilterGPS();

        yield break;
    }

    private void digitalFilterGPS(){
        int counter = 0;
        int maxcount = 0;
        float d = 0.5f;

        while (counter < maxcount)
        {
            float newLatitude = Input.location.lastData.latitude;
            float newLongitude = Input.location.lastData.longitude;

            float filteredLatitude = latitude + d * (newLatitude - latitude);
            float filteredLongitude = longitude + d * (newLongitude - longitude);

            latitude = filteredLatitude;
            longitude = filteredLongitude;
        }
    }

    void Update(){
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
    }
}

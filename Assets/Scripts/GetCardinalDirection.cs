using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetCardinalDirection : MonoBehaviour
{
    public static GetCardinalDirection Instance {get; set;}
    public Text Cardinal;


    private void updateCardinal(float angle){
        if(angle == 0f || angle < 45f || angle >= 315f){
            Cardinal.text = "North";
        }
        if(angle == 45f || angle < 90f){
            Cardinal.text = "Northeast";
        }
        if(angle == 90f || angle < 135f){
            Cardinal.text = "East";
        }
        if(angle == 135f || angle < 180f){
            Cardinal.text = "Southeast";
        }
        if(angle == 180f || angle < 225f){
            Cardinal.text = "South";
        }
        if(angle == 225f || angle < 270f){
            Cardinal.text = "Southwest";
        }
        if(angle == 270f || angle < 315f){
            Cardinal.text = "Northwest";
        }
    }
    void Update()
    {
        updateCardinal(transform.localEulerAngles.y);
    }
}

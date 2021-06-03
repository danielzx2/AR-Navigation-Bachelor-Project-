using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateDistance : MonoBehaviour
{
    public static UpdateDistance Instance {get; set;}
    public Text toDestination;

    public float result;

    private void Update(){
        result = CalculateDistance.Instance.result * 1000f;
        while (result >= 0f && result < 5f)
        {
            toDestination.text = "Goal Reached!";
        }
        toDestination.text = "Distance: " +  result.ToString() + "m \n";
    }
}

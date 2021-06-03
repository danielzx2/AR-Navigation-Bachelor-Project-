using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCardinal : MonoBehaviour
{
    public Text updateCardinal;
   
    void Update()
    {
        updateCardinal.text = "Cardinal: " + GetCardinalDirection.Instance.Cardinal.ToString();      
    }
}

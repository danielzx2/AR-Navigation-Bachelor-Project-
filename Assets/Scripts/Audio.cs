using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{  
    public static Audio Instance {get; set;}
    public AudioSource source;
    public AudioClip clip;
    public AudioClip straight;
    public AudioClip left;
    public AudioClip right;
    public AudioClip start;
    public AudioClip soon;
    public AudioClip goal;

    public bool played;

    void Start(){
        played = false;
        playSound(start);
    }

    public void playSound(AudioClip status){
            source.PlayOneShot(status);
    }

    void Update(){
        if(CalculateDistance.Instance.POI == 1 && CalculateDistance.Instance.played == false){
            playSound(straight);
            CalculateDistance.Instance.played = true;
        }

       if (CalculateDistance.Instance.POI == 2 && CalculateDistance.Instance.played == false)
       {
           playSound(right);
           CalculateDistance.Instance.played = true;
       }

       if (CalculateDistance.Instance.POI == 3 && CalculateDistance.Instance.played == false)
       {
           playSound(left);
           CalculateDistance.Instance.played = true;
       }

       if (CalculateDistance.Instance.POI == 4 && CalculateDistance.Instance.played == false)
       {
           playSound(soon);
           CalculateDistance.Instance.played = true;
       }

       if(CalculateDistance.Instance.POI == 5 && CalculateDistance.Instance.played == false)
       {
           playSound(goal);
           CalculateDistance.Instance.played = true;
       }
    }
    
}

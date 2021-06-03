using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{  
    public static Audio Instance {get; set;}
    public AudioSource source;
    public AudioClip clip;
    public AudioClip left;
    public AudioClip right;
    public AudioClip start;
    public AudioClip soon;
    public AudioClip goal;

    public AudioClip state;

    float  cooldown;

    public bool played = false;

    void Start(){
        playSound(start);
    }

    void playSound(AudioClip status){
        if(!source.isPlaying && played == false){
            source.PlayOneShot(status);
            played = true;
        }
        played = false;
        
    }
    void Update()
    {
        cooldown += Time.deltaTime;
        
        if(cooldown > 15f){
            if(UpdateDistance.Instance.result < 10f && UpdateDistance.Instance.result > 5f){
                playSound(soon);
            }
            if(UpdateDistance.Instance.result > 0f && UpdateDistance.Instance.result < 5f){
                playSound(goal);
            }      
            cooldown = 0;
        }
        Debug.Log(state.name.ToString());
        Debug.Log(cooldown.ToString());
    }
}

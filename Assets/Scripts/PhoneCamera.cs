using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneCamera : MonoBehaviour
{
   private bool camAvailable;
   private WebCamTexture rearCamera;
   private Texture defaultBackground;

   public RawImage background;
   public AspectRatioFitter fit;

   private void Start(){
       
       defaultBackground = background.texture;
       WebCamDevice[] devices = WebCamTexture.devices;

       if(devices.Length == 0){
           Debug.Log("No camera detected");
           camAvailable = false;
           return;
       }
       for(int i = 0; i < devices.Length; i++){
           if(!devices[i].isFrontFacing){
               rearCamera = new WebCamTexture(devices[i].name, Screen.width, Screen.height);
           }
       }

       if(rearCamera == null){
               Debug.Log("Unable to find rear camera");
               return;
           }

           rearCamera.Play();
           background.texture = rearCamera;

           camAvailable = true;
   }

   private void Update(){
       if(!camAvailable)
           return;

       float ratio = (float)rearCamera.width / (float)rearCamera.height;
       fit.aspectRatio = ratio;

       float scaleY = rearCamera.videoVerticallyMirrored ? -1f: 1f;
       background.rectTransform.localScale = new Vector3(1f, scaleY, -1f);

       int orient = -rearCamera.videoRotationAngle;
       background.rectTransform.localEulerAngles = new Vector3(0,0,orient);
   }
}


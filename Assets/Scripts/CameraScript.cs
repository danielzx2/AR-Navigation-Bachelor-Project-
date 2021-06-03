using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{
    int currentCamIndex = 0;

    public RawImage display;
    public Text startStopText;
    public Quaternion baseRotation;

    WebCamTexture tex;

    private void Start(){
        WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            tex.Play();
    }
    void Update(){
        int orient = -tex.videoRotationAngle;
        display.rectTransform.localEulerAngles = new Vector3(0,0,orient);
    }
}

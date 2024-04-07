using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public CameraFade cameraFade;
    void Start()
    {
        cameraFade.FadeOut();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

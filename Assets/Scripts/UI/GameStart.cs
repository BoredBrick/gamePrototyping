using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public CameraFade cameraFade;
    void Start()
    {
        Time.timeScale = 1;
        cameraFade.FadeOut();
    }
}

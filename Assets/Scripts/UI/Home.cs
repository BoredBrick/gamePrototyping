using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Home : MonoBehaviour
{
    public GameObject Button;
    public void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(Button);
    }
}

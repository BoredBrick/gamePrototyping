using UnityEngine;
using UnityEngine.EventSystems;


public class Menu : MonoBehaviour
{
    public GameObject BackButton;

    public void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(BackButton);
    }
}

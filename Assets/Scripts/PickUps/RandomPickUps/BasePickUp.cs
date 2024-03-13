using UnityEngine;

public abstract class BasePickUp : MonoBehaviour
{
    public abstract string PickUpName { get; }
    public abstract void StartEffect();
}

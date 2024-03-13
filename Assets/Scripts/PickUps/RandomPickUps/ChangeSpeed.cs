using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class ChangeSpeed : BasePickUp
{
    public int speed;

    public override string PickUpName { get => SetName(); }

    public override void StartEffect()
    {
        StartCoroutine(SpeedChange());
    }

    private string SetName()
    {
        return (speed == 12) ? "FASTER RUNNING" : "SLOWER RUNNING";
    }

    IEnumerator SpeedChange()
    {
        PlayerMove.moveSpeed = speed;
        yield return new WaitForSecondsRealtime(10f);
        PlayerMove.moveSpeed = Constants.defaultMoveSpeed;
        yield return null;
    }
}

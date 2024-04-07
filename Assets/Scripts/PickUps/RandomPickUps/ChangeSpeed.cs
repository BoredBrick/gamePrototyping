using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class ChangeSpeed : BasePickUp
{
    private readonly int slowSpeed = 2;
    private readonly int fastSpeed = 10;

    public bool MakeFaster;

    public override string PickUpName { get => SetName(); }

    public override bool IsPositive { get => MakeFaster; }

    public override void StartEffect()
    {
        StartCoroutine(SpeedChange());
    }

    private string SetName()
    {
        return (MakeFaster) ? "FASTER RUNNING" : "SLOWER RUNNING";
    }

    IEnumerator SpeedChange()
    {
        PlayerMove.moveSpeed = MakeFaster ? fastSpeed : slowSpeed;
        yield return new WaitForSecondsRealtime(10f);
        PlayerMove.moveSpeed = Constants.defaultMoveSpeed;
        yield return null;
    }
}

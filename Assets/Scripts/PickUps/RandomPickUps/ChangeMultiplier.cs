using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class ChangeMultiplier : BasePickUp
{
    public override string PickUpName { get => "2X SCORE MULTIPLIER"; }

    public override void StartEffect()
    {
        Constants.PointsMultiplier *= 2;
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSecondsRealtime(10f);
        Constants.PointsMultiplier /= 2;
    }
}

using Assets.Scripts;
using System.Collections;
using UnityEngine;

public class MegaJump : BasePickUp
{
    public override string PickUpName { get => "MEGA JUMP"; }

    public override void StartEffect()
    {
        StartCoroutine(JumpChange());
    }

    IEnumerator JumpChange()
    {
        PlayerMove.jumpForce = 17;
        yield return new WaitForSecondsRealtime(10f);
        PlayerMove.jumpForce = Constants.defaultJumpForce;
        yield return null;
    }
}

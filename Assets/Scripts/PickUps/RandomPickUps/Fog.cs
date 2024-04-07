using System.Collections;
using UnityEngine;

public class Fog : BasePickUp
{
    public static readonly float defaultFogDensity = 0.012f;
    public static readonly float effectFogDensity = 0.090f;
    public override string PickUpName { get => "FOG"; }
    public override bool IsPositive { get => false; }
    public override void StartEffect()
    {
        StartCoroutine(FogFade());
    }

    IEnumerator FogFade()
    {
        while (RenderSettings.fogDensity <= effectFogDensity)
        {
            RenderSettings.fogDensity += 0.1f * Time.deltaTime;
            yield return null;
        }

        yield return new WaitForSecondsRealtime(10);

        while (RenderSettings.fogDensity >= defaultFogDensity)
        {
            RenderSettings.fogDensity -= 0.1f * Time.deltaTime;
            yield return null;
        }
        yield return null;
    }
}

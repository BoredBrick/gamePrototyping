using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomPickUps : MonoBehaviour
{
    public List<BasePickUp> pickUps;
    public List<string> activePickUps;
    public GameObject display;
    public GameObject foreground;
    public GameObject label;
    private List<GameObject> labels = new();


    public void TriggerEffect()
    {
        BasePickUp chosenEffect = pickUps[Random.Range(0, pickUps.Count)];
        chosenEffect.StartEffect();
        activePickUps.Add(chosenEffect.PickUpName);
        StartCoroutine(LabelLife());
    }

    private void RefreshDisplay()
    {
        if (activePickUps.Count == 0)
        {
            display.SetActive(false);
        }
        display.SetActive(true);
        int active = activePickUps.Count;
        display.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 100 * active);
        foreground.GetComponent<RectTransform>().sizeDelta = new Vector2(480, 80 + 100 * (active - 1));

        foreach (var label in labels)
        {
            Destroy(label);
        }
        labels = new();

        int count = 0;
        foreach (var pickUp in activePickUps)
        {
            var newLabel = Instantiate(label);
            labels.Add(newLabel);
            newLabel.transform.SetParent(display.transform);
            newLabel.transform.localPosition = new Vector3(-46.86502f, -24.39911f - 100 * (count), 0);
            newLabel.transform.localScale = new Vector3(1.30765f, 1.231246f, 1.231246f);
            newLabel.GetComponent<TMP_Text>().text = pickUp;
            count++;
        }
    }

    IEnumerator LabelLife()
    {
        RefreshDisplay();
        yield return new WaitForSecondsRealtime(10f);
        activePickUps.RemoveAt(0);
        RefreshDisplay();
        yield return null;
    }

}

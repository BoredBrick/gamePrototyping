using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum TypeOfPickUp
{
    Positive,
    Negative,
    Mixed
}

public class RandomPickUps : MonoBehaviour
{
    public List<BasePickUp> pickUps;
    public List<string> activePickUps = new();
    public GameObject display;
    public GameObject foreground;
    public GameObject label;
    private List<GameObject> labels = new();

    public void TriggerEffect()
    {
        BasePickUp chosenEffect = GetRandomPickUp();
        Debug.Log(chosenEffect.PickUpName);
        chosenEffect.StartEffect();
        activePickUps.Add(chosenEffect.PickUpName);
        StartCoroutine(LabelLife());
    }

    private BasePickUp GetRandomPickUp()
    {
        return pickUps[UnityEngine.Random.Range(0, pickUps.Count)];
    }

    public List<BasePickUp> GetPickUps(TypeOfPickUp typeOfPickUp)
    {
        List<BasePickUp> filteredPickUps = new();

        foreach (BasePickUp pickup in pickUps)
        {
            switch (typeOfPickUp)
            {
                case TypeOfPickUp.Positive:
                    if (pickup.IsPositive)
                        filteredPickUps.Add(pickup);
                    break;
                case TypeOfPickUp.Negative:
                    if (!pickup.IsPositive)
                        filteredPickUps.Add(pickup);
                    break;
                case TypeOfPickUp.Mixed:
                    return pickUps; 
                default:
                    throw new ArgumentOutOfRangeException(nameof(typeOfPickUp), typeOfPickUp, null);
            }
        }

        return filteredPickUps;
    }

    public void TriggerPickUp(TypeOfPickUp typeOfPickUp)
    {
        List<BasePickUp> pickedPickUps = GetPickUps(typeOfPickUp);

        if (pickedPickUps.Count > 0)
        {
            BasePickUp chosenEffect;

            if (typeOfPickUp == TypeOfPickUp.Mixed)
                chosenEffect = GetRandomPickUp();
            else
                chosenEffect = pickedPickUps[UnityEngine.Random.Range(0, pickedPickUps.Count)];

            Debug.Log(chosenEffect.PickUpName);
            chosenEffect.StartEffect();
            activePickUps.Add(chosenEffect.PickUpName);
            StartCoroutine(LabelLife());
        }
    }

    private IEnumerator LabelLife()
    {
        RefreshDisplay();
        yield return new WaitForSecondsRealtime(10f);
        activePickUps.RemoveAt(0);
        RefreshDisplay();
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
}

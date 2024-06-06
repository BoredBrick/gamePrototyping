using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class IntroSlides : MonoBehaviour
{
    public Sprite[] slides;
    public CameraFade cameraFade;


    //create function that will show each slide for 3 seconds on image component of SlidePicture gameobject, then fade out and show next slide
    IEnumerator ShowSlides()
    {
        for (int i = 0; i < slides.Length; i++)
        {
            var ob = GameObject.Find("SlidePicture"); // Find the GameObject with the name "SlidePicture
            ob.GetComponent<Image>().sprite = slides[i]; // Set the sprite of the Image component on the GameObject to the current slide
            cameraFade.FadeOut();
            if(i == 0)
            {
                yield return new WaitForSeconds(7);
            } else
            {
            yield return new WaitForSeconds(3);

            }
            cameraFade.FadeIn();
            yield return new WaitForSeconds(0.5f);
        }
            StartGame();
    }


    void Start()
    {
        StartCoroutine(ShowSlides());
    }
    //start another level
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown)
        {
            StartGame();
        }
    }
}

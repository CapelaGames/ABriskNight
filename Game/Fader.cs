using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fader : MonoBehaviour
{
    public Image fadeImage;
    public float FadeSpeed;
    public bool isFadeToClear;

    public void OnEnable()
    {
        if(isFadeToClear)
        {
            Color tempcolor = fadeImage.color;
            tempcolor.a = 1f;
            fadeImage.color = tempcolor;
        }
        else
        {
            Color tempcolor = fadeImage.color;
            tempcolor.a = 0f;
            fadeImage.color = tempcolor;
        }
    }

    public void Update()
    {
        if (isFadeToClear)
        {
            FadeToClear();

            if (fadeImage.color.a <= 0.05f)
            {
                fadeImage.color = Color.clear;
                fadeImage.enabled = false;
                this.gameObject.SetActive(false);
            }
        }
        else
        {
            FadeToImage();

            if (fadeImage.color.a >= 0.95f)
            {
                Color tempcolor = fadeImage.color;
                tempcolor.a = 1f;
                fadeImage.color = tempcolor;
                //fadeImage.enabled = false;
                this.gameObject.SetActive(false);
            }
        }
        
    }

    public void FadeToClear()
    {
        fadeImage.color = Color.Lerp(fadeImage.color, Color.clear, FadeSpeed * Time.deltaTime);
    }

    public void FadeToImage()
    {
        fadeImage.color = Color.Lerp(Color.clear, fadeImage.color,  FadeSpeed * Time.deltaTime);
    }

}

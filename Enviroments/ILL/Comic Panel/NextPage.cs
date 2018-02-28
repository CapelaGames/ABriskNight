using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextPage : MonoBehaviour
{
    public Image DisplayImage;
    public List<Image> Comic;

    public bool isLoadEndGame = false;

    int CurrentPage = 0;

    public float TimeBetweenPages = 1.5f;

    public float TimeBetweenCrashPage = 1.5f;


    public GameObject QuitButton;

    float timeLastPage;
	// Use this for initialization
	void Start ()
    {
        timeLastPage = Time.time;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CurrentPage == 1 && isLoadEndGame == true)
        {
            if (timeLastPage + TimeBetweenCrashPage < Time.time)
            {
                CurrentPage++;
                DisplayImage.sprite = Comic[CurrentPage].sprite;
                timeLastPage = Time.time;

                QuitButton.SetActive(true);
                //Play outroMusic
            }
        }
        else
        {
            if (CurrentPage >= 2)
            {

                if (timeLastPage + TimeBetweenCrashPage < Time.time)
                {
                    CurrentPage++;
                    if (CurrentPage >= Comic.Count)
                    {
                        if (isLoadEndGame == true)
                        {

                        }
                        else
                        {
                            SceneManager.LoadScene("Game");
                        }
                    }
                    else
                    {
                        DisplayImage.sprite = Comic[CurrentPage].sprite;
                        timeLastPage = Time.time;
                    }
                }
            }
            else if (timeLastPage + TimeBetweenPages < Time.time)
            {
                CurrentPage++;

                if (CurrentPage >= Comic.Count)
                {
                    if (isLoadEndGame == true)
                    {

                    }
                    else
                    {
                        SceneManager.LoadScene("Game");
                    }
                }
                else
                {
                    DisplayImage.sprite = Comic[CurrentPage].sprite;
                    timeLastPage = Time.time;
                }
            }
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public bool isForWalk = false;

    public bool isPaused = false;
    public FmodRadioStation radio;

    public ChangeScene changeScene;
    public GameObject enablePauseMenu;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isForWalk)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                isPaused = !isPaused;
                if (isPaused)
                {
                    Pause();
                }
                else
                {
                    Resume();
                }

            }
        }
    }

    public void Pause()
    {
        if(!isForWalk)
        {
            radio.isPaused = true;
        }
        
        enablePauseMenu.SetActive(true);
        changeScene.ChangeToPause(true);

        if (!isForWalk)
        {
            Time.timeScale = 0;
        }
    }
    public void Resume()
    {
        if (!isForWalk)
        {
            radio.isPaused = false;
        }
        
        enablePauseMenu.SetActive(false);
        changeScene.ChangeToPause(false);

        if (!isForWalk)
        {
            Time.timeScale = 1;
        }
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}

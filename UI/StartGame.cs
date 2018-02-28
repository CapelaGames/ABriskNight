using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
    public void LoadFirstLevel()
    {
        SceneManager.LoadScene("Comic");
        //Application.LoadLevel("Game");
    }

	// Update is called once per frame
	void Update ()
    {
		
	}
}

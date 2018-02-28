using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreenSeatButton : MonoBehaviour
{
    public ChangeScene changeScene;


	// Use this for initialization
	void Start ()
    {
		if(changeScene == null)
        {
            Debug.LogError("changeScene is missing from NextScreenBootButton");
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnMouseDown()
    {
        changeScene.ChangeLocationSeat();
    }
}

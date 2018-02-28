using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextScreenBootButton : MonoBehaviour
{
    public ChangeScene changeScene;

    public HeatSystem heatSystem;


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
        changeScene.ChangeLocationBoot();

        if (heatSystem != null)
        {
            heatSystem.GoOutSideHeatLost();
        }
    }
}

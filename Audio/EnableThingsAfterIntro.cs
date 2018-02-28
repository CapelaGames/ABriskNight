using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableThingsAfterIntro : MonoBehaviour
{
    public List<GameObject> enableThese;
    public float Delay;
    public float StartTime;


	// Use this for initialization
	void Start ()
    {
        StartTime = Time.time;
    }
	
	// Update is called once per frame
	void Update ()
    {
		if(StartTime + Delay < Time.time)
        {
            foreach(GameObject thing in enableThese)
            {
                thing.SetActive(true);
            }

            this.gameObject.SetActive(false);
        }
	}
}

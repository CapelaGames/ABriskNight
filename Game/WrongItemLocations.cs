using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongItemLocations : MonoBehaviour
{
    public List<LocationClass> Locations;

    public void PlaceItem(GameObject item)
    {
        foreach(LocationClass spot in Locations)
        {
            if(spot != null)
            {
                if(spot.isTaken == false)
                {
                    spot.isTaken = true;

                    item.transform.position = spot.location.position;
                    return;
                }
              
            }
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

[Serializable]
public class LocationClass
{
    public Transform location;
    public bool isTaken = false;
}
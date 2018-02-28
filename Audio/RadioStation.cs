using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadioStation : MonoBehaviour
{
    public List<Station> Stations;
    public float firstStation;
    public Station currentStation;

    // Use this for initialization
    void Start ()
    {
        PlayNextStation(firstStation);

    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void PlayNextStation(float nextStationNumber)
    {
        foreach (Station nextStation in Stations)
        {
            if (nextStation.StationNumber == nextStationNumber)
            {
                nextStation.PlayStation();
                if (currentStation != null)
                {
                    currentStation.StopStation();
                }
                currentStation = nextStation;
                break;
            }
        }
    }
    
}

[Serializable]
public class Station
{
    public AudioSource StationSound;
    public float StationNumber;

    public void PlayStation()
    {
        if (StationSound)
        {
            StationSound.volume = 1;
            StationSound.Play();
        }
    }

    public void StopStation()
    {
        if (StationSound)
        {
            StationSound.volume = 0f;
        }
    }
}
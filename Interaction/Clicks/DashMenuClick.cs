using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashMenuClick : MonoBehaviour
{
    public WaveAnimation waveAnimation;
   // public RadioStation radio;

    void Start()
    {
        if (waveAnimation == null)
        {
            Debug.LogError("waveAnimation missing from DashMenuClick");
        }
        /*
        if(radio == null)
        {
            Debug.LogError("RadioStation missing from DashMenuClick");
        }*/
    }

	void OnMouseDown()
    {
        waveAnimation.isSearching = !waveAnimation.isSearching;

        

        //radio.PlayNextStation(102.3f);


    }
}

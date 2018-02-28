using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAnimation : MonoBehaviour
{
    Animator anim;
    public bool isSearching = false;
    float timeOfIssearching;
    public float SecondsUntilWaveReturnToNormal;


    void Start ()
    {
        anim = GetComponent<Animator>();

        if(anim == null)
        {
            Debug.LogError("anim missing from WaveAnimation");
        }

        timeOfIssearching = Time.time;
    }

    void Update()
    {
        if((timeOfIssearching + SecondsUntilWaveReturnToNormal) < Time.time)
        {
            isSearching = false;
        }

        if (anim.GetBool("isSearching") != isSearching)
        {
            anim.SetBool("isSearching", isSearching);
        }
    }

    public void setIsSearching()
    {

        timeOfIssearching = Time.time;
        isSearching = true;
    }
	
}

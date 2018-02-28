using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatSystem : MonoBehaviour
{

    
    public float CurrentHeat;
    public float StartHeat;

    public float MaxHeat;
    public float MinHeat;

    public float HeatDegrade;
    public bool PauseDegrade;

    public float HeatLostGoingOutside;

    // Use this for initialization
    void Start ()
    {
        CurrentHeat = StartHeat;


    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CurrentHeat > MinHeat)
        {
            if (PauseDegrade == false)
            {
                CurrentHeat -= HeatDegrade * Time.deltaTime;
            }
        }
        else
        {
            //Debug.Log("Player Death");
        }
    }


    public void IncreaseHeatBy(float HeatIncrease)
    {
        CurrentHeat += HeatIncrease;

        if(CurrentHeat > MaxHeat)
        {
            CurrentHeat = MaxHeat;
        }
    }

    public void DecreaseHeatBy(float HeatDecrease)
    {
        CurrentHeat -= HeatDecrease;

        if (CurrentHeat < MinHeat)
        {
            CurrentHeat = MinHeat;
        }
    }

    public void GoOutSideHeatLost()
    {
        CurrentHeat -= HeatLostGoingOutside;

        if (CurrentHeat < MinHeat)
        {
            CurrentHeat = MinHeat;
        }
    }
}

using FMOD.Studio;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FmodRadioStation : MonoBehaviour
{

    public bool isPaused = false;
    public bool isOutside = false;

    public float CurrentStationNumber;
    public float MaxStationNumber;
    public float MinStationNumber;

    private FMOD.Studio.EventInstance RadioFMOD;
    private FMOD.Studio.ParameterInstance RadioParameterFMOD;
    private FMOD.Studio.ParameterInstance InsideParameterFMOD;

    void Start()
    {
        RadioFMOD = FMODUnity.RuntimeManager.CreateInstance("event:/Radio");
        RadioFMOD.start();
        RadioFMOD.getParameter("Frequency", out RadioParameterFMOD);

        RadioFMOD.getParameter("Inside", out InsideParameterFMOD);
    }

    public void StopRadio()
    {
        RadioFMOD.stop(STOP_MODE.ALLOWFADEOUT);
    }

    void Update()
    {

        if(isPaused == true)
        {
            FMODUnity.RuntimeManager.PauseAllEvents(true);
        }
        else
        {
            FMODUnity.RuntimeManager.PauseAllEvents(false);
        }

        if(CurrentStationNumber > MaxStationNumber)
        {
            CurrentStationNumber = MaxStationNumber;
        }

        if (CurrentStationNumber < MinStationNumber)
        {
            CurrentStationNumber = MinStationNumber;
        }

        
       


        RadioParameterFMOD.setValue(CurrentStationNumber);
        if(isOutside)
        {

            InsideParameterFMOD.setValue(1);
        }
        else
        {
            InsideParameterFMOD.setValue(0);
        }
        
        //FMOD.Studio.Bank bank;
        //Load the FMOD bank
        // FMOD.Studio.Bank bank;
        //fmod (set stationNumber)
    }

    public void ChangeFrequency(float newNumber)
    {
        CurrentStationNumber = newNumber;
    }
}

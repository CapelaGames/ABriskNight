using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeatUI : MonoBehaviour
{
    public HeatSystem heatSystem;

    public int AmmountOfHeatPips;

    public float HeatPercent;
    public float HowManyPips;
    float HowManyPipsCurrent;

    public GameObject[] HeatPips;

    void Start()
    {
        HowManyPipsCurrent = HowManyPips;
        if (heatSystem == null)
        {
            Debug.LogError("HeatSystem not attached to HeatUI");
        }
    }

    void Update()
    {
        float top = heatSystem.CurrentHeat - heatSystem.MinHeat;
        float bottom = heatSystem.MaxHeat - heatSystem.MinHeat;
        HeatPercent = top / bottom;

        float percentEachPipIsWorth = 1f / AmmountOfHeatPips;

        HowManyPips = HeatPercent / percentEachPipIsWorth;

        bool isPipOn;
        if (HowManyPipsCurrent != HowManyPips)
        { 
            isPipOn = true;
            int pipCount = 0;
            foreach (GameObject pip in HeatPips)
            {
                if (pipCount >= HowManyPips)
                {
                    isPipOn = false;
                }

                if (isPipOn == true)
                {
                    pip.SetActive(true);
                }
                else
                {
                    pip.SetActive(false);
                }

                pipCount++;
            }
            HowManyPipsCurrent = HowManyPips;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    public List<Slot> Slots;
    public bool canReturn = false;

    public bool EnableOnFull = false;
    public GameObject enabledGameObjectOnFull;

    void Update()
    {
        int slotCount = 0;
        foreach (Slot slot in Slots)
        {
            if (slot.gameClickObject != null)
            {
                slotCount++;
            }
        }

        if(slotCount == Slots.Count)
        {
            enabledGameObjectOnFull.SetActive(true);
        }
    }

    public void AddToInventory(GameClickObject gameClickObject)
    {
        foreach (Slot slot in Slots)
        {
            if (slot.gameClickObject == null)
            {
                slot.gameClickObject = gameClickObject;
                slot.image.sprite = slot.gameClickObject.objectSprite;
                gameClickObject.gameObject.SetActive(false);
                break;
            }
        }
    }

    public void RemoveFromInventory(GameClickObject gameClickObject)
    {
        foreach (Slot slot in Slots)
        {
            if (slot.gameClickObject == gameClickObject)
            {
                //slot.gameClickObject.gameObject.SetActive(true);
                slot.gameClickObject = null;
                slot.image.sprite = null;
                return;
            }
        }
    }

    public void ReturnObjectToEnvironment(Image image)
    {
        if (canReturn)
        {
            foreach (Slot slot in Slots)
            {
                if (slot.image == image)
                {
                    slot.gameClickObject.gameObject.SetActive(true);
                    slot.gameClickObject = null;
                    slot.image.sprite = null;
                    return;
                }
            }
        }
    }

    void Start()
    {
        foreach (Slot slot in Slots)
        {
            if (slot.gameClickObject != null)
            {
                if (slot.gameClickObject.objectSprite != null)
                {
                    slot.image.sprite = slot.gameClickObject.objectSprite;
                }
            }
        }
    }
}


[Serializable]
public class Slot
{
    public Image image;
    public GameClickObject gameClickObject;
}

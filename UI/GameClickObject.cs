using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameClickObject : MonoBehaviour
{
    public Sprite objectSprite;

    public bool isImportantObect;

    public Inventory inventory;

    public bool isDisabled = false;

    public AudioSource soundEffect;

    // Use this for initialization
    void Start()
    {
        if (objectSprite == null)
        {
            Debug.LogError("objectSprite not in GameClickObject");
        }

        if (inventory == null)
        {
            Debug.LogError("inventory not in GameClickObject");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


    void OnMouseDown()
    {
        if (isDisabled == false)
        {
            inventory.AddToInventory(this);

            if(soundEffect  != null)
            {
                soundEffect.Play();
            }
        }
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BearClickObject : MonoBehaviour
{
    public Sprite objectSprite;
    public Sprite BearSpriteOpen;
    public Sprite BearSpriteEmpty;

    public GameClickObject Batteries;

    public SpriteRenderer bearObject;

    public bool isClosed = true;
    public bool isEmpty = false;

    public bool isImportantObect;

    public Inventory inventory;

    public bool isDisabled = false;

    // Use this for initialization
    void Start()
    {
        if (objectSprite == null)
        {
            Debug.LogError("objectSprite not in BearClickObject");
        }

        if (inventory == null)
        {
            Debug.LogError("inventory not in BearClickObject");
        }

        if (bearObject == null)
        {
            Debug.LogError("bearObject not in BearClickObject");
        }

        if (Batteries == null)
        {
            Debug.LogError("Batteries not in BearClickObject");
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

            if (isClosed)
            {
                bearObject.sprite = BearSpriteOpen;
                isClosed = false;
            }
            else if(!isEmpty)
            {
                bearObject.sprite = BearSpriteEmpty;
                Batteries.gameObject.SetActive(true);
                inventory.AddToInventory(Batteries);

                isEmpty = true;
            }
            
        }

    }
}

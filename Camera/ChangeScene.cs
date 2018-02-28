using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public PauseMenu SnowOutMenu;
    public float SnowOutLength = 5f;

    public FmodRadioStation radioManager;

    public Camera cameraToChange;
    public PanCamera panCamera;

    public Transform BootCameraStartLocaiton;

    public Vector3 BOOTPanLimitBottomLeftCorner;
    public Vector3 BOOTPanLimitTopRightCorner;

    public GameObject OutsideInventoryUI;



    public Transform FrontCameraStartLocaiton;

    public Vector3 FRONTPanLimitBottomLeftCorner;
    public Vector3 FRONTPanLimitTopRightCorner;

    public GameObject FrontInventoryUI;


    public Inventory InsideInventory;
    public Inventory HandsInventory;

    public WrongItemLocations wrongItemLocations;


    /// <summary>
    ///under
    /// </summary>
    public Transform UnderCameraStartLocaiton;

    public Vector3 UnderPanLimitBottomLeftCorner;
    public Vector3 UnderPanLimitTopRightCorner;


    /// <summary>
    /// Bonnet
    /// </summary>
    public Transform BonnetCameraStartLocaiton;

    public Vector3 BonnetPanLimitBottomLeftCorner;
    public Vector3 BonnetPanLimitTopRightCorner;


/// <summary>
/// backseat
/// </summary>
    public Transform backseatCameraStartLocaiton;

    public Vector3 backseatPanLimitBottomLeftCorner;
    public Vector3 backseatPanLimitTopRightCorner;
    //-------------------------------------------

    public Transform PAUSELocaiton;
    public void Start()
    {
        if(cameraToChange == null)
        {
            Debug.LogError("cameraToChange not attached to ChangeScene");
        }

        if (panCamera == null)
        {
            Debug.LogError("panCamera not attached to ChangeScene");
        }

        if (InsideInventory == null)
        {
            Debug.LogError("InsideInventory not attached to ChangeScene");
        }

        if (HandsInventory == null)
        {
            Debug.LogError("HandsInventory not attached to ChangeScene");
        }

        if (wrongItemLocations == null)
        {
            Debug.LogError("WrongItemLocations not attached to ChangeScene");
        }

        if (SnowOutMenu == null)
        {
            Debug.LogError("SnowOutMenu not attached to ChangeScene");
        }
    }

    Vector3 LastPositionOfCameraPause;

    public void ChangeToPause(bool isPaused)
    {
        if(isPaused)
        {
            LastPositionOfCameraPause = cameraToChange.transform.position;
            cameraToChange.transform.position = PAUSELocaiton.position;
        }
        else
        {
            cameraToChange.transform.position = LastPositionOfCameraPause;
        }
    }

    Vector3 NextLocation;
    public void ChangeToSnowout(Vector3 nextLocation)
    {
        SnowOutMenu.Pause();

        cameraToChange.transform.position = PAUSELocaiton.position;

        NextLocation = nextLocation;
        StartCoroutine("waitToMove");

        //    LastPositionOfCameraPause = cameraToChange.transform.position;
        //     cameraToChange.transform.position = PAUSELocaiton.position;
        // }
        // else
        // {
        //    cameraToChange.transform.position = LastPositionOfCameraPause;
        //}
    }

    IEnumerator waitToMove()
    {

        yield return new WaitForSeconds(SnowOutLength);

        SnowOutMenu.Resume();
        cameraToChange.transform.position = NextLocation;
    }

    public void ChangeLocationSeat()
    {
        cameraToChange.transform.position = backseatCameraStartLocaiton.position;

        panCamera.PanLimitBottomLeftCorner = backseatPanLimitBottomLeftCorner;
        panCamera.PanLimitTopRightCorner = backseatPanLimitTopRightCorner;

        OutsideInventoryUI.SetActive(true);
        FrontInventoryUI.SetActive(false);

        radioManager.isOutside = false;
    }

    public void ChangeLocationBonnet()
    {
        cameraToChange.transform.position = BonnetCameraStartLocaiton.position;

        panCamera.PanLimitBottomLeftCorner = BonnetPanLimitBottomLeftCorner;
        panCamera.PanLimitTopRightCorner = BonnetPanLimitTopRightCorner;

        OutsideInventoryUI.SetActive(true);
        FrontInventoryUI.SetActive(false);

        radioManager.isOutside = true;

        ChangeToSnowout(BonnetCameraStartLocaiton.position);
    }

    public void ChangeLocationUnder()
    {
        cameraToChange.transform.position = UnderCameraStartLocaiton.position;

        panCamera.PanLimitBottomLeftCorner = UnderPanLimitBottomLeftCorner;
        panCamera.PanLimitTopRightCorner = UnderPanLimitTopRightCorner;

        OutsideInventoryUI.SetActive(true);
        FrontInventoryUI.SetActive(false);

        radioManager.isOutside = true;

        ChangeToSnowout(UnderCameraStartLocaiton.position);
    }


   public void ChangeLocationBoot()
    {
        cameraToChange.transform.position = BootCameraStartLocaiton.position;

        panCamera.PanLimitBottomLeftCorner = BOOTPanLimitBottomLeftCorner;
        panCamera.PanLimitTopRightCorner = BOOTPanLimitTopRightCorner;

        OutsideInventoryUI.SetActive(true);
        FrontInventoryUI.SetActive(false);

        radioManager.isOutside = true;


        ChangeToSnowout(BootCameraStartLocaiton.position);
    }

    public void ChangeLocationFront()
    {
        if(radioManager.isOutside == true)
        {
            ChangeToSnowout(FrontCameraStartLocaiton.position);
        }

        Slot item = HandsInventory.Slots[0];
        if (item != null)
        {
            if (item.gameClickObject != null)
            {
                if (item.gameClickObject.isImportantObect == true)
                {
                    InsideInventory.AddToInventory(item.gameClickObject);
                    HandsInventory.RemoveFromInventory(item.gameClickObject);
                }
                else
                {
                    wrongItemLocations.PlaceItem(item.gameClickObject.gameObject);

                    item.gameClickObject.isDisabled = true;

                    HandsInventory.ReturnObjectToEnvironment(item.image);// .RemoveFromInventory(item.gameClickObject);
                }
            }

            radioManager.isOutside = false;
        }


        cameraToChange.transform.position = FrontCameraStartLocaiton.position;

        panCamera.PanLimitBottomLeftCorner = FRONTPanLimitBottomLeftCorner;
        panCamera.PanLimitTopRightCorner = FRONTPanLimitTopRightCorner;

        OutsideInventoryUI.SetActive(false);
        FrontInventoryUI.SetActive(true);


        
    }
}

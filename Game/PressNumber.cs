using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressNumber : MonoBehaviour
{
    public DialPadWinGame dialPad;
    public int Number;
    void OnMouseDown()
    {
        dialPad.SendNumberToDialPad(Number);
    }
}

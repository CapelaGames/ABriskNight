using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DialPadWinGame : MonoBehaviour
{
    public FmodRadioStation radio;

    public string WinningNumber;
    public string EnteredNumber;
    public int MaxNumbers;
    public int CurrentNumbers;

    public Text displayNumbers;

    void Start()
    {
        CurrentNumbers = 0;
    }

	public void SendNumberToDialPad(int number)
    {

        EnteredNumber += number.ToString();

        if (CurrentNumbers == MaxNumbers && WinningNumber != EnteredNumber)
        {
            EnteredNumber = "";
            CurrentNumbers = 0;
        }
        else
        {
            CurrentNumbers++;
        }

    }

    void Update()
    {
        displayNumbers.text = EnteredNumber;

        if (WinningNumber == EnteredNumber)
        {
            radio.StopRadio();
            SceneManager.LoadScene("ComicOutro");
        }
    }
}

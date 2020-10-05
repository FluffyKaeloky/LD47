using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class DisplayPanel : MonoBehaviour
{
    [SerializeField] DoorPad DoorPadScriptableObject;
    [SerializeField]TMP_Text displayText;
    [SerializeField] DoorPadManager doorPadManager;
    int count = 0;

    public void DisplayNumber(int num)
    {
        
        if(count < 5)
        {
            displayText.text += num;
            count++;
        }
        
        if (count == 5)
        {
            if(displayText.text == DoorPadScriptableObject.CodeNumber)
            {
                displayText.text = "Unlock";
                doorPadManager.OpenDoorPad(DoorPadScriptableObject.CodeNumber);
                count++;
            }
            else
            {
                StartCoroutine(RetryInput());
            }
        }
    }

    //public bool GetDisplay()
    //{
    //    return display.text == "Unlock" ? true : false;
    //}
    IEnumerator RetryInput()
    {
        displayText.text = "Retry";
        count = 0;
        yield return new WaitForSeconds(0.5f);
        displayText.text = "";
    }
}

using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;

public class DisplayPanel : MonoBehaviour
{
    [SerializeField] DoorPad CorrespondingDoor;
    [SerializeField]TMP_Text display;
    [SerializeField] DoorPadManager door;
    int count = 0;

    public void DisplayNumber(int num)
    {
        
        if(count < 5)
        {
            display.text += num;
            count++;
        }
        
        if (count == 5)
        {
            if(display.text == "12345")
            {
                display.text = "Unlock";
                door.OpenDoorPad();
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
        display.text = "Retry";
        count = 0;
        yield return new WaitForSeconds(0.5f);
        display.text = "";
    }
}

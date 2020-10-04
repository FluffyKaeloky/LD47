using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DisplayPanel : MonoBehaviour
{
    [SerializeField]TMP_Text display;
    DoorPad doorPad;
    int count = 0;

    private void Awake()
    {
        doorPad = GetComponent<DoorPad>();
    }
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
                count++;
            }
            else
            {
                StartCoroutine(RetryInput());
            }
        }
    }

    public bool DoorUnlock()
    {
        if(display.text == "Unlock")
            return true;
        
        return false;
    }
    IEnumerator RetryInput()
    {
        display.text = "Retry";
        count = 0;
        yield return new WaitForSeconds(0.5f);
        display.text = "";
    }
}

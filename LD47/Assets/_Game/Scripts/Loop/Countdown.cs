using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour {
    public TMP_Text textBox;

	public void SetTimer(float loopTimer)
    {
		textBox.text = loopTimer.ToString();
		
	}

    public float TimeDown(float loopTimer)
    {
		loopTimer -= Time.deltaTime;
		textBox.text = Mathf.Round(loopTimer).ToString();
		return loopTimer;
	}
}
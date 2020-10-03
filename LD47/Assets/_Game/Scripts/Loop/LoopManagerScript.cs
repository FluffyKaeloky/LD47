/*
 *  Start a new loop when timer is down
 *  Dependennce :
 *  loopgameobject
 *  respawn
 *  countdown
 *  
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class LoopManagerScript : MonoBehaviour
{
    public static LoopManagerScript instance = null;
    public List<GameObject> loopList = new List<GameObject>();
    public int currentLoop = 0;

    private float startTime = 0.0f;
    private float loopTimer = 0.0f;

    Respawn respawn = null;
    Countdown countdown = null;
    Loop loop = null;


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        respawn = GetComponent<Respawn>();
        countdown = GetComponent<Countdown>();
        loop = loopList[currentLoop].GetComponent<Loop>();
        startTime = loop.GetLoopTimer();
        loopTimer = startTime;
    }
    
    private void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space))
            respawn.RespawnPlayer();
        StartNextLoop();
        Timer();
    }


    public void GetNextLoop()
    {
        if (currentLoop < loopList.Count)
            currentLoop++;
        else
            currentLoop = 0;
    }

    public void LoopChange()
    {
        if (currentLoop == loopList.Count - 1)
        {
            Debug.Log("GameOver");
            loopList[currentLoop].SetActive(false);
            loopList[0].SetActive(true);
            currentLoop = 0;
        }
        else if(currentLoop > 0)
        {
            loopList[currentLoop].SetActive(true);
            loopList[currentLoop - 1].SetActive(false);
        }
    }

    public void StartNextLoop()
    {
        if (loopTimer <= 0)
        {
            GetNextLoop();
            LoopChange();
            startTime = loop.GetLoopTimer();
            loopTimer = startTime;
            countdown.SetTimer(startTime);
            //respawn.RespawnPlayer();
        }
    }

    public void Timer()
    {
        loopTimer = countdown.TimeDown(loopTimer);
    }

    //[Button("Respawn")]
    //private  void TestRespawn()
    //{
    //    //await new WaitForFixedUpdate();
    //    //await new WaitForEndOfFrame();
    //    respawn.RespawnPlayer();
    //}
}

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

    private float loopTimer = 0.0f;

    [SerializeField] GameObject player;
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
        loopTimer = loop.GetLoopTimer();
    }

    private void Update()
    {
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
            player.SetActive(false);
            loopTimer = loop.GetLoopTimer();
            respawn.RespawnPlayer();
            GetNextLoop();
            LoopChange();
            countdown.SetTimer(loopTimer);
            player.SetActive(true);
            //StartCoroutine(WaitAndRespawn());
        }
}

    public void Timer()
    {
            loopTimer = countdown.TimeDown(loopTimer);
    }

    //IEnumerator WaitAndRespawn()
    //{
    //    loopTimer = loop.GetLoopTimer();
    //    respawn.RespawnPlayer();
    //    yield return new WaitForSeconds(0.5f);
    //    GetNextLoop();
    //    LoopChange();
    //    countdown.SetTimer(loopTimer);
    //}

    [Button("Respawn")]
    private async void TestRespawn()
    {
        await new WaitForFixedUpdate();
        await new WaitForEndOfFrame();
        respawn.RespawnPlayer();
    }
}

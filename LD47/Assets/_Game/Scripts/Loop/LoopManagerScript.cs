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
using UnityEngine.Events;

public class LoopManagerScript : MonoBehaviour
{
    public static LoopManagerScript instance = null;
    public List<Loop> loopList = new List<Loop>();
    public int currentLoop = 0;

    public float loopTimer = 0.0f;

    [SerializeField] GameObject player;
    Respawn respawn = null;
    Countdown countdown = null;
    Loop loop = null;

    public UnityEvent onTimerChanged = new UnityEvent();
    public UnityEvent onLoopStart = new UnityEvent();

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
            loopList[currentLoop].gameObject.SetActive(false);
            loopList[0].gameObject.SetActive(true);
            loopTimer = loop.GetLoopTimer();
            currentLoop = 0;
        }
        else if(currentLoop > 0)
        {
            loopList[currentLoop].gameObject.SetActive(true);
            loopList[currentLoop - 1].gameObject.SetActive(false);
            loopTimer = loopList[currentLoop].GetLoopTimer();

            onLoopStart?.Invoke();
        }
    }

    public void StartNextLoop()
    {
        if (loopTimer <= 0)
        {
            player.SetActive(false);
            respawn.RespawnPlayer();
            GetNextLoop();
            LoopChange();
            Debug.Log(loopTimer);
            countdown.SetTimer(loopTimer);
            player.SetActive(true);
            //StartCoroutine(WaitAndRespawn());
        }
}

    public void Timer()
    {
        loopTimer = countdown.TimeDown(loopTimer);

        onTimerChanged?.Invoke();
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

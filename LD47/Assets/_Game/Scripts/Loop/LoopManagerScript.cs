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
using AlmenaraGames;

public class LoopManagerScript : MonoBehaviour
{
    public static LoopManagerScript instance = null;
    public List<Loop> loopList = new List<Loop>();
    public int currentLoop = 0;

    public float loopTimer = 0.0f;

    public MultiAudioSource annoucerSource = null;

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

    private void Start()
    {
        if (loopList[0].startClip != null)
            annoucerSource.PlayOverride(loopList[0].startClip);

        for(int i = 0; i < loopList.Count; i++)
        {
            loopList[i].gameObject.SetActive(false);
        }
        currentLoop = 0;
        loopList[currentLoop].gameObject.SetActive(true);
                
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
        if (currentLoop >= loopList.Count)
        {
            Debug.Log("GameOver");
            loopList[currentLoop].gameObject.SetActive(false);
            loopList[0].gameObject.SetActive(true);
            currentLoop = 0;
        }
        else if(currentLoop > 0)
        {
            loopList[currentLoop].gameObject.SetActive(true);
            loopList[currentLoop - 1].gameObject.SetActive(false);

            if (loopList[currentLoop].startClip != null)
                annoucerSource.PlayOverride(loopList[currentLoop].startClip);

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
            loopTimer = loopList[currentLoop].GetLoopTimer();
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

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
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

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

    public List<Material> listMaterial = new List<Material>();

    [SerializeField] AudioObject deathSFX;
    public float timeMultiplier = 1.0f;

    public UnityEvent onTimerChanged = new UnityEvent();
    public UnityEvent onLoopStart = new UnityEvent();

    public UnityEvent onGameOver = new UnityEvent();

    private bool playAnnouncement = true;

    private void Awake()
    {
        instance = this;

        respawn = GetComponent<Respawn>();
        countdown = GetComponent<Countdown>();
        loop = loopList[currentLoop].GetComponent<Loop>();
        loopTimer = loop.GetLoopTimer();
    }

    private void Start()
    {
        if (loopList[0].startClip != null && playAnnouncement)
            annoucerSource.PlayOverride(loopList[0].startClip);

        for(int i = 0; i < loopList.Count; i++)
        {
            loopList[i].gameObject.SetActive(false);
        }
        currentLoop = 0;
        loopList[currentLoop].gameObject.SetActive(true);

        player.GetComponent<Damageable>().onDeath.AddListener(async () => 
        {
            timeMultiplier = 0.0f;

            await new WaitForSeconds(5.0f);

            player.SetActive(false);
            respawn.RespawnPlayer();

            GetNextLoop();
            await LoopChange();

            loopTimer = loopList[currentLoop].GetLoopTimer();

            timeMultiplier = 1.0f;

            player.SetActive(true);
        });
    }

    private void Update()
    {
        StartNextLoop();
    }


    public void GetNextLoop()
    {
        if (currentLoop < loopList.Count)
            currentLoop++;
        else
            currentLoop = 0;
    }

    public async Task<bool> LoopChange()
    {
        if (currentLoop >= loopList.Count)
        {
            playAnnouncement = false;

            Debug.Log("GameOver");
            //loopList[currentLoop].gameObject.SetActive(false);
            //loopList[0].gameObject.SetActive(true);
            currentLoop = 0;
            MultiAudioManager.PlayAudioObject(deathSFX, transform.position);

            listMaterial[0].SetFloat("_Fade", 1.0f);

            onGameOver?.Invoke();

            player.GetComponent<PlayerInput>().enabled = false;

            await new WaitForSeconds(deathSFX.clips[0].length + 1);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            listMaterial.ForEach((x) => {
                x.SetFloat("_Fade", 0.0f);
            });
            return true;
            
        }
        else if(currentLoop > 0)
        {
            loopList[currentLoop].gameObject.SetActive(true);
            loopList[currentLoop - 1].gameObject.SetActive(false);

            if (loopList[currentLoop].startClip != null && playAnnouncement)
                annoucerSource.PlayOverride(loopList[currentLoop].startClip);

            onLoopStart?.Invoke();
        }

        Damageable damageable = player.GetComponent<Damageable>();
        damageable.Health = damageable.MaxHealth;
        return false;
    }

    public async void StartNextLoop()
    {
        if (loopTimer <= 0)
        {
            player.SetActive(false);
            respawn.RespawnPlayer();
            GetNextLoop();
            bool r = await LoopChange();
            if(r == true)
                return;         
            loopTimer = loopList[currentLoop].GetLoopTimer();
            Debug.Log(loopTimer);
            countdown.SetTimer(loopTimer);
            player.SetActive(true);
            //StartCoroutine(WaitAndRespawn());
        }

        Timer();
    }

    public void Timer()
    {
        loopTimer = countdown.TimeDown(loopTimer, timeMultiplier);

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

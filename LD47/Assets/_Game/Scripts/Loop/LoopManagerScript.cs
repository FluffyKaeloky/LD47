using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Sirenix.OdinInspector;

public class LoopManagerScript : MonoBehaviour
{
    public static LoopManagerScript instance = null;
    public List<GameObject> loopList = new List<GameObject>();
    public int currentLoop = 0;
    [SerializeField] bool test = false;
    Respawn respawn;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject);

        respawn = GetComponent<Respawn>();
    }

    private void FixedUpdate()
    {
        //replace test with event listener
        if (test)
        {
            GetNextLoop();
            LoopChange();
            respawn.RespawnPlayer();
            test = false;
        }
    }

    public void GetNextLoop()
    {
        if(currentLoop < loopList.Count)
            currentLoop++;
    }
    public void LoopChange()
    {
        if (currentLoop > 0)
        {
            loopList[currentLoop].SetActive(true);
            loopList[currentLoop - 1].SetActive(false);
        }else if(currentLoop == loopList.Count)
        {
            Debug.Log("GameOver");
        }
    }

    //[Button("Respawn")]
    //private  void TestRespawn()
    //{
    //    //await new WaitForFixedUpdate();
    //    //await new WaitForEndOfFrame();
    //    respawn.RespawnPlayer();
    //}
}

using AlmenaraGames;
using DG.Tweening;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(ReactorVictoryManager))]
public class VictoryGUI : MonoBehaviour
{
    public CanvasGroup canvasGroup = null;
    public CanvasGroup textGroup = null;

    public AudioObject victoryAnnoucement = null;

    public float delay = 5.0f;

    private void Awake()
    {
        ReactorVictoryManager reactor = GetComponent<ReactorVictoryManager>();

        reactor.onVictory.AddListener(() => 
        {
            DoWin();
        });
    }

    private void Start()
    {
        canvasGroup.alpha = 0.0f;
        textGroup.alpha = 0.0f;

        canvasGroup.transform.root.gameObject.SetActive(false);
    }

    [Button("Win Now")]
    private async void DoWin()
    {
        canvasGroup.transform.root.gameObject.SetActive(true);

        MultiAudioManager.PlayAudioObject(victoryAnnoucement, transform.position);

        await new WaitForSeconds(delay);

        canvasGroup.DOFade(1.0f, 5.0f)
            .OnComplete(() =>
            {
                textGroup.DOFade(1.0f, 2.0f);
            });

        await new WaitForSeconds(10.0f);

        Application.Quit();
    }
}

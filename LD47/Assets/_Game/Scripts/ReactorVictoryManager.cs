using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Usable))]
public class ReactorVictoryManager : MonoBehaviour
{
    public int totalPieces = 4;

    public UnityEvent onVictory = new UnityEvent();

    public TMPro.TextMeshProUGUI gui = null;

    private void Awake()
    {
        Usable usable = GetComponent<Usable>();

        usable.onMouseDown.AddListener(CheckVictory);
    }

    private void Start()
    {
        gui.text = string.Format("{0}/{1}", 0, totalPieces);
    }

    private void CheckVictory(Usable.OnUsableEventArgs args)
    {
        if (!enabled)
            return;

        InventorySystem ivs = args.Instigator.GetComponentInChildren<InventorySystem>();

        if (ivs == null)
            return;

        InventorySlot slot = ivs.Container.FirstOrDefault(x => x.item.type == ItemType.Piece);
        if (slot != null)
        {
            gui.text = string.Format("{0}/{1}", slot.amount, totalPieces);

            if (slot.amount >= totalPieces)
            {
                onVictory?.Invoke();
                enabled = false;

                args.Instigator.GetComponent<PlayerInput>().enabled = false;
            }
        }
    }
}

using Rewired;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class RewiredPlayer : MonoBehaviour
{
    [SerializeField]
    private int playerIndex = 0;

    public Player Player { get; private set; } = null;

    private void Awake()
    {
        Player = ReInput.players.GetPlayer(playerIndex);
    }
}

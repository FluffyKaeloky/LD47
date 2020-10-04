using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Piece Object", menuName = "Inventory System/Items/Piece")]
public class PieceItem : ItemObject
{
    private void Awake()
    {
        type = ItemType.Piece;
    }
}

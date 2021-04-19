using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Queen Piece Object", menuName = "Puzzle System/Items/Queen")]
public class QueenPieceObject : PuzzleItemObject
{

    public void Awake()
    {
        type = PuzzleItemType.Queen;
        pos = 0;
        Id = 0;
    }

    
}

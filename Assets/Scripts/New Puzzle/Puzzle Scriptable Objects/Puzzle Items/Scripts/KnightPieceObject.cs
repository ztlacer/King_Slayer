using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Knight Piece Object", menuName = "Puzzle System/Items/Knight")]
public class KnightPieceObject : PuzzleItemObject
{

    public void Awake()
    {
        type = PuzzleItemType.Knight;
        pos = 2;
        Id = 2;
    }
}

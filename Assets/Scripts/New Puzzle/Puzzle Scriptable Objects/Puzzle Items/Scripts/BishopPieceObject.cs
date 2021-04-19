using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Bishop Piece Object", menuName = "Puzzle System/Items/Bishop")]
public class BishopPieceObject : PuzzleItemObject
{

    public void Awake()
    {
        type = PuzzleItemType.Bishop;
        pos = 1;
        Id = 1;
    }
}

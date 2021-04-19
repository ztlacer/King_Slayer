using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Brook Piece Object", menuName = "Puzzle System/Items/Brook")]
public class BrookPieceObject : PuzzleItemObject
{

    public void Awake()
    {
        type = PuzzleItemType.Brook;
        pos = 3;
        Id = 3;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GateHandler : MonoBehaviour
{
    public GameObject player;

    public PuzzleObject puzzle;
    public PuzzleItemObject[] items;
    public PuzzleObject[] puzzles;

    public QueenPieceObject queen_0;
    public QueenPieceObject queen_1;
    public QueenPieceObject queen_2;
    public QueenPieceObject queen_3;

    public BishopPieceObject bishop_0;
    public BishopPieceObject bishop_1;
    public BishopPieceObject bishop_2;
    public BishopPieceObject bishop_3;

    public KnightPieceObject knight_0;
    public KnightPieceObject knight_1;
    public KnightPieceObject knight_2;
    public KnightPieceObject knight_3;

    public BrookPieceObject brook_0;
    public BrookPieceObject brook_1;
    public BrookPieceObject brook_2;
    public BrookPieceObject brook_3;

    // Start is called before the first frame update
    void Start()
    {
        //SetUpPuzzle();
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.Space))
       {
            puzzle.Save();
       }
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            puzzle.Load();
        }
    }

    void SetUpPuzzle()
    {
        /* puzzle.AddItem(queen_0);
        puzzle.AddItem(queen_1);
        puzzle.AddItem(queen_2);
        puzzle.AddItem(queen_3);

        puzzle.AddItem(bishop_0);
        puzzle.AddItem(bishop_1);
        puzzle.AddItem(bishop_2);
        puzzle.AddItem(bishop_3);

        puzzle.AddItem(knight_0);
        puzzle.AddItem(knight_1);
        puzzle.AddItem(knight_2);
        puzzle.AddItem(knight_3);

        puzzle.AddItem(brook_0);
        puzzle.AddItem(brook_1);
        puzzle.AddItem(brook_2);
        puzzle.AddItem(brook_3); */
    }

    private void OnApplicationQuit()
    {
        //puzzle.Container.Clear();
        puzzle.Container.Items = new PuzzleSlot[16];
    }
}

//using System.Collections;
//using System.Collections.Generic;
//using Mirror;
//using UnityEngine;

//public class WinUIHandler : NetworkBehaviour
//{
//    [SerializeField] private WinCondition win = null;
//    [SerializeField] private GameObject winUI;

//    private void OnEnable()
//    {
//        win.EventPlayerWin += HandleWin;
//    }

//    private void OnDisable()
//    {
//        win.EventPlayerWin += HandleWin;
//    }

//    [ClientRpc]
//    private void HandleWin(bool winCondition)
//    {
//        print("heee");
//        winUI.SetActive(true);
//    }
//}

using System.Collections;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

public class WinCondition : NetworkBehaviour
{

    [SyncVar(hook = nameof(SetUI))]
    private bool win;

    private void SetUI(bool win, bool newValue)
    {
        print("hello, this worked");
        EndStateManager.instance.initiateEndScreen("Player Won!");
    }

    [Server]
    private void OnTriggerEnter(Collider other)
    {
        print("getTriggeredSoon");
        win = true;
    }
    //[SyncVar]
    //private bool winUI = false;

    //public delegate void playerWon(bool winUI);


    //public event playerWon EventPlayerWin;


    //[Server]
    //private void setWinUI(bool winUI)
    //{
    //    winUI = true;
    //    //winUI.SetActive(true);
    //    EventPlayerWin?.Invoke(winUI);
    //}

    //[Command]
    //private void CmdDoWin() => setWinUI(winUI);


    //[Client]
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (isServer)
    //    {
    //        return;
    //    }
    //    gameObject.GetComponent<NetworkIdentity>().AssignClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
    //    CmdDoWin();
    //    //gameObject.GetComponent<NetworkIdentity>().RemoveClientAuthority(this.GetComponent<NetworkIdentity>().connectionToClient);
    //}
}

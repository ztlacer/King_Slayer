using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class NetworkGamePlayerChess : NetworkBehaviour
{
    [SyncVar]
    private string displayName = "Loading...";

    private NetManager room;
    private NetManager Room
    {
        get
        {
            if(room != null) { return room; }
            return room = NetworkManager.singleton as NetManager;
        }
    }

    public override void OnStartClient()
    {
        DontDestroyOnLoad(gameObject);
        Room.GamePlayers.Add(this);
    }

    public override void OnStopClient()
    {
        Room.GamePlayers.Remove(this);
    }

    [Server]
    public void SetDisplayName(string displayName)
    {
        this.displayName = displayName;
    }
}

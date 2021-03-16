
using Mirror;
using System.Linq;
using UnityEngine;

    public class RoundSystem : NetworkBehaviour
    {
        [SerializeField] private Animator animator = null;

        private NetManager room;
        private NetManager Room
        {
            get
            {
                if (room != null) { return room; }
                return room = NetworkManager.singleton as NetManager;
            }
        }

        public void CountdownEnded()
        {
            animator.enabled = false;
        }

        #region Server

        public override void OnStartServer()
        {
            NetManager.OnServerStopped += CleanUpServer;
            NetManager.OnServerReadied += CheckToStartRound;
        }

        [ServerCallback]
        private void OnDestroy() => CleanUpServer();

        [Server]
        private void CleanUpServer()
        {
            NetManager.OnServerStopped -= CleanUpServer;
            NetManager.OnServerReadied -= CheckToStartRound;
        }

        [ServerCallback]
        public void StartRound()
        {
            RpcStartRound();
        }

        [Server]
        private void CheckToStartRound(NetworkConnection conn)
        {
            if (Room.GamePlayers.Count(x => x.connectionToClient.isReady) != Room.GamePlayers.Count) { return; }

            animator.enabled = true;

            RpcStartCountdown();
        }

        #endregion

        #region Client

        [ClientRpc]
        private void RpcStartCountdown()
        {
           // animator.enabled = true;
        }

        [ClientRpc]
        private void RpcStartRound()
        {
          //  InputManager.Remove(ActionMapNames.Player);
        }

        #endregion
    }

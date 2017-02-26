// Player/SyncedData/LocalPlayerDataManager.cs

using UnityEngine;
using UnityEngine.Networking;

namespace Player.SyncedData {
    public class LocalPlayerDataManager : NetworkBehaviour {

        public PlayerDataForClients clientData;

        private string[] names = new string[] { "Adam", "Betty", "Charles", "Deborah", "Eddy", "Francis", "Gerald", "Holly" };
        private int[] teams = new int[] { PlayerDataForClients.TEAM_VIP, PlayerDataForClients.TEAM_INHUMER };

        public override void OnStartLocalPlayer()
        {
            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();
            if (store.playerColour == new Color(0, 0, 0, 0)) {
                store.playerColour = Random.ColorHSV();
            }
            if (store.playerName == "") {
                store.playerName = names[Random.Range(0, 8)];
            }
            if (store.team == 0) {
                store.team = teams[Random.Range(0, 2)];
            }
            if (isServer) {
                store.isServer = isServer;
            }

            clientData.SetColour(store.playerColour);
            clientData.OnColourUpdated += OnPlayerColourUpdated;

            clientData.SetName(store.playerName);
            clientData.OnNameUpdated += OnNameUpdated;
            
            clientData.SetTeam(store.team);
            clientData.OnTeamUpdated += OnTeamUpdated;

            clientData.SetIsReadyFlag(store.isReady);
            clientData.OnIsReadyFlagUpdated += OnIsReadyFlagUpdated;

            clientData.SetIsServerFlag(store.isServer);
            clientData.OnIsServerFlagUpdated += OnIsServerFlagUpdated;
        }

        public void OnPlayerColourUpdated(GameObject player, Color newColour)
        {
            LocalPlayerDataStore.GetInstance().playerColour = newColour;
        }

        public void OnNameUpdated(GameObject player, string newName)
        {
            LocalPlayerDataStore.GetInstance().playerName = newName;
        }

        public void OnTeamUpdated(GameObject player, int newTeam)
        {
            LocalPlayerDataStore.GetInstance().team = newTeam;
        }

        public void OnIsReadyFlagUpdated(GameObject player, bool isReady)
        {
            LocalPlayerDataStore.GetInstance().isReady = isReady;
        }

        public void OnIsServerFlagUpdated (GameObject player, bool isServer)
        {
            LocalPlayerDataStore.GetInstance().isServer = isServer;
        }
    }
}
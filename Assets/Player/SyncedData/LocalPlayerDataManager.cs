﻿// Player/SyncedData/LocalPlayerDataManager.cs

using GameState;
using UnityEngine;
using UnityEngine.Networking;

namespace Player.SyncedData {
    public class LocalPlayerDataManager : NetworkBehaviour {

        public PlayerDataForClients clientData;

        private string[] names = new string[] { "Adam", "Betty", "Charles", "Deborah", "Eddy", "Francis", "Gerald", "Holly" };
        private int[] teams = new int[] { PlayerDataForClients.TEAM_VIP, PlayerDataForClients.TEAM_INHUMER };

        public override void OnStartLocalPlayer()
        {
            CreateDefaultValues();
            State.GetInstance().Subscribe(
                new StateOption()
                    .GameState(State.GAME_OFFLINE), 
                ResetValues
            );

            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();
            clientData.SetName(store.playerName);
            clientData.SetTeam(store.team);
            clientData.SetIsReadyFlag(store.isReady);
            clientData.SetIsServerFlag(store.isServer);

            clientData.OnNameUpdated += OnNameUpdated;
            clientData.OnTeamUpdated += OnTeamUpdated;
            clientData.OnIsReadyFlagUpdated += OnIsReadyFlagUpdated;
            clientData.OnIsServerFlagUpdated += OnIsServerFlagUpdated;
        }

        private void CreateDefaultValues ()
        {
            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();
            if (store.playerName != "" || store.team != 0 | store.isServer != false || store.isReady != false) {
                return;
            }

            store.playerName = names[Random.Range(0, 8)];
            store.team = teams[Random.Range(0, 2)];

            if (State.GetInstance().Network() == State.NETWORK_SERVER) {
                store.isServer = true;
            }
        }

        private void ResetValues ()
        {
            LocalPlayerDataStore store = LocalPlayerDataStore.GetInstance();
            store.playerName = "";
            store.team = 0;
            store.isServer = false;
            store.isReady = false;
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
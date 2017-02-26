// UI/Lobby/Player/RemoteEntryUI.cs

using Player.SyncedData;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Lobby.Player
{
    public class RemoteEntryUI : MonoBehaviour, EntryInterface
    {
        public GameObject isReadyBackground;
        public GameObject isServerBackground;
        public Text nameText;
        public Text teamText;

        private PlayerDataForClients settings;

        public void SetPlayerObject(GameObject player)
        {
            settings = player.GetComponent<PlayerDataForClients>();

            // force a change when setup so we have initial settings
            OnNameUpdateFromSettings(player, settings.GetName());
            OnTeamUpdateFromSettings(player, settings.GetTeam());
            OnServerUpdateFromSettings(player, settings.GetIsServerFlag());

            // set up events so when client player settings change, hud updates
            settings.OnNameUpdated += OnNameUpdateFromSettings;
            settings.OnTeamUpdated += OnTeamUpdateFromSettings;
            settings.OnIsReadyFlagUpdated += OnReadyUpdateFromSettings;
            settings.OnIsServerFlagUpdated += OnServerUpdateFromSettings;
        }

        // used when PlayerDataForClients changes name
        public void OnNameUpdateFromSettings(GameObject player, string name)
        {
            nameText.text = name;
        }

        // used when PlayerDataForClients changes team
        public void OnTeamUpdateFromSettings(GameObject player, int teamId)
        {
            if (teamId == PlayerDataForClients.TEAM_VIP) {
                teamText.text = "VIP";
            }

            if (teamId == PlayerDataForClients.TEAM_INHUMER) {
                teamText.text = "Inhumer";
            }
        }

        public void OnReadyUpdateFromSettings(GameObject player, bool isReady)
        {
            isReadyBackground.SetActive(isReady);
        }

        public void OnServerUpdateFromSettings(GameObject player, bool isServer)
        {
            isServerBackground.SetActive(isServer);
        }
    }
}

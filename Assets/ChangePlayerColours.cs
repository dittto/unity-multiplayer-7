// ChangePlayerColours.cs

using Player.SyncedData;
using Player.Tracking;
using UnityEngine;

class ChangePlayerColours:MonoBehaviour {

    public void Start ()
    {
        foreach (GameObject player in PlayerTracker.GetInstance().GetPlayers()) {
            AddColourChangeEvent(player);
        }
        PlayerTracker.GetInstance().OnPlayerAdded += AddColourChangeEvent;
    }

    public void AddColourChangeEvent (GameObject player)
    {
        PlayerDataForClients playerData = player.GetComponent<PlayerDataForClients>();
        HandlePlayerColourChange(player, playerData.GetTeam());
        playerData.OnTeamUpdated += HandlePlayerColourChange;
    }

    public void HandlePlayerColourChange (GameObject player, int newTeam)
    {
        player.GetComponentInChildren<MeshRenderer>().material.color = newTeam == PlayerDataForClients.TEAM_VIP ? Color.red : Color.blue;
    }
}


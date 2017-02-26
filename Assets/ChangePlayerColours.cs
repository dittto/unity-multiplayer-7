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
        HandlePlayerColourChange(player, playerData.GetColour());
        playerData.OnColourUpdated += HandlePlayerColourChange;
    }

    public void HandlePlayerColourChange (GameObject player, Color newColour)
    {
        player.GetComponentInChildren<MeshRenderer>().material.color = newColour;
    }
}


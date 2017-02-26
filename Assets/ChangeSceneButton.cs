// ChangeSceneButton.cs

using Modal;
using UnityEngine.Networking;

public class ChangeSceneButton : NetworkBehaviour {

    private string storedSceneName;

    [Server]
    public void ChangeScene (string sceneName)
    {
        ModalManager.GetInstance().Show(
            "Ready to load scene '" + sceneName + "'",
            "Do it",
            "Not yet",
            () => {
                NetworkManager.singleton.ServerChangeScene(sceneName);
            },
            () => {
                ModalManager.GetInstance().Hide();
            }
        );
    }
}
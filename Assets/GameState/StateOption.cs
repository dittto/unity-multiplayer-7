// GameState/StateOption.cs

namespace GameState
{
    public struct StateOption
    {
        public string oldNetwork;
        public string newNetwork;
        public string oldGame;
        public string newGame;

        public StateOption(
            string oldNetworkState = "",
            string oldGameState = "",
            string newNetworkState = "",
            string newGameState = ""
        )
        {
            oldNetwork = oldNetworkState;
            newNetwork = newNetworkState;
            oldGame = oldGameState;
            newGame = newGameState;
        }

        public StateOption PreviousNetworkState (string oldNetworkState)
        {
            oldNetwork = oldNetworkState;

            return this;
        }

        public StateOption PreviousGameState (string oldGameState)
        {
            oldGame = oldGameState;

            return this;
        }

        public StateOption NetworkState (string newNetworkState)
        {
            newNetwork = newNetworkState;

            return this;
        }

        public StateOption GameState (string newGameState)
        {
            newGame = newGameState;

            return this;
        }

        public bool Matches(
            string oldNetworkState,
            string oldGameState,
            string newNetworkState,
            string newGameState,
            bool isNetworkDirty,
            bool isGameDirty
            )
        {
            if (oldNetwork != null && oldNetwork != "" && oldNetworkState != "" && oldNetwork != oldNetworkState) {
                return false;
            }

            if (newNetwork != null && newNetwork != "" && newNetworkState != "" && newNetwork != newNetworkState) {
                return false;
            }

            if (oldGame != null && oldGame != "" && oldGameState != "" && oldGame != oldGameState) {
                return false;
            }

            if (newGame != null && newGame != "" && newGameState != "" && newGame != newGameState) {
                return false;
            }

            bool anyDirty = false;
            if (((oldNetwork != null && oldNetwork != "") || (newNetwork != null && newNetwork != "")) && isNetworkDirty) {
                anyDirty = true;
            }
            if (((oldGame != null && oldGame != "") || (newGame != null && newGame != "")) && isGameDirty) {
                anyDirty = true;
            }
            if (!anyDirty) {
                return false;
            }

            return true;
        }
    }
}

// GameState/StateOption.cs

namespace GameState
{
    public struct StateOption
    {
        public string oldNetwork;
        public string oldGame;
        public string newNetwork;
        public string newGame;

        public StateOption (string oldNetworkState = "", string oldGameState = "", string newNetworkState = "", string newGameState = "")
        {
            oldNetwork = oldNetworkState;
            oldGame = oldGameState;
            newNetwork = newNetworkState;
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

        public bool Matches (string oldNetworkState, string oldGameState, string newNetworkState, string newGameState)
        {
            if (oldNetwork != null && oldNetwork != "" && oldNetworkState != "" && oldNetwork != oldNetworkState) {
                return false;
            }

            if (oldGame != null && oldGame != "" && oldGameState != "" && oldGame != oldGameState) {
                return false;
            }

            if (newNetwork != null && newNetwork != "" && newNetworkState != "" && newNetwork != newNetworkState) {
                return false;
            }

            if (newGame != null && newGame != "" && newGameState != "" && newGame != newGameState) {
                return false;
            }

            return true;
        }
    }
}

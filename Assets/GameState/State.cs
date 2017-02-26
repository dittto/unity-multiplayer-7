// GameState/State.cs

using System.Collections.Generic;
using UnityEngine;

namespace GameState
{
    public struct SubscriberOptions
    {
        public StateOption option;
        public State.Subscriber subscriber;
    }

    public class State
    {
        public const string NETWORK_CLIENT = "network_client";
        public const string NETWORK_SERVER = "network_server";

        public const string GAME_OFFLINE = "game_offline";
        public const string GAME_CONNECTING = "game_connecting";
        public const string GAME_ONLINE = "game_online";
        public const string GAME_DISCONNECTING = "game_disconnecting";

        public delegate void Subscriber ();
        private List<SubscriberOptions> subscribers = new List<SubscriberOptions>();

        private static State instance;

        private string networkState;
        private string gameState;
        private string previousNetworkState;
        private string previousGameState;

        private State () { }

        public static State GetInstance ()
        {
            if (instance == null) {
                instance = new State();
            }

            return instance;
        }

        public State Network (string newNetworkState)
        {
            previousNetworkState = networkState;
            networkState = newNetworkState;

            return this;
        }

        public string Network ()
        {
            return networkState;
        }

        public State Game (string newGameState)
        {
            previousGameState = gameState;
            gameState = newGameState;

            return this;
        }

        public string Game ()
        {
            return gameState;
        }

        public void Subscribe (StateOption options, Subscriber callback)
        {
            SubscriberOptions subscriberOption = new SubscriberOptions();
            subscriberOption.option = options;
            subscriberOption.subscriber = callback;

            if (!subscribers.Contains(subscriberOption)) {
                subscribers.Add(subscriberOption);
            }
            PublishIfMatches(subscriberOption);
        }

        public void Publish ()
        {
            // Debug.Log("State: " + networkState + " | " + previousGameState + " > " + gameState);

            foreach (SubscriberOptions subscriberOption in subscribers) {
                PublishIfMatches(subscriberOption);
            }
        }

        private void PublishIfMatches (SubscriberOptions subscriberOption)
        {
            if (subscriberOption.option.Matches(previousNetworkState, previousGameState, networkState, gameState)) {
                subscriberOption.subscriber();
            }
        }
    }
}

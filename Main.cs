using ModLoader;
using System.Collections.Generic;
using UnityEngine;

namespace CustomAssetsReadyAPI
{
    /// <summary>
    /// API mod that signals when CustomAssetsLoader.finishedLoading is true.
    /// Other mods can subscribe to CustomAssetsReadyAPI.OnCustomAssetsReady.
    /// </summary>
    public class Main : Mod
    {
        public static Main Instance { get; private set; }

        public Main()
        {
            Instance = this;
        }

        public override string ModNameID => "customassetsreadyapi";
        public override string DisplayName => "CustomAssetsReadyAPI";
        public override string Author => "Koja Mori";
        public override string Description => "Signals when CustomAssetsLoader.finishedLoading is true. Other mods can listen for the event.";
        public override string ModVersion => "2.0.0";
        public override string MinimumGameVersionNecessary => "1.6.00.0";
        public override Dictionary<string, string> Dependencies => null;

        public override void Early_Load()
        {
            Debug.Log($"[{DisplayName}] Waiting for custom assets to be loaded...");

            CustomAssetsReady.OnCustomAssetsReady += () =>
            {
                Debug.Log($"[{DisplayName}] Custom assets are ready!");
            };

            CustomAssetsReady.WaitForCustomAssetsAsync();
        }

        public override void Load()
        {
            // ...
        }
    }
}
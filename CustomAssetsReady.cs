using System;
using SFS.Parts;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace CustomAssetsReadyAPI
{
    public static class CustomAssetsReady
    {
        internal static async UniTaskVoid WaitForCustomAssetsAsync()
        {
            while (!CustomAssetsLoader.finishedLoading)
                await UniTask.Yield();

            OnCustomAssetsReady?.Invoke();
        }

        /// <summary>
        /// Event fired when CustomAssetsLoader.finishedLoading is true.
        /// </summary>
        public static event Action OnCustomAssetsReady;
    }
}

using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using Cysharp.Threading.Tasks;

namespace Controllers
{
    partial class SaveSystemController
    {
        private const string LogTag = nameof(SaveSystemController);
        private static readonly ILogger Logger = Debug.unityLogger;

        private bool _isReady;

        private async UniTask ProcessAsync(Func<UniTask> task, [CallerMemberName] string callerName = "")
        {
            SetProcessStatus(callerName);
            await task();
            SetReadyStatus();
        }

        private void SetProcessStatus(string processName)
        {
            _isReady = false;
            Logger.Log(LogTag);
        }

        private void SetReadyStatus()
        {
            _isReady = true;
            Logger.Log(LogTag);
        }
    }
}

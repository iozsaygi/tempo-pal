using System;
using UnityEngine;

namespace AAA.Source.Debugger.Runtime
{
    public class Debugger
    {
        public static void Log(string message = null, string tag = null, LogCategory logCategory = LogCategory.Trace)
        {
            Debug.Assert(!string.IsNullOrEmpty(message));
            Debug.Assert(!string.IsNullOrEmpty(tag));

            var reformattedTag = string.Concat('[', tag, ']');
            var reformattedMessage = string.Concat(reformattedTag, ' ', message);

            switch (logCategory)
            {
                case LogCategory.Error:
                    Debug.LogError($"<color=red>{reformattedMessage}</color>");
                    break;
                case LogCategory.Trace:
                    Debug.Log($"<color=white>{reformattedMessage}</color>");
                    break;
                case LogCategory.Warning:
                    Debug.LogWarning($"<color=yellow>{reformattedMessage}</color>");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logCategory), logCategory, null);
            }
        }
    }
}
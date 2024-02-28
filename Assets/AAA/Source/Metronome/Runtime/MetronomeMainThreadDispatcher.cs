using System;
using System.Collections.Concurrent;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace AAA.Source.Metronome.Runtime
{
    // TODO: Check to see if we can implement custom 'ApplicationComponent' class for this and related stuff.
    [DisallowMultipleComponent]
    public class MetronomeMainThreadDispatcher : MonoBehaviour
    {
        private readonly ConcurrentQueue<Action> clicks = new();

        public void QueueClickOnMainThread(Action action)
        {
            clicks.Enqueue(action);
        }

        private void Update()
        {
            if (clicks.IsEmpty) return;

            clicks.TryDequeue(out var queuedClickAction);
            queuedClickAction.Invoke();
        }
    }
}
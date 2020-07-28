using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UbisoftPresentation
{
    public static class TaskExtensions
    {
        public static readonly Action<Task> _handleFinishedTask = HandleFinishedTask;

        internal static void HandleExceptions(this Task task)
        {
            task.ContinueWith(_handleFinishedTask);
        }

        public static void HandleFinishedTask(Task task)
        {
            if (task.IsFaulted)
                Debug.LogException(task.Exception);
        }
    }
}
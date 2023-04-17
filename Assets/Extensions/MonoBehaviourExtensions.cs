using System;
using System.Collections;
using UnityEngine;

namespace Extensions
{
    public static class MonoBehaviourExtensions
    {
        /// <summary>
        /// Invoke Action with delay (use coroutine).
        /// </summary>
        public static Coroutine InvokeWithDelay(this MonoBehaviour behaviour, Action action, in float delay)
        {
            return behaviour.StartCoroutine(InvokeWithDelayRoutine(action, delay));
        }

        private static IEnumerator InvokeWithDelayRoutine(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }

        public static Coroutine FillProgress(this MonoBehaviour behaviour, 
            float startValue, float endValue, float duration, 
            Action<float> action) =>
            behaviour.StartCoroutine(FillProgressRoutine(startValue, endValue, duration, action));

        private static IEnumerator FillProgressRoutine(float startValue, float endValue, float duration, Action<float> action)
        {
            float currentTime = 0;
            float difference = endValue - startValue;
            action?.Invoke(0);
            yield return null;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                action?.Invoke(startValue + (difference * currentTime / duration));
                yield return null;
            }
            action?.Invoke(1);
        }
    }
}
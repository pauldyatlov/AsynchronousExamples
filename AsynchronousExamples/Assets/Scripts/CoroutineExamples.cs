using System.Collections;
using UnityEngine;

namespace UbisoftPresentation
{
    public class CoroutineExamples : MonoBehaviour
    {
        private Coroutine _coroutine;

        private void Awake()
        {
            _coroutine = StartCoroutine(Co_Wait());
        }

        private IEnumerator Co_Wait()
        {
            //Happens after the Update
            yield return null;

            //Wait until the predicate is true
            yield return new WaitUntil(() => true);

            //Wait while the predicate is true
            yield return new WaitWhile(() => false);

            //Wait for scaled time
            yield return new WaitForSeconds(1);

            //Wait for Fixed Update to perform
            yield return new WaitForFixedUpdate();

            //Wait for unscaled time
            yield return new WaitForSecondsRealtime(2);

            //Wait until the end of frame reached
            yield return new WaitForEndOfFrame();
        }

        private IEnumerator Co_WaitForEndOfFrame()
        {
            yield return new WaitForEndOfFrame();

            Debug.Log("End of frame reached");
        }

        private void Stop()
        {
            if (_coroutine == null)
                return;

            StopCoroutine(_coroutine);
        }
    }
}
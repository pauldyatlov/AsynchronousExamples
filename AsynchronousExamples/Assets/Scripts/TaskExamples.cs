using System;
using System.Threading.Tasks;
using UnityEngine;

namespace UbisoftPresentation
{
    public class WaitUntil : CustomYieldInstruction
    {
        private Func<bool> _predicate;

        public override bool keepWaiting => _predicate() == false;

        public WaitUntil(Func<bool> predicate)
        {
            _predicate = predicate;
        }
    }

    public class TaskExamples
    {
        private void Start()
        {
            SomeAction().HandleExceptions();
        }

        private async Task SomeAction()
        {
            //Wait until the predicate is true
            await new WaitUntil(() => true);

            //Wait while the predicate is true
            await new WaitWhile(() => false);

            //Wait for scaled time
            await new WaitForSeconds(1);

            //Wait for Fixed Update to perform
            await new WaitForFixedUpdate();

            //Wait for unscaled time
            await new WaitForSecondsRealtime(2);

            //Wait until the end of frame reached
            await new WaitForEndOfFrame();
        }

        private async Task SomeActionOne()
        {
            await Task.Delay(1);
        }
    }
}
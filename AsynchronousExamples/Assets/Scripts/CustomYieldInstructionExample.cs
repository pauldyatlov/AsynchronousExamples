using System.Collections;
using UnityEngine;

namespace UbisoftPresentation
{
    public class CustomYieldInstructionExample : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetMouseButtonUp(0) == false)
                return;

            Debug.Log("Left mouse button up");

            StartCoroutine(WaitForMouseDown());
        }

        private IEnumerator WaitForMouseDown()
        {
            yield return new WaitForMouseDown();
            Debug.Log("Right mouse button pressed");
        }
    }

    public class WaitForMouseDown : CustomYieldInstruction
    {
        public override bool keepWaiting => Input.GetMouseButtonDown(1) == false;

        public WaitForMouseDown()
        {
            Debug.Log("Waiting for Mouse right button down");
        }
    }
}
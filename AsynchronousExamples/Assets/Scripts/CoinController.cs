using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace UbisoftPresentation
{
    public class CoinController : MonoBehaviour
    {
        [SerializeField] private List<Coin> _coins = new List<Coin>();

        private NativeArray<Coin> _nativeArray;
        private UpdateCoinJob _job;

        private void Awake()
        {
            _nativeArray = new NativeArray<Coin>(_coins.Count, Allocator.TempJob);

            for (var i = 0; i < _coins.Count; i++)
                _nativeArray[i] = new Coin(0);
        }

        private void Update()
        {
            _job = new UpdateCoinJob
            {
                DataArray = _nativeArray,
            };

            var jobHandle = _job.Schedule(_coins.Count, 1);
            jobHandle.Complete();
        }

        private void OnDestroy()
        {
            _nativeArray.Dispose();
        }
    }
}
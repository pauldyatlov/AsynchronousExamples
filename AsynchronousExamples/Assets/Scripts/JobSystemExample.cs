using System;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

namespace UbisoftPresentation
{
    public struct UpdateCoinJob : IJobParallelFor
    {
        public NativeArray<Coin> DataArray;

        public void Execute(int index)
        {
            var data = DataArray[index];
            data.Refresh();

            DataArray[index] = data;
        }
    }

    [Serializable]
    public struct Coin
    {
        public float Value;

        public Coin(float value)
        {
            Value = value;
        }

        public void Refresh()
        {
            Debug.Log(GetHashCode() + ", value: " + Value);

            Value += 1;
        }
    }
}
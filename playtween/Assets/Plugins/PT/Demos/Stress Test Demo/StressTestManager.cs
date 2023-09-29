using System;
using UnityEngine;

namespace PT.Stress_Test_Demo
{
    public class StressTestManager : MonoBehaviour
    {
        private StressTestObject[] _objects;

        private void Start()
        {
            _objects = GetComponentsInChildren<StressTestObject>();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (var stressTestObject in _objects)
                {
                    stressTestObject.Play();
                }
            }
        }
    }
}
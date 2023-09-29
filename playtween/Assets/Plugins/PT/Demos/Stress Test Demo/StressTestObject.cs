using UnityEngine;

namespace PT.Stress_Test_Demo
{
    public class StressTestObject : MonoBehaviour
    {
        public void Play()
        {
            transform.PlayMove(Vector3.right, 1).SetEase(EaseType.OutBack);
        }
    }
}
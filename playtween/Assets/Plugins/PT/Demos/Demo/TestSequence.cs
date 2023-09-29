using System;
using UnityEngine;

namespace PT.Demo
{
    public class TestSequence : MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                //var sequence = PlayTween.GetSequence();
                //sequence
                //    .AddTweenAt(transform.PlayMoveX(2,1),.5f)
                //    .AddTweenAt(transform.PlayMoveY(2,1),1f)
                //    .AddTweenAt(transform.PlayScale(Vector3.one * 2, 1),1.5f);
                //
                //sequence.OnComplete(() =>
                //{
                //    Debug.Log("Completed");
                //});
                //
                //sequence
                //    .AppendTween(transform.PlayMoveX(2,1))
                //    .AppendTween(transform.PlayMoveY(2,1))
                //    .AddTweenAt(transform.PlayScale(Vector3.one * 2, 1),.5f);
            }
            
        }
    }
}
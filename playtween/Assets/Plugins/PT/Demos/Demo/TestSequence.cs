using System;
using UnityEngine;

namespace PT.Demo
{
    public class TestSequence : MonoBehaviour
    {
        private Sequence _sequence;
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _sequence = PlayTween.GetSequence();
                _sequence.Append(transform.PlayMove(Vector3.right, .5f).SetFrom(Vector3.zero));
                _sequence.Join(transform.PlayScale(Vector3.one * 2, .5f).SetFrom(Vector3.one));
                _sequence.Append(GetComponentInChildren<SpriteRenderer>().PlayColor(Color.red, .5f)
                    .SetFrom(Color.white));
                _sequence.SetDelay(.5f);
                _sequence.OnComplete(() => { Debug.Log("Complete"); });
                _sequence.OnStart(() => { Debug.Log("Start"); });
            }

        }
    }
}
using UnityEngine;

namespace PT.Demo
{
    public class TestPlayTween : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;
        [SerializeField] private float duration = .5f;
        [SerializeField] private EaseType ease = EaseType.OutBack;
        [SerializeField] private EaseData easeData;

        private ITween _tween;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayTween.KillAll();
                
                _tween = PlayTween.NewTween(
                    duration: duration,
                    to: Vector3.right,
                    getter: () => Vector3.zero, 
                    updater: (value, tween) =>
                    {
                        transform.position = value;
                    },
                    target: transform)
                    .SetDelay(0)
                    .SetFromAtStart()
                    .SetEase(easeData)
                    .SetDelay(.5f)
                    .SetTimeIndependent()
                    .SetPlayDirection(PlayDirection.Backward)
                    .SetLoop(2,LoopType.YoYo)
                    .OnComplete(() =>
                    {
                        Debug.Log("Complete");
                    })
                    .OnStart(() =>
                    {
                        Debug.Log("Start");
                    });
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                if (_tween.IsPaused)
                {
                    _tween.Play();
                }
                else
                {
                    _tween.Pause();
                }
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                _tween.Restart();
            }
        }
    }
}
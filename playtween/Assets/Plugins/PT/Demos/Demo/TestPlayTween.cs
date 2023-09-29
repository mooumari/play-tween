using UnityEngine;

namespace PT.Demo
{
    public class TestPlayTween : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;
        [SerializeField] private float duration = .5f;
        [SerializeField] private EaseType ease = EaseType.OutBack;
        [SerializeField] private EaseData easeData;


        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //transform.PlayRotateQuaternion(Quaternion.Euler(0, 0, 45), .5f)
                //    .SetDirection(PlayDirection.Backward);
                //transform.PlayMove(Vector3.zero, Vector3.up, 1).SetLoop(5,LoopType.YoYo);
                //transform.PlayRotate(new Vector3(0, 0, 45), 1).SetLoop(5,LoopType.YoYo);
                PlayTween.Kill(transform);
                
                //transform.PlayRotateQuaternion(Quaternion.Euler(0, 0, 0), Quaternion.Euler(0, 0, 45), 1)
                //    .SetLoop(5, LoopType.YoYo);

                //transform.PlayMove(Vector3.up * 2, Vector3.up, .5f)
                //    .After(transform.PlayMove(Vector3.up, Vector3.right, .5f));

                //transform.PlayPunchScale(Vector3.one, .2f).SetEase(EaseType.InOutSine);
                //transform.PlayPunchRotation(Vector3.one * 15, .5f).SetEase(easeData);

                //transform.PlayMove(Vector3.right * 2, .5f).SetFrom(Vector3.zero).SetEase(easeData);

                //TweenVector3.New(.5f, Vector3.zero, Vector3.right,
                //    (value, tween) =>
                //    {
                //        transform.position = value;
                //    },
                //    transform).SetEase(easeData).SetDelay(.5f).SetIndependentDeltaTime();

                //transform.PlayMove(Vector3.zero, Vector3.right, .5f).SetEase(easeData).SetIndependentDeltaTime();

                transform.PlayMoveX(2, .5f).ThenPlay(transform.PlayMoveX(-2,.5f));
                
                
                //    .After(transform.PlayMove(Vector3.up * 2, Vector3.up, .25f))
                //    .After(transform.PlayScale(Vector3.one, Vector3.one * 2f, .5f).SetEase(EaseType.OutBack));

                //GetComponentInChildren<SpriteRenderer>().PlayGradient(gradient, 1).SetDirection(PlayDirection.Backward);
            }
        }
    }
}
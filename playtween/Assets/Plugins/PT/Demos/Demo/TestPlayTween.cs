using UnityEngine;

namespace PT.Demo
{
    public class TestPlayTween : MonoBehaviour
    {
        [SerializeField] private Gradient gradient;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                PlayTween.KillAll();
                transform.PlayJump(Vector3.up, .5f).SetFrom(Vector3.zero).SetEase(EaseType.InSine);
                GetComponentInChildren<SpriteRenderer>().PlayGradient(gradient, 1).SetLoop(5,LoopType.YoYo);
            }
        }
    }
}
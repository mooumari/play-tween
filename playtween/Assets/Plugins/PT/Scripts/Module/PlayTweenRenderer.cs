using UnityEngine;

namespace PT
{
    public static class PlayTweenRenderer
    {
        //------------------ Play Color -----------------------
        public static TweenColor PlayColor(this SpriteRenderer target, Color to, float duration)
        {
            return TweenColor.New(duration,
                to,
                () => target.color,
                (value, tween) =>
                {
                    target.color = value;
                },target);
        }
        
        //------------------ Play Gradient -----------------------
        public static TweenGradient PlayGradient(this SpriteRenderer target, Gradient gradient, float duration)
        {
            return TweenGradient.New(duration,
                gradient,
                () => target.color,
                (value, tween) =>
                {
                    target.color = value;
                },target);
        }
    }
}
using UnityEngine;

namespace PT
{
    public class TweenGradient : Tween<Color>
    {
        private readonly Gradient _gradient;
        public TweenGradient(float duration, Gradient gradient, TweenGetter<Color> getter, TweenUpdater<Color, ITween> updater, Object target = null) : base(duration, gradient.Evaluate(1), getter, updater, target)
        {
            _gradient = gradient;
        }

        protected override Color GetValue(float normalTime)
        {
            return _gradient.Evaluate(GetEaseNormalTime(normalTime));
        }

        public static TweenGradient New(float duration, Gradient gradient, TweenGetter<Color> getter, TweenUpdater<Color, ITween> updater, Object target = null)
        {
            return new TweenGradient(duration, gradient, getter, updater, target);
        }
    }
}
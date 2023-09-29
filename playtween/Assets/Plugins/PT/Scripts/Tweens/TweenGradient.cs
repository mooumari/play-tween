using UnityEngine;

namespace PT
{
    public class TweenGradient : Tween<Color>
    {
        private readonly Gradient _gradient;
        


        protected override void OnUpdate(float normalTime)
        {
            Updater.Invoke(GetValue(normalTime),this);
        }

        protected override Color GetValue(float normalTime)
        {
            return _gradient.Evaluate(GetEaseNormalTime(normalTime));
        }

        public TweenGradient(float duration, Gradient gradient, TweenUpdater<Color, ITween> updater, TweenGetter<Color> getter, Object target = null) : base(duration, gradient.Evaluate(0), gradient.Evaluate(1), updater, getter, target)
        {
            _gradient = gradient;
        }
    }
}
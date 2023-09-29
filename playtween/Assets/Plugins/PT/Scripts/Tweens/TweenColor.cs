using UnityEngine;

namespace PT
{
    public class TweenColor : Tween<Color>
    {

        protected override void OnUpdate(float normalTime)
        {
            Updater.Invoke(GetValue(normalTime),this);
        }

        protected override Color GetValue(float normalTime)
        {
            return Color.LerpUnclamped(From, To, GetEaseNormalTime(normalTime));
        }

        public TweenColor(float duration, Color from, Color to, TweenUpdater<Color, ITween> updater, TweenGetter<Color> getter, Object target = null) : base(duration, from, to, updater, getter, target)
        {
        }
    }
}
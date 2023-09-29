using UnityEngine;

namespace PT
{
    public class TweenColor : Tween<Color>
    {
        public TweenColor(float duration, Color to, TweenGetter<Color> getter, TweenUpdater<Color, ITween> updater, Object target = null) : base(duration, to, getter, updater, target)
        {
        }

        protected override Color GetValue(float normalTime)
        {
            return Color.LerpUnclamped(From, To, GetEaseNormalTime(normalTime));
        }

        public static TweenColor New(float duration, Color to, TweenGetter<Color> getter, TweenUpdater<Color, ITween> updater, Object target = null)
        {
            return new TweenColor(duration, to, getter, updater, target);
        }
        
    }
}
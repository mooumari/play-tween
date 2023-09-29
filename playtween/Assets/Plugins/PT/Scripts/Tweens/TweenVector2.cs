using UnityEngine;

namespace PT
{
    public class TweenVector2 : Tween<Vector2>
    {
        public TweenVector2(float duration, Vector2 to, TweenGetter<Vector2> getter, TweenUpdater<Vector2, ITween> updater, Object target = null) : base(duration, to, getter, updater, target)
        {
        }

        protected override Vector2 GetValue(float normalTime)
        {
            return Vector2.LerpUnclamped(From, To, GetEaseNormalTime(normalTime));
        }

        public static TweenVector2 New(float duration, Vector2 to, TweenGetter<Vector2> getter, TweenUpdater<Vector2, ITween> updater, Object target = null)
        {
            return new TweenVector2(duration, to, getter, updater, target);
        }
    }
}
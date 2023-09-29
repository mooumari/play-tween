using UnityEngine;

namespace PT
{
    public class TweenVector2 : Tween<Vector2>
    {


        protected override void OnUpdate(float normalTime)
        {
            Updater.Invoke(GetValue(normalTime),this);
        }

        protected override Vector2 GetValue(float normalTime)
        {
            return Vector2.LerpUnclamped(From, To, GetEaseNormalTime(normalTime));
        }

        public TweenVector2(float duration, Vector2 from, Vector2 to, TweenUpdater<Vector2, ITween> updater, TweenGetter<Vector2> getter, Object target = null) : base(duration, from, to, updater, getter, target)
        {
        }
    }
}
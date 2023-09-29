using UnityEngine;

namespace PT
{
    public class TweenFloat : Tween<float>
    {
        public TweenFloat(float duration, float to, TweenGetter<float> getter, TweenUpdater<float, ITween> updater, Object target = null) : base(duration, to, getter, updater, target)
        {
        }

        protected override float GetValue(float normalTime)
        {
            return Mathf.LerpUnclamped(From, To, GetEaseNormalTime(normalTime));
        }

        public static TweenFloat New(float duration, float to, TweenGetter<float> getter, TweenUpdater<float, ITween> updater, Object target = null)
        {
            return new TweenFloat(duration,to,getter,updater,target);
        }
    }
}
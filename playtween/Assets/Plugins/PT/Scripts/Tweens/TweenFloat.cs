using UnityEngine;

namespace PT
{
    public class TweenFloat : Tween<float>
    {

        protected override void OnUpdate(float normalTime)
        {
            Updater.Invoke(GetValue(normalTime),this);
        }

        protected override float GetValue(float normalTime)
        {
            return Mathf.LerpUnclamped(From, To, GetEaseNormalTime(normalTime));
        }

        public TweenFloat(float duration, float from, float to, TweenUpdater<float, ITween> updater, TweenGetter<float> getter, Object target = null) : base(duration, from, to, updater, getter, target)
        {
        }
    }
}
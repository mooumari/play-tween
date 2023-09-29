using UnityEngine;

namespace PT
{
    public class TweenQuaternion : Tween<Quaternion>
    {
        public TweenQuaternion(float duration, Quaternion to, TweenGetter<Quaternion> getter, TweenUpdater<Quaternion, ITween> updater, Object target = null) : base(duration, to, getter, updater, target)
        {
        }

        protected override Quaternion GetValue(float normalTime)
        {
            return Quaternion.SlerpUnclamped(From,To,GetEaseNormalTime(normalTime));
        }

        public static TweenQuaternion New(float duration, Quaternion to, TweenGetter<Quaternion> getter, TweenUpdater<Quaternion, ITween> updater, Object target = null)
        {
            return new TweenQuaternion(duration, to, getter, updater, target);
        }
    }
}
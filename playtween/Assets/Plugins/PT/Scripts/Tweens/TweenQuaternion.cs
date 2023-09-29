using UnityEngine;

namespace PT
{
    public class TweenQuaternion : Tween<Quaternion>
    {


        protected override void OnUpdate(float normalTime)
        {
            Updater.Invoke(GetValue(normalTime),this);
        }

        protected override Quaternion GetValue(float normalTime)
        {
            return Quaternion.SlerpUnclamped(From,To,GetEaseNormalTime(normalTime));
        }

        public TweenQuaternion(float duration, Quaternion from, Quaternion to, TweenUpdater<Quaternion, ITween> updater, TweenGetter<Quaternion> getter, Object target = null) : base(duration, from, to, updater, getter, target)
        {
        }
    }
}
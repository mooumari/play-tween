using UnityEngine;

namespace PT
{
    public class TweenVector3 : Tween<Vector3>
    {
        protected override void OnUpdate(float normalTime)
        {
            Updater.Invoke(GetValue(normalTime), this);
        }
        
        protected override Vector3 GetValue(float normalTime)
        {
            return Vector3.LerpUnclamped(From,To,GetEaseNormalTime(normalTime));
        }

        public static TweenVector3 New(float duration,Vector3 from,Vector3 to,TweenUpdater<Vector3,ITween> updater,TweenGetter<Vector3> getter,Object target = null)
        {
            return new TweenVector3(duration, from, to, updater,getter, target);
        }

        public TweenVector3(float duration, Vector3 from, Vector3 to, TweenUpdater<Vector3, ITween> updater, TweenGetter<Vector3> getter, Object target = null) : base(duration, from, to, updater, getter, target)
        {
        }
    }
}
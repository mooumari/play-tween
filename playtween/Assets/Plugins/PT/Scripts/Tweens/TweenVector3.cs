using UnityEngine;

namespace PT
{
    public class TweenVector3 : Tween<Vector3>
    {
        public TweenVector3(float duration, Vector3 to, TweenGetter<Vector3> getter, TweenUpdater<Vector3, ITween> updater, Object target = null) : base(duration, to, getter, updater, target)
        {
            
        }

        protected override Vector3 GetValue(float normalTime)
        {
            return Vector3.LerpUnclamped(From, To, normalTime);
        }
        
    }
}
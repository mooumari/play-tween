using UnityEngine;

namespace PT
{
    public class TweenJump : Tween<Vector3>
    {
        private bool _up = true;
        
        public TweenJump(float duration, Vector3 to, TweenGetter<Vector3> getter, TweenUpdater<Vector3, ITween> updater, Object target = null) : base(duration, to, getter, updater, target)
        {
        }

        protected override Vector3 GetValue(float normalTime)
        {
            if (!_up)
            {
                return Vector3.LerpUnclamped(To, From, GetEaseNormalTime((normalTime - .5f) / .5f));
            }
            
            if (normalTime >= .5f)
            {
                _up = false;
            }
            return Vector3.LerpUnclamped(From, To, GetEaseNormalTime(normalTime / .5f));
        }
        
        public static TweenJump New(float duration, Vector3 to, TweenGetter<Vector3> getter, TweenUpdater<Vector3, ITween> updater, Object target = null)
        {
            return new TweenJump(duration, to, getter, updater, target);
        }
        
    }
}
using UnityEngine;

namespace PT
{
    public class TweenPunch : Tween<Vector3>
    {
        private readonly Vector3 _to;
        private bool _up = true;
        


        protected override void OnUpdate(float normalTime)
        {
            Updater.Invoke(GetValue(normalTime),this);
        }

        protected override Vector3 GetValue(float normalTime)
        {
            if (!_up) return Vector3.LerpUnclamped(_to, From, GetEaseNormalTime(normalTime));
            
            if (Mathf.Abs(normalTime) >= .5f)
            {
                _up = false;
            }
            return Vector3.LerpUnclamped(From, _to, GetEaseNormalTime(normalTime));
        }

        public TweenPunch(float duration, Vector3 from, Vector3 amount, TweenUpdater<Vector3, ITween> updater, TweenGetter<Vector3> getter, Object target = null) : base(duration, from, amount, updater, getter, target)
        {
            _to = From + amount;

        }
    }
}
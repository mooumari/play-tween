using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PT
{
    public static class PlayTween
    {
        //------------------ Fields -----------------------
        private static List<ITween> _tweensToAdd;
        private static List<ITween> _tweens;

        //------------------ Setup -----------------------
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void Init()
        {
            Setup();
            InstantiateTweenPlayRuntime();
        }
        
        private static void Setup()
        {
            _tweensToAdd = new List<ITween>();
            _tweens = new List<ITween>();
            
            Debug.Log("Setup PlayTween");
        }
        
        //------------------ Control -----------------------
        public static void Update()
        {
            if (_tweensToAdd.Count > 0)
            {
                _tweens.AddRange(_tweensToAdd);
                foreach (var tween in _tweensToAdd)
                {
                    tween.StartTween();
                }
                _tweensToAdd.Clear();
            }
            
            foreach (var tween in _tweens)
            {
                tween.UpdateTween();
            }
            
            _tweens.RemoveAll(x=>x.ShouldBeRemoved());
        }

        public static T AddTween<T>(T tween) where T : ITween
        {
            _tweensToAdd.Add(tween);
            return tween;
        }
        
        public static void Kill(Object target)
        {
            foreach (var tween in _tweens.Where(x=>x.Target == target))
            {
                tween.Kill();
            }
        }

        public static void KillAll()
        {
            foreach (var tween in _tweens)
            {
                tween.Kill();
            }

            foreach (var tween in _tweensToAdd)
            {
                tween.Kill();
            }
        }

        //------------------ Func -----------------------
        private static void InstantiateTweenPlayRuntime()
        {
            var runtime = new GameObject("PlayTween Runtime");
            runtime.AddComponent<PlayTweenRuntime>();
        }

        public static void SetTweenAsPartOfSequence(ITween tween)
        {
            _tweensToAdd.Remove(tween);
        }

        public static void RemoveTween(ITween tween)
        {
            if (_tweensToAdd.Contains(tween))
            {
                _tweensToAdd.Remove(tween);
            }

            if (_tweens.Contains(tween))
            {
                _tweens.Remove(tween);
            }
        }

        public static TweenVector3 NewTween(float duration, Vector3 to, TweenGetter<Vector3> getter, TweenUpdater<Vector3, ITween> updater, Object target = null)
        {
            return new TweenVector3(duration,to,getter,updater,target);
        }

    }
}

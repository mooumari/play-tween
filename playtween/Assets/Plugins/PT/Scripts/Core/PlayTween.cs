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
        private static List<Sequence> _sequences;

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
            _sequences = new List<Sequence>();
            
            Debug.Log("Setup PlayTween");
        }
        
        //------------------ Control -----------------------
        public static void Update(float dt)
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
                tween.Update();
            }
            
            _tweens.RemoveAll(x=>x.CanRemoveTween());
            
            //Sequence
            foreach (var sequence in _sequences)
            {
                sequence.Update();
            }

            _sequences.RemoveAll(x => x.IsCompleted());
        }

        public static T AddTween<T>(T tween) where T : ITween
        {
            _tweensToAdd.Add(tween);
            return tween;
        }

        public static Sequence GetSequence(int maxCount = 20)
        {
            return AddSequence(new Sequence(maxCount));
        }

        private static Sequence AddSequence(Sequence sequence)
        {
            _sequences.Add(sequence);
            return sequence;
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
        
    }
}

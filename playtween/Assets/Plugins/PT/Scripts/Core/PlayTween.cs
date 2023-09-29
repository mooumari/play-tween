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
        
        private static List<Sequence> _sequencesToAdd;
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

            _sequencesToAdd = new List<Sequence>();
            _sequences = new List<Sequence>();
        }
        
        //------------------ Control -----------------------
        public static void Update()
        {
            HandleTweens();
            HandleSequences();
        }

        public static T AddTween<T>(T tween) where T : ITween
        {
            _tweensToAdd.Add(tween);
            return tween;
        }
        
        public static void RemoveTween(ITween tween)
        {
            _tweensToAdd.Remove(tween);
        }
        
        public static Sequence GetSequence()
        {
            var sequence = new Sequence();
            _sequencesToAdd.Add(sequence);
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
        private static void HandleTweens()
        {
            if (_tweensToAdd.Count > 0)
            {
                _tweens.AddRange(_tweensToAdd);
                foreach (var tween in _tweensToAdd)
                {
                    tween.Start();
                }
                _tweensToAdd.Clear();
            }
            
            foreach (var tween in _tweens)
            {
                tween.Update();
            }
            
            _tweens.RemoveAll(x=>x.ShouldBeRemoved());
        }

        private static void HandleSequences()
        {
            if (_sequencesToAdd.Count > 0)
            {
                _sequences.AddRange(_sequencesToAdd);
                foreach (var sequence in _sequencesToAdd)
                {
                    sequence.Start();
                }
                _sequencesToAdd.Clear();
            }
            
            foreach (var sequence in _sequences)
            {
                sequence.Update();
            }
            
            _sequences.RemoveAll(x=>x.ShouldBeRemoved());
        }
        
        private static void InstantiateTweenPlayRuntime()
        {
            var runtime = new GameObject("PlayTween Runtime");
            runtime.AddComponent<PlayTweenRuntime>();
        }

        
    }
}

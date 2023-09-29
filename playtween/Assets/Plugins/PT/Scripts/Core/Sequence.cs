using System;
using System.Collections.Generic;
using UnityEngine;

namespace PT
{
    public class Sequence
    {
        private readonly float[] _times;
        private readonly ITween[] _tweens;
        private readonly List<ITween> _runningTweens;

        private Action _completeCallback;
        private bool _isCompleted;
        private bool _independentDeltaTime;
        private int _addIndex;
        private float _delay;
        private float _timer;
        
        public Sequence(int maxCount = 20)
        {
            _runningTweens = new List<ITween>();
            _times = new float[maxCount];
            _tweens = new ITween[maxCount];
        }

        public Sequence AddTweenAt(ITween tween, float at)
        {
            _times[_addIndex] = at;
            _tweens[_addIndex] = tween;
            _addIndex++;
            PlayTween.SetTweenAsPartOfSequence(tween);
            return this;
        }
        
        public Sequence AppendTween(ITween tween)
        {
            _times[_addIndex] = GetNextStartTime();
            _tweens[_addIndex] = tween;
            _addIndex++;
            PlayTween.SetTweenAsPartOfSequence(tween);
            return this;
        }
        
        public Sequence JoinTween(ITween tween)
        {
            _times[_addIndex] = GetLastTweenStartTime();
            _tweens[_addIndex] = tween;
            _addIndex++;
            PlayTween.SetTweenAsPartOfSequence(tween);
            return this;
        }

        private float GetNextStartTime()
        {
            float time = 0;
            
            for (var i = 0; i < _addIndex; i++)
            {
                time += _tweens[i].GetDuration();
            }

            return time;
        }
        
        private float GetLastTweenStartTime()
        {
            return _times[_addIndex-1];
        }

        public void Update()
        {
            if(_isCompleted) return;
            
            _timer += GetDeltaTime();
            
            for (var i = 0; i < _addIndex; i++)
            {
                var time = _times[i];
                var tween = _tweens[i];
                
                if (tween != null && _timer >= time)
                {
                    PlayTween.AddTween(tween);
                    _runningTweens.Add(tween);
                    _tweens[i] = null;
                }
            }

            _addIndex -= _runningTweens.RemoveAll(x => x.CanRemoveTween());

            if (_runningTweens.Count <= 0 && _addIndex <= 0)
            {
                _isCompleted = true;
                _completeCallback?.Invoke();
            }
        }

        public bool IsCompleted()
        {
            return _isCompleted;
        }

        public Sequence OnComplete(Action callback)
        {
            _completeCallback = callback;
            return this;
        }

        public Sequence SetIndependentDeltaTime(bool value)
        {
            _independentDeltaTime = value;   
            return this;
        }

        private float GetDeltaTime()
        {
            return _independentDeltaTime ? Time.deltaTime : Time.unscaledDeltaTime;
        }
        
    }
}
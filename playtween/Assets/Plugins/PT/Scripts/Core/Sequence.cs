using System;
using System.Collections.Generic;
using UnityEngine;

namespace PT
{
    public class Sequence : ITweenLoop,ITweenSetterMain<Sequence>,ITweenControl
    {
        private enum SequenceState
        {
            Waiting,
            Delay,
            Running,
            Remove,
        }
        
        public bool IsActive { get; private set; }
        public bool IsPaused { get; private set; }

        private bool _timeIndependent = false;
        private bool _autoPlay = true;
        private float _delay;
        private float _timer;
        private int _tweensCount;
        private SequenceState _currentState;

        private Action _onStart;
        private Action _onComplete;
        
        private readonly List<ITween> _tweens = new List<ITween>();
        private readonly List<ITween> _runningTweens = new List<ITween>();
        private readonly List<float> _tweensAt = new List<float>();

        public Sequence AddTweenAt(ITween tween,float at)
        {
            _tweens.Add(tween);
            _tweensAt.Add(at);
            PlayTween.RemoveTween(tween);
            _tweensCount++;
            return this;
        }
        
        public Sequence Join(ITween tween)
        {
            _tweens.Add(tween);
            _tweensAt.Add(GetLastTweenStartTime());
            PlayTween.RemoveTween(tween);
            _tweensCount++;
            return this;
        }
        
        public Sequence Append(ITween tween)
        {
            _tweens.Add(tween);
            _tweensAt.Add(GetLastTweenEndTime());
            PlayTween.RemoveTween(tween);
            _tweensCount++;
            return this;
        }
        
        private void SetNewState(SequenceState newState,bool force = false)
        {
            if(_currentState == SequenceState.Remove) return;
            if(!force && _currentState == newState) return;
            _currentState = newState;
            _timer = 0f;
        }
        
        public void Start()
        {
            IsActive = true;
            SetNewState(SequenceState.Waiting);
        }

        public void Update()
        {
            var dt = GetDeltaTime();
            _timer += dt;
            
            switch (_currentState)
            {
                case SequenceState.Waiting:
                    if (_autoPlay)
                    {
                        SetNewState(SequenceState.Delay);
                    }
                    break;
                case SequenceState.Delay:
                    if (_timer >= _delay)
                    {
                        SetNewState(SequenceState.Running);
                        _onStart?.Invoke();
                    }
                    break;
                case SequenceState.Running:

                    for (int i = 0; i < _tweens.Count; i++)
                    {
                        var tween = _tweens[i];
                        var at = _tweensAt[i];

                        if (_timer >= at && !_runningTweens.Contains(tween))
                        {
                            _runningTweens.Add(tween);
                            PlayTween.AddTween(tween);
                            _tweensCount--;
                        }
                    }

                    _runningTweens.RemoveAll(x => x.ShouldBeRemoved());

                    if (_runningTweens.Count <= 0 && _tweensCount <= 0)
                    {
                        End();
                    }   
                    break;
            }
            
        }

        public void End()
        {
            SetNewState(SequenceState.Remove);
            IsActive = false;
            
            _onComplete?.Invoke();
        }

        public bool ShouldBeRemoved()
        {
            return _currentState == SequenceState.Remove;
        }

        public float GetDeltaTime()
        {
            if (IsPaused) return 0;
            return _timeIndependent ? Time.unscaledDeltaTime : Time.deltaTime;
        }

        public Sequence SetDelay(float delay)
        {
            _delay = delay;
            return this;
        }

        public Sequence SetLoop(int loopCount, LoopType loopType = LoopType.YoYo)
        {
            return this;
        }

        public Sequence SetTimeIndependent(bool timeIndependent = true)
        {
            _timeIndependent = timeIndependent;
            return this;
        }

        public Sequence SetPlayDirection(PlayDirection playDirection = PlayDirection.Forward)
        {
            
            return this;
        }

        public Sequence SetAutoPlay(bool value = true)
        {
            _autoPlay = value;
            return this;
        }

        public Sequence OnStart(Action callback)
        {
            _onStart = callback;
            return this;
        }

        public Sequence OnComplete(Action callback)
        {
            _onComplete = callback;
            return this;
        }

        private float GetLastTweenStartTime()
        {
            if (_tweensAt.Count > 0)
            {
                return _tweensAt[_tweensAt.Count-1];
            }
            return 0;
        }
        
        private float GetLastTweenEndTime()
        {
            if (_tweensAt.Count > 0)
            {
                return _tweensAt[_tweensAt.Count-1] + _tweens[_tweens.Count-1].GetFullDuration();
            }

            return 0;
        }

        public void Kill()
        {
            SetNewState(SequenceState.Remove);
        }

        public void Play()
        {
            _autoPlay = true;
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Restart()
        {
            IsPaused = false;
        }
    }
}
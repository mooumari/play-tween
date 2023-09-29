using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PT
{
    public abstract class Tween<T> : ITween
    {
        private enum TweenState
        {
            Waiting,
            Delay,
            Running,
            Remove,
        }
        
        //------------------ Properties -----------------------
        public bool HasTarget { get; }
        public Object Target { get; }
        public bool IsTweenActive { get; private set; } = false;
        public bool IsPaused { get; private set; } = false;

        //------------------ Fields -----------------------
        private TweenState _currentState = TweenState.Waiting;
        private bool _setFromStart = false;
        private bool _autoPlay = true;
        private bool _timeIndependent = false;
        private float _timer = 0f;
        private float _delay = 0f;
        
        private EaseDataType _easeDataType = EaseDataType.Ease;
        private AnimationCurve _easeAnimationCurve;
        private EaseType _easeType;
        
        private Action _onStart;
        private Action _onComplete;

        private PlayDirection _playDirection;
        private PlayDirection _currentPlayDirection;
        private LoopType _loopType;
        private int _loopCount;
        private int _currentLoopCount = 0;
        
        protected T From;
        protected readonly T To;
        protected readonly float Duration;
        protected readonly TweenGetter<T> Getter;
        protected readonly TweenUpdater<T,ITween> Updater;
        
        //------------------ Setup -----------------------
        protected Tween(float duration,T to, TweenGetter<T> getter,TweenUpdater<T,ITween> updater, Object target = null)
        {
            Target = target;
            HasTarget = target != null;
            
            To = to;
            Duration = duration;
            Getter = getter;
            Updater = updater;
            PlayTween.AddTween(this);
        }
        
        //------------------ Tween Loop -----------------------
        public void StartTween()
        {
            IsTweenActive = true;
            IsPaused = false;
            _currentLoopCount = 0;
            _currentPlayDirection = _playDirection;
            SetNewState(TweenState.Waiting,true);
        }

        public void UpdateTween()
        {
            if (HasTarget && Target == null)
            {
                SetNewState(TweenState.Remove,true);
                Debug.LogWarning("Object deleted!");
                return;
            }
            
            _timer += GetDeltaTime();
            
            switch (_currentState)
            {
                case TweenState.Running:
                    UpdateLoop();
                    break;
                case TweenState.Delay:
                    if (_timer >= _delay)
                    {
                        StartLoop();
                    }
                    break;
                case TweenState.Waiting:
                    if (_autoPlay)
                    {
                        SetNewState(TweenState.Delay);
                    }
                    break;
            }
        }

        public void EndTween()
        {
            IsTweenActive = false;
            SetNewState(TweenState.Remove);
            _onComplete?.Invoke();
        }

        #region Tween Loop

        protected virtual void StartLoop()
        {
            SetNewState(TweenState.Running,true);
            From = Getter();
            _currentLoopCount++;
            
            //if first loop fire start event
            if (_currentLoopCount == 1)
            {
                _onStart?.Invoke();
            }
            else
            {
                //update Direction based on Loop Type
                switch (_loopType)
                {
                    case LoopType.Restart:
                        break;
                    case LoopType.YoYo:
                        _currentPlayDirection = _currentPlayDirection == PlayDirection.Forward
                            ? PlayDirection.Backward
                            : PlayDirection.Forward;
                        break;
                }
            }
            

            
            //Update Value
            Updater(GetValue(GetNormalTime()),this);
        }

        protected virtual void UpdateLoop()
        {
            Updater(GetValue(GetEaseNormalTime(GetNormalTime())),this);
            
            //Check for Completion
            if (GetNormalTime(true) >= 1f)
            {
                EndLoop();
            }
        }

        protected virtual void EndLoop()
        {
            if (_currentLoopCount >= _loopCount && _loopCount >= 0)
            {
                EndTween();
                return;
            }

            StartLoop();
        }
        
        #endregion
        
        //------------------ Control -----------------------
        private void SetNewState(TweenState newState,bool force = false)
        {
            if(_currentState == TweenState.Remove) return;
            if (!force && _currentState == newState) return;
            _currentState = newState;
            _timer = 0;
            switch (_currentState)
            {
                case TweenState.Delay:
                    //Update Value On delay before running the tween
                    if (_setFromStart)
                    {
                        Updater(GetValue(GetNormalTime()),this);
                    }
                    break;
                case TweenState.Running:
                    break;
            }
        }
        
        public void Kill()
        {
            SetNewState(TweenState.Remove);
        }

        public void Play()
        {
            _autoPlay = true;
            IsPaused = false;
        }

        public void Pause()
        {
            IsPaused = true;
        }

        public void Restart()
        {
            StartTween();
        }

        //------------------ Setter -----------------------
        public ITween SetDelay(float delay)
        {
            _delay = delay;
            return this;
        }

        public ITween SetLoop(int loopCount, LoopType loopType = LoopType.YoYo)
        {
            _loopType = loopType;
            _loopCount = loopCount;
            return this;
        }

        public ITween SetFromAtStart(bool value = true)
        {
            _setFromStart = value;
            return this;
        }

        public ITween SetEase(EaseType easeType)
        {
            _easeDataType = EaseDataType.Ease;
            _easeType = easeType;
            return this;
        }

        public ITween SetEase(EaseData easeData)
        {
            _easeDataType = easeData.easeDataType;
            _easeAnimationCurve = easeData.animationCurve;
            _easeType = easeData.easeType;
            return this;
        }

        public ITween SetEase(AnimationCurve animationCurve)
        {
            _easeDataType = EaseDataType.AnimationCurve;
            _easeAnimationCurve = animationCurve;
            return this;
        }

        public ITween SetTimeIndependent(bool timeIndependent = true)
        {
            _timeIndependent = timeIndependent;
            return this;
        }

        public ITween SetPlayDirection(PlayDirection playDirection = PlayDirection.Forward)
        {
            _playDirection = playDirection;
            _currentPlayDirection = _playDirection;
            return this;
        }

        public ITween SetAutoPlay(bool value = true)
        {
            _autoPlay = value;
            return this;
        }

        public ITween OnStart(Action callback)
        {
            _onStart = callback;
            return this;
        }

        public ITween OnComplete(Action callback)
        {
            _onComplete = callback;
            return this;
        }

        //------------------ Getter -----------------------
        public bool ShouldBeRemoved()
        {
            return _currentState == TweenState.Remove;
        }

        public float GetDeltaTime()
        {
            if (IsPaused) return 0;
            return _timeIndependent? Time.unscaledDeltaTime : Time.deltaTime;
        }

        public float GetNormalTime(bool onlyForward = false)
        {
            if (onlyForward || _currentPlayDirection == PlayDirection.Forward) return Mathf.Clamp01(_timer / Duration);
            return Mathf.Clamp01((1 - _timer) / Duration);
        }

        public float GetEaseNormalTime(float normalTime)
        {
            return _easeDataType == EaseDataType.AnimationCurve ? _easeAnimationCurve.Evaluate(normalTime) : EaseLibrary.LerpEase(normalTime, _easeType);
        }

        protected abstract T GetValue(float normalTime);
    }
}
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
        }
        
        private PlayDirection _playDirection = PlayDirection.Forward;
        private TweenState _tweenState = TweenState.Waiting;
        private bool _isPartOfSequence = false;
        private bool _independentDeltaTime = false;
        private bool _autoStart = true;
        private bool _setFromStart = true;
        private bool _firstLoop = true;
        private int _currentLoopCount = 0;
        private int _loopCount = 0;
        private LoopType _loopType = LoopType.Restart;

        private readonly float _duration;
        private float _delay;
        private float _timer;
        private bool _isCompleted = false;
        private bool _isKilled = false;
        private EaseDataType _easeDataType = EaseDataType.Ease;
        private AnimationCurve _easeAnimationCurve;
        private EaseType _easeType = EaseType.Linear;
        private Action _completeCallback;
        private Action _startCallback;
        private Action<float,ITween> _updateCallback;
        private ITween _afterTween;
        
        protected readonly T From;
        protected readonly T To;
        protected readonly TweenUpdater<T, ITween> Updater;
        protected readonly TweenGetter<T> Getter;

        public Object Target { get; set; }
        
        //------------------ Setup -----------------------
        protected Tween(float duration,T from, T to, TweenUpdater<T, ITween> updater,TweenGetter<T> getter,Object target = null)
        {
            Getter = getter;
            _duration = duration;
            From = from;
            To = to;
            Updater = updater;
            Target = target;
            PlayTween.AddTween(this);
        }

        private void SetState(TweenState newState)
        {
            if (_tweenState == newState) return;
            _tweenState = newState;
        }
        
        //------------------ ITween -----------------------
        public virtual void StartTween()
        {
            _currentLoopCount++;
            _timer = 0f;
            
            if (!_autoStart)
            {
                SetState(TweenState.Waiting);
            }
            else
            {
                if (_firstLoop)
                {
                    SetState(_delay > 0 ? TweenState.Delay : TweenState.Running);
                    OnTweenStarted();
                }
                else
                {
                    SetState(TweenState.Running);
                }
            }
            
            if (!_firstLoop)
            {
                switch (_loopType)
                {
                    case LoopType.Restart:
                        break;
                    case LoopType.YoYo:
                        _playDirection = _playDirection == PlayDirection.Forward
                            ? PlayDirection.Backward
                            : PlayDirection.Forward;
                        break;
                }
            }
            
            _firstLoop = false;
        }

        public virtual void Update()
        {
            _timer += GetDeltaTime();

            switch (_tweenState)
            {
                case TweenState.Running:
                    var normalTime = GetNormalTime();
                    
                    OnUpdate(normalTime);
                    _updateCallback?.Invoke(normalTime,this);
                    
                    if (GetNormalTime(true) >= 1f) CompleteTween();
                    break;
                case TweenState.Delay:
                    if (_timer >= _delay)
                    {
                        _timer = 0;
                        SetState(TweenState.Running);
                    }
                    break;
                case TweenState.Waiting:
                    if (_autoStart)
                    {
                        _timer = 0;
                        SetState(_delay > 0 ? TweenState.Delay : TweenState.Running);
                        OnTweenStarted();
                    }
                    break;
            }
        }

        public float GetDuration()
        {
            return _duration;
        }

        public float GetDeltaTime()
        {
            return _independentDeltaTime ? Time.unscaledDeltaTime : Time.deltaTime;
        }

        public virtual bool CanRemoveTween()
        {
            return _isCompleted || _isKilled;
        }

        public bool IsRunning()
        {
            return _tweenState == TweenState.Running;
        }

        //------------------ Getter -----------------------
        public float GetNormalTime(bool onlyForward = false)
        {
            if (onlyForward || _playDirection == PlayDirection.Forward)
            {
                return Mathf.Clamp01(_timer / _duration);
            } 
            return Mathf.Clamp01((1 - _timer) / _duration);
        }

        public float GetEaseNormalTime(float normalTime)
        {
            return _easeDataType == EaseDataType.Ease ? EaseLibrary.LerpEasing(normalTime, _easeType) : _easeAnimationCurve.Evaluate(normalTime);
        }
        
        //------------------ Internal Control -----------------------
        protected virtual void CompleteTween()
        {
            if (_loopCount < 0 || _currentLoopCount < _loopCount)
            {
                StartTween();
                return;
            }
            _isCompleted = true;
            _completeCallback?.Invoke();
            
            OnTweenCompleted();
            _afterTween?.Play();
        }
        
        //------------------ External Control -----------------------
        public virtual void Kill()
        {
            _isKilled = true;
        }

        public ITween SetDirection(PlayDirection direction = PlayDirection.Forward)
        {
            _playDirection = direction;
            return this;
        }

        public ITween SetLoop(int loopCount, LoopType loopType = LoopType.Restart)
        {
            _loopCount = loopCount;
            _loopType = loopType;
            
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
            _easeType = easeData.easeType;
            _easeAnimationCurve = easeData.animationCurve;
            return this;
        }

        public ITween SetEase(AnimationCurve animationCurve)
        {
            _easeDataType = EaseDataType.AnimationCurve;
            _easeAnimationCurve = animationCurve;
            return this;
        }

        public ITween SetDelay(float delay)
        {
            _delay = delay;
            return this;
        }

        public ITween SetAutoStart(bool value = true)
        {
            _autoStart = value;
            return this;
        }

        public ITween SetFromStart(bool value = true)
        {
            _setFromStart = value;
            return this;
        }

        public ITween OnUpdateCallback(Action<float, ITween> callback)
        {
            _updateCallback = callback;
            return this;
        }

        public ITween ThenPlay(ITween tween)
        {
            tween.SetAutoStart(false);
            
            if (_afterTween != null)
            {
                _afterTween.ThenPlay(tween);
            }
            else
            {
                _afterTween = tween;
            }
            return this;
        }

        public ITween SetIndependentDeltaTime(bool value = true)
        {
            _independentDeltaTime = value;
            return this;
        }

        public void SetAsPartOfSequence()
        {
            _isPartOfSequence = true;
        }

        public void Play()
        {
            _autoStart = true;
        }

        public ITween OnComplete(Action callback)
        {
            _completeCallback = callback;
            return this;
        }

        public ITween OnStart(Action callback)
        {
            _startCallback = callback;
            return this;
        }
        
        //------------------ Virtual -----------------------
        protected virtual void OnTweenStarted()
        {
            _startCallback?.Invoke();
            
            if (_setFromStart)
            {
                OnUpdate(GetNormalTime());
            }
        }
        
        protected virtual void OnTweenCompleted()
        {
            
        }

        protected abstract void OnUpdate(float normalTime);
        protected abstract T GetValue(float normalTime);
    }
}
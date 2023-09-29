using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PT
{
    public interface ITweenControl
    {
        public bool IsPaused { get; }

        //Control
        void Kill();
        void Play();
        void Pause();
        void Restart();
    }

    public interface ITweenSetter<out T> : ITweenSetterMain<T>
    {
        T SetFromAtStart(bool value = true);
        T SetEase(EaseType easeType);
        T SetEase(EaseData easeData);
        T SetEase(AnimationCurve animationCurve);
    }

    public interface ITweenSetterMain<out T>
    {
        T SetDelay(float delay);
        T SetLoop(int loopCount,LoopType loopType = LoopType.YoYo);
        T SetTimeIndependent(bool timeIndependent = true);
        T SetPlayDirection(PlayDirection playDirection = PlayDirection.Forward);
        T SetAutoPlay(bool value = true);
        T OnStart(Action callback);
        T OnComplete(Action callback);
    }

    public interface ITweenLoop
    {
        public bool IsActive { get; }

        void Start();
        void Update();
        void End();
        
        bool ShouldBeRemoved();
        float GetDeltaTime();
    }
    
    public interface ITween : ITweenControl,ITweenSetter<ITween>,ITweenLoop
    {
        //Properties
        public bool HasTarget { get; }
        public Object Target { get; }
        
        //Getter
        float GetNormalTime(bool onlyForward = false);
        float GetEaseNormalTime(float normalTime);
        float GetFullDuration();
        float GetDelay();
        float GetDuration();
    }
}
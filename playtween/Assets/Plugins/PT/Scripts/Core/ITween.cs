using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PT
{
    public interface ITween
    {
        //Properties
        public bool HasTarget { get; }
        public Object Target { get; }
        public bool IsTweenActive { get; }
        public bool IsPaused { get; }
        
        //Loop
        void StartTween();
        void UpdateTween();
        void EndTween();

        //Control
        void Kill();
        void Play();
        void Pause();
        void Restart();
        
        //Setter
        ITween SetDelay(float delay);
        ITween SetLoop(int loopCount,LoopType loopType = LoopType.YoYo);
        ITween SetFromAtStart(bool value = true);
        ITween SetEase(EaseType easeType);
        ITween SetEase(EaseData easeData);
        ITween SetEase(AnimationCurve animationCurve);
        ITween SetTimeIndependent(bool timeIndependent = true);
        ITween SetPlayDirection(PlayDirection playDirection = PlayDirection.Forward);
        ITween SetAutoPlay(bool value = true);
        ITween OnStart(Action callback);
        ITween OnComplete(Action callback);
        
        //Getter
        bool ShouldBeRemoved();
        float GetDeltaTime();
        float GetNormalTime(bool onlyForward = false);
        float GetEaseNormalTime(float normalTime);

    }
}
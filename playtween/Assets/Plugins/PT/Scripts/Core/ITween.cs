using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PT
{
    public interface ITween
    {
        Object Target { get; set; }
        float GetNormalTime(bool onlyForward = false);
        float GetEaseNormalTime(float normalTime);
        float GetDuration();
        float GetDeltaTime();
        bool CanRemoveTween();
        bool IsRunning();

        ITween SetDirection(PlayDirection direction = PlayDirection.Forward);
        ITween SetLoop(int loopCount,LoopType loopType = LoopType.Restart);
        ITween SetEase(EaseType easeType);
        ITween SetEase(EaseData easeData);
        ITween SetEase(AnimationCurve animationCurve);
        ITween SetDelay(float delay);
        ITween SetAutoStart(bool value = true);
        ITween SetFromStart(bool value = true);
        ITween OnComplete(Action callback);
        ITween OnStart(Action callback);
        ITween OnUpdateCallback(Action<float,ITween> callback);
        ITween ThenPlay(ITween tween);
        ITween SetIndependentDeltaTime(bool value = true);

        void SetAsPartOfSequence();
        void Play();
        void Update();
        void StartTween();
        void Kill();
    }
}
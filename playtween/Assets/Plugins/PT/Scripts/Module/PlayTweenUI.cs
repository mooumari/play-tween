using UnityEngine;
using UnityEngine.UI;

namespace PT
{
    public static class PlayTweenUI
    {
        //------------------ Play AnchorPosition -----------------------
        public static TweenVector3 PlayAnchorPosition(this RectTransform target, Vector3 to, float duration)
        {
            return TweenVector3.New(duration,
                to,
                () => target.anchoredPosition3D,
                (value, tween) =>
                {
                    target.anchoredPosition3D = value;
                },target);
        }
        
        public static TweenFloat PlayAnchorPositionX(this RectTransform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.anchoredPosition3D.x,
                (value, tween) =>
                {
                    var newValue = target.anchoredPosition3D;
                    newValue.x = value;
                    target.anchoredPosition3D = newValue;
                },target);
        }
        
        public static TweenFloat PlayAnchorPositionY(this RectTransform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.anchoredPosition3D.y,
                (value, tween) =>
                {
                    var newValue = target.anchoredPosition3D;
                    newValue.y = value;
                    target.anchoredPosition3D = newValue;
                },target);
        }
        
        public static TweenFloat PlayAnchorPositionZ(this RectTransform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.anchoredPosition3D.z,
                (value, tween) =>
                {
                    var newValue = target.anchoredPosition3D;
                    newValue.z = value;
                    target.anchoredPosition3D = newValue;
                },target);
        }
        
        //------------------ Play CanvasGroup -----------------------
        public static TweenFloat PlayAlpha(this CanvasGroup target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.alpha,
                (value, tween) =>
                {
                    target.alpha = value;
                },target);
        }
        
        //------------------ Play Color -----------------------
        public static TweenColor PlayColor(this Graphic target, Color to, float duration)
        {
            return TweenColor.New(duration,
                to,
                () => target.color,
                (value, tween) =>
                {
                    target.color = value;
                },target);
        }
        
        //------------------ Play Pivot -----------------------
        public static TweenVector2 PlayPivot(this RectTransform target, Vector2 to, float duration)
        {
            return TweenVector2.New(duration,
                to,
                () => target.pivot,
                (value, tween) =>
                {
                    target.pivot = value;
                },target);
        }
        
        public static TweenFloat PlayPivotX(this RectTransform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.pivot.x,
                (value, tween) =>
                {
                    var newValue = target.pivot;
                    newValue.x = value;
                    target.pivot = newValue;
                },target);
        }
        
        public static TweenFloat PlayPivotY(this RectTransform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.pivot.y,
                (value, tween) =>
                {
                    var newValue = target.pivot;
                    newValue.y = value;
                    target.pivot = newValue;
                },target);
        }
        
        //------------------ Play SizeDelta -----------------------
        public static TweenVector2 PlaySizeDelta(this RectTransform target, Vector2 to, float duration)
        {
            return TweenVector2.New(duration,
                to,
                () => target.sizeDelta,
                (value, tween) =>
                {
                    target.sizeDelta = value;
                },target);
        }
        
        public static TweenFloat PlaySizeDeltaX(this RectTransform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.sizeDelta.x,
                (value, tween) =>
                {
                    var newValue = target.sizeDelta;
                    newValue.x = value;
                    target.sizeDelta = newValue;
                },target);
        }
        
        public static TweenFloat PlaySizeDeltaY(this RectTransform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.sizeDelta.y,
                (value, tween) =>
                {
                    var newValue = target.sizeDelta;
                    newValue.y = value;
                    target.sizeDelta = newValue;
                },target);
        }
        
        
    }
}
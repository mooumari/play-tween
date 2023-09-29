using UnityEngine;

namespace PT
{
    public static class PlayTweenUI
    {
        //------------------ AnchorPosition 3D -----------------------
        public static TweenVector3 PlayAnchorPosition3D(this RectTransform target,Vector3 from, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,from,to, (value, tween) =>
            {
                target.anchoredPosition3D = value;
            },() => Vector3.zero,target));
        }
        
        public static TweenVector3 PlayAnchorPosition3D(this RectTransform target, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,target.anchoredPosition3D,to, (value, tween) =>
            {
                target.anchoredPosition3D = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ AnchorPosition -----------------------
        public static TweenVector2 PlayAnchorPosition(this RectTransform target,Vector2 from, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,from,to, (value, tween) =>
            {
                target.anchoredPosition = value;
            },() => Vector3.zero,target));
        }
        
        public static TweenVector2 PlayAnchorPosition(this RectTransform target, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,target.anchoredPosition3D,to, (value, tween) =>
            {
                target.anchoredPosition = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ AnchorPosition X -----------------------
        public static TweenFloat PlayAnchorPositionX(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.anchoredPosition3D;
                newValue.x = value;
                target.anchoredPosition3D = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayAnchorPositionX(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.anchoredPosition3D.x,to, (value, tween) =>
            {
                var newValue = target.anchoredPosition3D;
                newValue.x = value;
                target.anchoredPosition3D = newValue;
            },() => 0,target));
        }
        
        //------------------ AnchorPosition Y -----------------------
        public static TweenFloat PlayAnchorPositionY(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.anchoredPosition3D;
                newValue.y = value;
                target.anchoredPosition3D = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayAnchorPositionY(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.anchoredPosition3D.y,to, (value, tween) =>
            {
                var newValue = target.anchoredPosition3D;
                newValue.y = value;
                target.anchoredPosition3D = newValue;
            },() => 0,target));
        }
        
        //------------------ AnchorPosition Z -----------------------
        public static TweenFloat PlayAnchorPositionZ(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.anchoredPosition3D;
                newValue.z = value;
                target.anchoredPosition3D = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayAnchorPositionZ(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.anchoredPosition3D.z,to, (value, tween) =>
            {
                var newValue = target.anchoredPosition3D;
                newValue.z = value;
                target.anchoredPosition3D = newValue;
            },() => 0,target));
        }
        
        //------------------ PlayAnchorMin -----------------------
        public static TweenVector2 PlayAnchorMin(this RectTransform target,Vector2 from, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,from,to, (value, tween) =>
            {
                target.anchorMin = value;
            },() => Vector3.zero,target));
        }
        
        public static TweenVector2 PlayAnchorMin(this RectTransform target, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,target.anchorMin,to, (value, tween) =>
            {
                target.anchorMin = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ PlayAnchorMinX -----------------------
        public static TweenFloat PlayAnchorMinX(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.anchorMin;
                newValue.x = value;
                target.anchorMin = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayAnchorMinX(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.anchorMin.x,to, (value, tween) =>
            {
                var newValue = target.anchorMin;
                newValue.x = value;
                target.anchorMin = newValue;
            },() => 0,target));
        }
        
        //------------------ PlayAnchorMinY -----------------------
        public static TweenFloat PlayAnchorMinY(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.anchorMin;
                newValue.y = value;
                target.anchorMin = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayAnchorMinY(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.anchorMin.y,to, (value, tween) =>
            {
                var newValue = target.anchorMin;
                newValue.y = value;
                target.anchorMin = newValue;
            },() => 0,target));
        }
        
        //------------------ PlayAnchorMax -----------------------
        public static TweenVector2 PlayAnchorMax(this RectTransform target,Vector2 from, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,from,to, (value, tween) =>
            {
                target.anchorMax = value;
            },() => Vector3.zero,target));
        }
        
        public static TweenVector2 PlayAnchorMax(this RectTransform target, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,target.anchorMin,to, (value, tween) =>
            {
                target.anchorMax = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ PlayAnchorMinX -----------------------
        public static TweenFloat PlayAnchorMaxX(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.anchorMax;
                newValue.x = value;
                target.anchorMax = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayAnchorMaxX(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.anchorMax.x,to, (value, tween) =>
            {
                var newValue = target.anchorMax;
                newValue.x = value;
                target.anchorMax = newValue;
            },() => 0,target));
        }
        
        //------------------ PlayAnchorMinY -----------------------
        public static TweenFloat PlayAnchorMaxY(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.anchorMax;
                newValue.y = value;
                target.anchorMax = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayAnchorMaxY(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.anchorMax.y,to, (value, tween) =>
            {
                var newValue = target.anchorMax;
                newValue.y = value;
                target.anchorMax = newValue;
            },() => 0,target));
        }
        
        //------------------ Pivot -----------------------
        public static TweenVector2 PlayPivot(this RectTransform target,Vector2 from, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,from,to, (value, tween) =>
            {
                target.pivot = value;
            },() => Vector3.zero,target));
        }
        
        public static TweenVector2 PlayPivot(this RectTransform target, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,target.pivot,to, (value, tween) =>
            {
                target.pivot = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ Pivot X -----------------------
        public static TweenFloat PlayPivotX(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.pivot;
                newValue.x = value;
                target.pivot = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayPivotX(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.pivot.x,to, (value, tween) =>
            {
                var newValue = target.pivot;
                newValue.x = value;
                target.pivot = newValue;
            },() => 0,target));
        }
        
        //------------------ Pivot Y -----------------------
        public static TweenFloat PlayPivotY(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.pivot;
                newValue.y = value;
                target.pivot = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayPivotY(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.pivot.y,to, (value, tween) =>
            {
                var newValue = target.pivot;
                newValue.y = value;
                target.pivot = newValue;
            },() => 0,target));
        }
        
        //------------------ SizeDelta -----------------------
        public static TweenVector2 PlaySizeDelta(this RectTransform target,Vector2 from, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,from,to, (value, tween) =>
            {
                target.sizeDelta = value;
            },() => Vector3.zero,target));
        }
        
        public static TweenVector2 PlaySizeDelta(this RectTransform target, Vector2 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector2(duration,target.sizeDelta,to, (value, tween) =>
            {
                target.sizeDelta = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ Pivot X -----------------------
        public static TweenFloat PlaySizeDeltaX(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.sizeDelta;
                newValue.x = value;
                target.sizeDelta = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlaySizeDeltaX(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.sizeDelta.x,to, (value, tween) =>
            {
                var newValue = target.sizeDelta;
                newValue.x = value;
                target.sizeDelta = newValue;
            },() => 0,target));
        }
        
        //------------------ Pivot Y -----------------------
        public static TweenFloat PlaySizeDeltaY(this RectTransform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.sizeDelta;
                newValue.y = value;
                target.sizeDelta = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlaySizeDeltaY(this RectTransform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.sizeDelta.y,to, (value, tween) =>
            {
                var newValue = target.sizeDelta;
                newValue.y = value;
                target.sizeDelta = newValue;
            },() => 0,target));
        }
    }
}
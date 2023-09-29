using UnityEngine;

namespace PT
{
    public static class PlayTweenTransform
    {
        //------------------ Play Move -----------------------
        public static TweenVector3 PlayMove(this Transform target, Vector3 to, float duration)
        {
            return TweenVector3.New(duration,
                to,
                () => target.position,
                (value, tween) =>
                {
                    target.position = value;
                },target);
        }
        
        public static TweenFloat PlayMoveX(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.position.x,
                (value, tween) =>
                {
                    var newValue = target.position;
                    newValue.x = value;
                    target.position = newValue;
                },target);
        }
        
        public static TweenFloat PlayMoveY(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.position.y,
                (value, tween) =>
                {
                    var newValue = target.position;
                    newValue.y = value;
                    target.position = newValue;
                },target);
        }
        
        public static TweenFloat PlayMoveZ(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.position.z,
                (value, tween) =>
                {
                    var newValue = target.position;
                    newValue.z = value;
                    target.position = newValue;
                },target);
        }
        
        //------------------ Play Local Move -----------------------
        public static TweenVector3 PlayLocalMove(this Transform target, Vector3 to, float duration)
        {
            return TweenVector3.New(duration,
                to,
                () => target.localPosition,
                (value, tween) =>
                {
                    target.localPosition = value;
                },target);
        }
        
        public static TweenFloat PlayLocalMoveX(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.localPosition.x,
                (value, tween) =>
                {
                    var newValue = target.localPosition;
                    newValue.x = value;
                    target.localPosition = newValue;
                },target);
        }
        
        public static TweenFloat PlayLocalMoveY(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.localPosition.y,
                (value, tween) =>
                {
                    var newValue = target.localPosition;
                    newValue.y = value;
                    target.localPosition = newValue;
                },target);
        }
        
        public static TweenFloat PlayLocalMoveZ(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.localPosition.z,
                (value, tween) =>
                {
                    var newValue = target.localPosition;
                    newValue.z = value;
                    target.localPosition = newValue;
                },target);
        }
        
        //------------------ Play Scale -----------------------
        public static TweenVector3 PlayScale(this Transform target, Vector3 to, float duration)
        {
            return TweenVector3.New(duration,
                to,
                () => target.localScale,
                (value, tween) =>
                {
                    target.localScale = value;
                },target);
        }
        
        public static TweenFloat PlayScaleX(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.localScale.x,
                (value, tween) =>
                {
                    var newValue = target.localScale;
                    newValue.x = value;
                    target.localScale = newValue;
                },target);
        }
        
        public static TweenFloat PlayScaleY(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.localScale.y,
                (value, tween) =>
                {
                    var newValue = target.localScale;
                    newValue.y = value;
                    target.localScale = newValue;
                },target);
        }
        
        public static TweenFloat PlayScaleZ(this Transform target, float to, float duration)
        {
            return TweenFloat.New(duration,
                to,
                () => target.localScale.z,
                (value, tween) =>
                {
                    var newValue = target.localScale;
                    newValue.z = value;
                    target.localScale = newValue;
                },target);
        }
        
        //------------------ Play Rotate -----------------------
        public static TweenVector3 PlayRotate(this Transform target, Vector3 to, float duration)
        {
            return TweenVector3.New(duration,
                to,
                () => target.rotation.eulerAngles,
                (value, tween) =>
                {
                    target.rotation = Quaternion.Euler(value);
                },target);
        }

        //------------------ Play Local Rotate -----------------------
        public static TweenVector3 PlayLocalRotate(this Transform target, Vector3 to, float duration)
        {
            return TweenVector3.New(duration,
                to,
                () => target.localRotation.eulerAngles,
                (value, tween) =>
                {
                    target.localRotation = Quaternion.Euler(value);
                },target);
        }
        
        //------------------ Play Quaternion -----------------------
        public static TweenQuaternion PlayQuaternion(this Transform target, Quaternion to, float duration)
        {
            return TweenQuaternion.New(duration,
                to,
                () => target.rotation,
                (value, tween) =>
                {
                    target.rotation = value;
                },target);
        }
        
        //------------------ Play Local Quaternion -----------------------
        public static TweenQuaternion PlayLocalQuaternion(this Transform target, Quaternion to, float duration)
        {
            return TweenQuaternion.New(duration,
                to,
                () => target.localRotation,
                (value, tween) =>
                {
                    target.localRotation = value;
                },target);
        }
        
        //------------------ Play Jump -----------------------
        public static TweenJump PlayJump(this Transform target, Vector3 to, float duration)
        {
            return TweenJump.New(duration,
                to,
                () => target.position,
                (value, tween) =>
                {
                    target.position = value;
                },target);
        }
        
        
    }
}
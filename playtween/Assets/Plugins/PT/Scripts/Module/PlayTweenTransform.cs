using UnityEngine;

namespace PT
{
    public static class PlayTweenTransform
    {
        //------------------ World Move -----------------------
        public static TweenVector3 PlayMove(this Transform target,Vector3 from, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,from,to, (value, tween) =>
            {
                target.position = value;
            },() => Vector3.zero, target));
        }
        
        public static TweenVector3 PlayMove(this Transform target, Vector3 to,float duration)
        {
            return TweenVector3.New(duration,target.position,to, (value, tween) =>
            {
                target.position = value;
            },() => Vector3.zero,target);
        }
        
        //------------------ Local Move -----------------------
        public static TweenVector3 PlayLocalMove(this Transform target,Vector3 from, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,from,to, (value, tween) =>
            {
                target.localPosition = value;
            },() => Vector3.zero,target));
        }
        
        public static TweenVector3 PlayLocalMove(this Transform target, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,target.localPosition,to, (value, tween) =>
            {
                target.localPosition = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ Move X -----------------------
        public static TweenFloat PlayMoveX(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.position;
                newValue.x = value;
                target.position = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayMoveX(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.position.x,to, (value, tween) =>
            {
                var newValue = target.position;
                newValue.x = value;
                target.position = newValue;
            },() => 0,target));
        }
        
        //------------------ Local Move X -----------------------
        public static TweenFloat PlayLocalMoveX(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.localPosition;
                newValue.x = value;
                target.localPosition = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayLocalMoveX(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.localPosition.x,to, (value, tween) =>
            {
                var newValue = target.localPosition;
                newValue.x = value;
                target.localPosition = newValue;
            },() => 0,target));
        }

        //------------------ Move Y -----------------------
        public static TweenFloat PlayMoveY(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.position;
                newValue.y = value;
                target.position = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayMoveY(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.position.y,to, (value, tween) =>
            {
                var newValue = target.position;
                newValue.y = value;
                target.position = newValue;
            },() => 0,target));
        }
        
        //------------------ Local Move Y -----------------------
        public static TweenFloat PlayLocalMoveY(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.localPosition;
                newValue.y = value;
                target.localPosition = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayLocalMoveY(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.localPosition.y,to, (value, tween) =>
            {
                var newValue = target.localPosition;
                newValue.y = value;
                target.localPosition = newValue;
            },() => 0,target));
        }
        
        //------------------ Move Z -----------------------
        public static TweenFloat PlayMoveZ(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.position;
                newValue.z = value;
                target.position = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayMoveZ(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.position.z,to, (value, tween) =>
            {
                var newValue = target.position;
                newValue.z = value;
                target.position = newValue;
            },() => 0,target));
        }
        
        //------------------ Local Move Z -----------------------
        public static TweenFloat PlayLocalMoveZ(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.localPosition;
                newValue.z = value;
                target.localPosition = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayLocalMoveZ(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.localPosition.z,to, (value, tween) =>
            {
                var newValue = target.localPosition;
                newValue.z = value;
                target.localPosition = newValue;
            },() => 0,target));
        }
        
        //------------------ Rotate Quaternion -----------------------
        public static TweenQuaternion PlayRotateQuaternion(this Transform target,Quaternion from, Quaternion to,float duration)
        {
            return PlayTween.AddTween(new TweenQuaternion(duration,from,to, (value, tween) =>
            {
                target.rotation = value;
            },() => Quaternion.identity, target));
        }
        
        public static TweenQuaternion PlayRotateQuaternion(this Transform target, Quaternion to,float duration)
        {
            return PlayTween.AddTween(new TweenQuaternion(duration,target.rotation,to, (value, tween) =>
            {
                target.rotation = value;
            },() => Quaternion.identity,target));
        }
        
        //------------------ Local Rotate Quaternion -----------------------
        public static TweenQuaternion PlayLocalRotateQuaternion(this Transform target,Quaternion from, Quaternion to,float duration)
        {
            return PlayTween.AddTween(new TweenQuaternion(duration,from,to, (value, tween) =>
            {
                target.localRotation = value;
            },() => Quaternion.identity,target));
        }
        
        public static TweenQuaternion PlayLocalRotateQuaternion(this Transform target, Quaternion to,float duration)
        {
            return PlayTween.AddTween(new TweenQuaternion(duration,target.localRotation,to, (value, tween) =>
            {
                target.localRotation = value;
            },() => Quaternion.identity,target));
        }

        //------------------ Rotate Vector3 -----------------------
        public static TweenVector3 PlayRotate(this Transform target,Vector3 from, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,from,to, (value, tween) =>
            {
                target.rotation = Quaternion.Euler(value);
            },() => Vector3.zero, target));
        }
        
        public static TweenVector3 PlayRotate(this Transform target, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,target.rotation.eulerAngles,to, (value, tween) =>
            {
                target.rotation = Quaternion.Euler(value);
            },() => Vector3.zero,target));
        }
        
        //------------------ Local Rotate Vector3 -----------------------
        public static TweenVector3 PlayLocalRotate(this Transform target,Vector3 from, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,from,to, (value, tween) =>
            {
                target.localRotation = Quaternion.Euler(value);
            },() => Vector3.zero,target));
        }
        
        public static TweenVector3 PlayLocalRotate(this Transform target, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,target.localRotation.eulerAngles,to, (value, tween) =>
            {
                target.localRotation = Quaternion.Euler(value);
            },() => Vector3.zero,target));
        }

        //------------------ Scale -----------------------
        public static TweenVector3 PlayScale(this Transform target,Vector3 from, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,from,to, (value, tween) =>
            {
                target.localScale = value;
            },() => Vector3.zero,target));
        }
        
        public static TweenVector3 PlayScale(this Transform target, Vector3 to,float duration)
        {
            return PlayTween.AddTween(new TweenVector3(duration,target.localScale,to, (value, tween) =>
            {
                target.localScale = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ Scale X -----------------------
        public static TweenFloat PlayScaleX(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.localScale;
                newValue.x = value;
                target.localScale = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayScaleX(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.localScale.x,to, (value, tween) =>
            {
                var newValue = target.localScale;
                newValue.x = value;
                target.localScale = newValue;
            },() => 0,target));
        }
        
        //------------------ Scale Y -----------------------
        public static TweenFloat PlayScaleY(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.localScale;
                newValue.y = value;
                target.localScale = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayScaleY(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.localScale.y,to, (value, tween) =>
            {
                var newValue = target.localScale;
                newValue.y = value;
                target.localScale = newValue;
            },() => 0,target));
        }
        
        //------------------ Scale Z -----------------------
        public static TweenFloat PlayScaleZ(this Transform target,float from, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,from,to, (value, tween) =>
            {
                var newValue = target.localScale;
                newValue.z = value;
                target.localScale = newValue;
            },() => 0,target));
        }
        
        public static TweenFloat PlayScaleZ(this Transform target, float to,float duration)
        {
            return PlayTween.AddTween(new TweenFloat(duration,target.localScale.z,to, (value, tween) =>
            {
                var newValue = target.localScale;
                newValue.z = value;
                target.localScale = newValue;
            },() => 0,target));
        }
        
        //------------------ Punch Scale -----------------------
        public static TweenPunch PlayPunchScale(this Transform target,Vector3 amount,float duration)
        {
            return PlayTween.AddTween(new TweenPunch(duration,target.localScale,amount, (value, tween) =>
            {
                target.localScale = value;
            },() => Vector3.zero,target));
        }
        
        //------------------ Punch Rotation -----------------------
        public static TweenPunch PlayPunchRotation(this Transform target,Vector3 amount,float duration)
        {
            return PlayTween.AddTween(new TweenPunch(duration,target.rotation.eulerAngles,amount, (value, tween) =>
            {
                target.rotation = Quaternion.Euler(value);
            },() => Vector3.zero,target));
        }

    }
}
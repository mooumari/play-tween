using System;
using UnityEngine;

namespace PT
{
    public static class EaseLibrary
    {
        public static Func<float,float> GetLerpMethod(EaseType easeType)
        {
            return easeType switch
            {
                EaseType.Linear => EaseLinear,
                
                EaseType.InSine => EaseInSine,
                EaseType.OutSine => EaseOutSine,
                EaseType.InOutSine => EaseInOutSine,
                
                EaseType.InQuad => EaseInQuad,
                EaseType.OutQuad => EaseOutQuad,
                EaseType.InOutQuad => EaseInOutQuad,
                
                EaseType.InBack => EaseInBack,
                EaseType.OutBack => EaseOutBack,
                EaseType.InOutBack => EaseInOutBack,
                
                EaseType.InCubic => EaseInCubic,
                EaseType.OutCubic => EaseOutCubic,
                EaseType.InOutCubic => EaseInOutCubic,

                EaseType.InBounce => EaseInBounce,
                EaseType.OutBounce => EaseOutBounce,
                EaseType.InOutBounce => EaseInOutBounce,
                
                EaseType.InQuint => EaseInQuint,
                EaseType.OutQuint => EaseOutQuint,
                EaseType.InOutQuint => EaseInOutQuint,
                
                EaseType.InCirc => EaseInCirc,
                EaseType.OutCirc => EaseOutCirc,
                EaseType.InOutCirc => EaseInOutCirc,
                
                EaseType.InElastic => EaseInElastic,
                EaseType.OutElastic => EaseOutElastic,
                EaseType.InOutElastic => EaseInOutElastic,
                
                EaseType.InExpo => EaseInExpo,
                EaseType.OutExpo => EaseOutExpo,
                EaseType.InOutExpo => EaseInOutExpo,
                
                EaseType.InQuart => EaseInQuart,
                EaseType.OutQuart => EaseOutQuart,
                EaseType.InOutQuart => EaseInOutQuart,
                _ => EaseLinear
            };
        }

        public static float LerpEasing(float t, EaseType easeType)
        {
            return easeType switch
            {
                EaseType.Linear => EaseLinear(t),
                
                EaseType.InSine => EaseInSine(t),
                EaseType.OutSine => EaseOutSine(t),
                EaseType.InOutSine => EaseInOutSine(t),
                
                EaseType.InQuad => EaseInQuad(t),
                EaseType.OutQuad => EaseOutQuad(t),
                EaseType.InOutQuad => EaseInOutQuad(t),
                
                EaseType.InBack => EaseInBack(t),
                EaseType.OutBack => EaseOutBack(t),
                EaseType.InOutBack => EaseInOutBack(t),
                
                EaseType.InCubic => EaseInCubic(t),
                EaseType.OutCubic => EaseOutCubic(t),
                EaseType.InOutCubic => EaseInOutCubic(t),

                EaseType.InBounce => EaseInBounce(t),
                EaseType.OutBounce => EaseOutBounce(t),
                EaseType.InOutBounce => EaseInOutBounce(t),
                
                EaseType.InQuint => EaseInQuint(t),
                EaseType.OutQuint => EaseOutQuint(t),
                EaseType.InOutQuint => EaseInOutQuint(t),
                
                EaseType.InCirc => EaseInCirc(t),
                EaseType.OutCirc => EaseOutCirc(t),
                EaseType.InOutCirc => EaseInOutCirc(t),
                
                EaseType.InElastic => EaseInElastic(t),
                EaseType.OutElastic => EaseOutElastic(t),
                EaseType.InOutElastic => EaseInOutElastic(t),
                
                EaseType.InExpo => EaseInExpo(t),
                EaseType.OutExpo => EaseOutExpo(t),
                EaseType.InOutExpo => EaseInOutExpo(t),
                
                EaseType.InQuart => EaseInQuart(t),
                EaseType.OutQuart => EaseOutQuart(t),
                EaseType.InOutQuart => EaseInOutQuart(t),
                
                _ => 0f
            };
        }

        public static float EaseLinear(float t) => Mathf.LerpUnclamped(0,1,t);
    
        //Sine
        public static float EaseInSine(float t) => 1 - Mathf.Cos((t * Mathf.PI) / 2f);
        public static float EaseOutSine(float t) => Mathf.Sin((t * Mathf.PI) / 2);
        public static float EaseInOutSine(float t) => -(Mathf.Cos(Mathf.PI * t) - 1) / 2;
    
        //Cubic
        public static float EaseInCubic(float t) => t * t * t;
        public static float EaseOutCubic(float t) => 1 - Mathf.Pow(1 - t, 3);
        public static float EaseInOutCubic(float t) => t < 0.5 ? 4 * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 3) / 2;
    
        //Quint
        public static float EaseInQuint(float t) => t * t * t * t * t;
        public static float EaseOutQuint(float t) => 1 - Mathf.Pow(1 - t, 5);
        public static float EaseInOutQuint(float t) => t < 0.5 ? 16 * t * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 5) / 2;
        
        //Circ
        public static float EaseInCirc(float t) => 1 - Mathf.Sqrt(1 - Mathf.Pow(t, 2));
        public static float EaseOutCirc(float t) => Mathf.Sqrt(1 - Mathf.Pow(t - 1, 2));
        public static float EaseInOutCirc(float t)
        {
            return t < 0.5
                ? (1 - Mathf.Sqrt(1 - Mathf.Pow(2 * t, 2))) / 2
                : (Mathf.Sqrt(1 - Mathf.Pow(-2 * t + 2, 2)) + 1) / 2;
        }
        
        //Elastic
        public static float EaseInElastic(float t)
        {
            const float c4 = (2 * Mathf.PI) / 3f;

            return t == 0
                ? 0
                : t >= 1
                    ? 1
                    : -Mathf.Pow(2, 10 * t - 10) * Mathf.Sin((t * 10 - 10.75f) * c4);
        }
        public static float EaseOutElastic(float t)
        {
            const float c4 = (2 * Mathf.PI) / 3;

            return t == 0
                ? 0
                : t >= 1
                    ? 1
                    : Mathf.Pow(2, -10 * t) * Mathf.Sin((t * 10 - 0.75f) * c4) + 1;
        }
        public static float EaseInOutElastic(float t)
        {
            const float c5 = (2 * Mathf.PI) / 4.5f;

            return t == 0
                ? 0
                : t >= 1
                    ? 1
                    : t < 0.5
                        ? -(Mathf.Pow(2, 20 * t - 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2
                        : (Mathf.Pow(2, -20 * t + 10) * Mathf.Sin((20 * t - 11.125f) * c5)) / 2 + 1;
        }
        
        //Quart
        public static float EaseInQuart(float t) => t * t * t * t;
        public static float EaseOutQuart(float t) => 1 - Mathf.Pow(1 - t, 4);
        public static float EaseInOutQuart(float t) => t < 0.5 ? 8 * t * t * t * t : 1 - Mathf.Pow(-2 * t + 2, 4) / 2;

        
        //Expo
        public static float EaseInExpo(float t) => t == 0 ? 0 : Mathf.Pow(2, 10 * t - 10);
        public static float EaseOutExpo(float t) => t >= 1 ? 1 : 1 - Mathf.Pow(2, -10 * t);
        public static float EaseInOutExpo(float t)
        {
            return t == 0
                ? 0
                : t >= 1
                    ? 1
                    : t < 0.5 ? Mathf.Pow(2, 20 * t - 10) / 2
                        : (2 - Mathf.Pow(2, -20 * t + 10)) / 2;
        }

        //Quad
        public static float EaseInQuad(float t) => t * t;
        public static float EaseOutQuad(float t) => 1 - (1 - t) * (1 - t);
        public static float EaseInOutQuad(float t) => t < 0.5 ? 2 * t * t : 1 - Mathf.Pow(-2 * t + 2, 2) / 2;
    
        //Back
        public static float EaseInBack(float t)
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1;

            return c3 * t * t * t - c1 * t * t;
        }
        public static float EaseOutBack(float t)
        {
            const float c1 = 1.70158f;
            const float c3 = c1 + 1;

            return 1 + c3 * Mathf.Pow(t - 1, 3) + c1 * Mathf.Pow(t - 1, 2);
        }
        public static float EaseInOutBack(float t)
        {
            const float c1 = 1.70158f;
            const float c2 = c1 * 1.525f;

            return t < 0.5
                ? (Mathf.Pow(2 * t, 2) * ((c2 + 1) * 2 * t - c2)) / 2
                : (Mathf.Pow(2 * t - 2, 2) * ((c2 + 1) * (t * 2 - 2) + c2) + 2) / 2;
        }

        //Bounce
        public static float EaseInBounce(float t) => 1 - EaseOutBounce(1 - t);
        public static float EaseOutBounce(float t)
        {
            const float n1 = 7.5625f;
            const float d1 = 2.75f;

            if (t < 1 / d1) {
                return n1 * t * t;
            } else if (t < 2f / d1) {
                return n1 * (t -= 1.5f / d1) * t + 0.75f;
            } else if (t < 2.5f / d1) {
                return n1 * (t -= 2.25f / d1) * t + 0.9375f;
            } else {
                return n1 * (t -= 2.625f / d1) * t + 0.984375f;
            }
        }
        
        public static float EaseInOutBounce(float t)
        {
            return t < 0.5
                ? (1 - EaseOutBounce(1 - 2 * t)) / 2
                : (1 + EaseOutBounce(2 * t - 1)) / 2;
        }
    
    }
}
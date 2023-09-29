using UnityEngine;

namespace PT
{
    public enum EaseDataType
    {
        Ease = 0,
        AnimationCurve = 1,
    }
    
    [System.Serializable]
    public class EaseData
    {
        public EaseDataType easeDataType;
        public AnimationCurve animationCurve = AnimationCurve.Linear(0,0,1,1);
        public EaseType easeType = EaseType.Linear;

        public EaseData()
        {
            easeDataType = EaseDataType.Ease;
            animationCurve = AnimationCurve.Linear(0,0,1,1);
            easeType = EaseType.Linear;
        }
        
        public EaseData(AnimationCurve animationCurve)
        {
            easeDataType = EaseDataType.AnimationCurve;
            this.animationCurve = animationCurve;
        }

        public EaseData(EaseType easeType)
        {
            easeDataType = EaseDataType.Ease;
            this.easeType = easeType;
        }
        
    }
}
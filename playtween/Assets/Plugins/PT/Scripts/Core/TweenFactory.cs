using UnityEngine;

namespace PT
{
    public static class TweenFactory<K,T> where T:class,K,new() 
    {
        public static K GetTween()
        {
            K o = new T();
            return o;
        }
    }
}
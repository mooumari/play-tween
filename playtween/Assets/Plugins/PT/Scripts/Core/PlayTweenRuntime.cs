using System;
using UnityEngine;

namespace PT
{
    public class PlayTweenRuntime : MonoBehaviour
    {
        private static PlayTweenRuntime Instance { get; set; }

        //------------------ Unity -----------------------
        private void Awake()
        {
            if (SetupSingleton())
            {
                
            }
        }

        private void Update()
        {
            PlayTween.Update(Time.deltaTime);
        }
        
        //------------------ Setup -----------------------
        private bool SetupSingleton()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                return true;
            }

            Destroy(gameObject);
            return false;
        }
    }
}
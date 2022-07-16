using System;
using UnityEngine;

namespace JoyTeam.Game
{
    [Serializable]
    public struct EntryData
    {
        [SerializeField] private Camera worldCamera;
        [SerializeField] private BaseScreen logoScreen;
        [SerializeField] private float time; 
            
        public Camera WorldCamera => worldCamera;
        public BaseScreen LogoScreen => logoScreen;
        public float Time => time;
    }
}
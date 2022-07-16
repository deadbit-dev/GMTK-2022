using System;
using UnityEngine;
using UnityEngine.Rendering;

namespace JoyTeam.Game
{
    [Serializable]
    public struct GameData
    {
        [SerializeField] private Camera worldCamera;
        [SerializeField] private Light directionLight;
        [SerializeField] private Volume postProcessing;
        
        public Camera WorldCamera => worldCamera;
        public Light DirectionLight => directionLight;
        public Volume PostProcessing => postProcessing;
    }
}
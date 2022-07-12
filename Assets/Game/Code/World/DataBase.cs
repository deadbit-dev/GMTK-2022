using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

namespace JoyTeam.Game
{
    [CreateAssetMenu(fileName = "DataBase", menuName = "DataBase")]
    public class DataBase : ScriptableObject
    {
        [Header("Environment")]
        [SerializeField] private Light directionLight;
        [SerializeField] private Volume postProcessing;
        
        [Header("Output")]
        [SerializeField] private Camera worldCamera;
        [SerializeField] private Camera uiCamera;
        [SerializeField] private Canvas canvas;

        public Light DirectionLight => directionLight;
        public Volume PostProcessing => postProcessing;
    }
}
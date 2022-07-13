using UnityEngine;
using UnityEngine.Rendering;

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
        [SerializeField] private Canvas ui;

        public Light DirectionLight => directionLight;
        public Volume PostProcessing => postProcessing;
        public Camera WorldCamera => worldCamera;
        public Camera UICamera => uiCamera;
        public Canvas UI => ui;
    }
}
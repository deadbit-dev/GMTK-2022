using PlasticPipe.PlasticProtocol.Client;
using UnityEngine;
using UnityEngine.EventSystems;
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
        [SerializeField] private Camera overlayCamera;
        [SerializeField] private Canvas userInterface;

        public Transform Root { get; set; }

        public Light DirectionLight => directionLight;
        public Volume PostProcessing => postProcessing;
        public Camera WorldCamera => worldCamera;
        public Camera OverlayCamera => overlayCamera;
        public Canvas UserInterface => userInterface;
    }
}
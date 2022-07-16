using UnityEngine;

namespace JoyTeam.Game
{
    [CreateAssetMenu(fileName = "SharedData", menuName = "SharedData")]
    public class SharedData : ScriptableObject
    {
        [SerializeField] private EntryData entry;
        [SerializeField] private GameData game;
        [Space]
        [SerializeField] private Camera overlayCamera;
        [Header("Transition")]
        [SerializeField] private Animator transition;
        [SerializeField] private float transitionTime;

        public Transform Root { get; set; }
        public EntryData Entry => entry;
        public GameData Game => game;
        public Camera OverlayCamera => overlayCamera;
        public Animator Transition => transition;
        public float TransitionTime => transitionTime;
    }
}
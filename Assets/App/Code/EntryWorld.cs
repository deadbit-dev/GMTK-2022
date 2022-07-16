using Leopotam.EcsLite;
using UnityEngine;

namespace JoyTeam.Game
{
    internal sealed class EntryWorld : MonoBehaviour
    {
        [SerializeField] private SharedData sharedData;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            sharedData.Root = transform;
            
            _world = new EcsWorld ();
            _systems = new EcsSystems(_world, sharedData);
            _systems
                .Add(new SetEntryWorldCameraSystem())
                .Add(new SetOverlayCameraSystem())
                .Add(new SetLogoScreenSystem())
                .Add(new SwitchSceneSystem())
                .Add(new TransitionSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Init();
        }

        private void Update()
        {
            _systems?.Run();
        }

        private void OnDestroy()
        {
            if (_systems != null) 
            {
                _systems.Destroy ();
                _systems = null;
            }
            
            if (_world != null) 
            {
                _world.Destroy ();
                _world = null;
            }
        }
    }
}
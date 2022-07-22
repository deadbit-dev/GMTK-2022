using System;
using UnityEngine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace JoyTeam.Game
{
    internal sealed class EntryWorld : MonoBehaviour
    {
        [SerializeField] private StaticData staticData;
        [SerializeField] private TransitionData transitionData;

        private EcsWorld _world;
        private EcsWorld _eventsWorld;
        private EcsSystems _systems;

        private ITimeService _timeService;
        private ISceneService _sceneService;

        private void Start()
        {
            _timeService = new UnityTimeService();
            _sceneService = new UnitySceneService();

            _world = new EcsWorld ();
            _eventsWorld = new EcsWorld();
            
            _systems = new EcsSystems(_world);
            _systems
                .AddWorld(_eventsWorld, Constants.EventsWorld)
                .Add(new LogoScreenSystem())
                .Add(new SwitchSceneSystem())
                .Add(new TransitionSystem())
                .Add(new TimerSystem())
#if UNITY_EDITOR
                .Add(new Leopotam.EcsLite.UnityEditor.EcsWorldDebugSystem())
#endif
                .Inject( staticData, transitionData)
                .Inject(_timeService, _sceneService)
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
                _systems.Destroy();
                _systems = null;
            }

            if (_world != null) 
            {
                _world.Destroy();
                _world = null;
            }

            if (_eventsWorld != null)
            {
                _eventsWorld.Destroy();
                _eventsWorld = null;
            }
        }
    }
}
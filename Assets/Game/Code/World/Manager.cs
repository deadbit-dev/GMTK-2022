using Leopotam.EcsLite;
using UnityEngine;

namespace JoyTeam.Game
{
    internal sealed class Manager : MonoBehaviour
    {
        [SerializeField] private DataBase dataBase;

        private EcsWorld _world;
        private EcsSystems _systems;

        private void Start()
        {
            _world = new EcsWorld ();
            _systems = new EcsSystems(_world, dataBase)
                .Add(new SetEnvironmentSystem())
                .Add(new SetOutputSystem());
            _systems.Init();
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
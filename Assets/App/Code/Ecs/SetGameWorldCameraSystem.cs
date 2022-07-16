using Leopotam.EcsLite;
using UnityEngine;

namespace JoyTeam.Game
{
    internal class SetGameWorldCameraSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var data = systems.GetShared<SharedData>();
            
            var world = systems.GetWorld();
            
            var worldCameraEntity = world.NewEntity();
            
            var worldCamera = Object.Instantiate(data.Game.WorldCamera, data.Root);
            worldCamera.name = data.Game.WorldCamera.name;
            
            var worldCameraRefPool = world.GetPool<WorldCameraRef>();
            
            ref var worldCameraRef = ref worldCameraRefPool.Add(worldCameraEntity);
            worldCameraRef.Value = worldCamera;
        }
    }
}
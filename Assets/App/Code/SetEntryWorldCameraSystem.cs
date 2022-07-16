using Leopotam.EcsLite;
using UnityEngine;

namespace JoyTeam.Game
{
    internal class SetEntryWorldCameraSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var data = systems.GetShared<SharedData>();
            
            var world = systems.GetWorld();
            
            var worldCameraEntity = world.NewEntity();
            
            var worldCamera = Object.Instantiate(data.Entry.WorldCamera, data.Root);
            worldCamera.name = data.Entry.WorldCamera.name;
            worldCamera.backgroundColor = Color.white;

            var worldCameraRefPool = world.GetPool<WorldCameraRef>();
            
            ref var worldCameraRef = ref worldCameraRefPool.Add(worldCameraEntity);
            worldCameraRef.Value = worldCamera;
        }
    }
}
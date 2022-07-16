using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace JoyTeam.Game
{
    internal class SetOverlayCameraSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var data = systems.GetShared<SharedData>();
            
            var world = systems.GetWorld();
            
            var filter = world.Filter<WorldCameraRef>().End();
            
            var overlayCameraEntity = world.NewEntity();
            
            var overlayCamera = Object.Instantiate(data.OverlayCamera, data.Root);
            overlayCamera.name = data.OverlayCamera.name;

            var worldCameraRefPool = world.GetPool<WorldCameraRef>();
            var overlayCameraRefPool = world.GetPool<OverlayCameraRef>();
            
            ref var overlayCameraRef = ref overlayCameraRefPool.Add(overlayCameraEntity);
            overlayCameraRef.Value = overlayCamera;

            foreach (var entity in filter)
            {
                ref var worldCamera = ref worldCameraRefPool.Get(entity); 
                worldCamera.Value.GetUniversalAdditionalCameraData().cameraStack.Add(overlayCamera);
            }
        }
    }
}
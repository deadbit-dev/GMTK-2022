using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace JoyTeam.Game
{
    internal class SetOutputSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var dataBase = systems.GetShared<DataBase>();
            
            var world = systems.GetWorld();
            
            var worldCameraEntity = world.NewEntity();
            var overlayCameraEntity = world.NewEntity();
            var userInterfaceEntity = world.NewEntity();

            var worldCamera = Object.Instantiate(dataBase.WorldCamera, dataBase.Root);
            var overlayCamera = Object.Instantiate(dataBase.OverlayCamera, dataBase.Root);
            var userInterface = Object.Instantiate(dataBase.UserInterface, dataBase.Root);

            worldCamera.name = dataBase.WorldCamera.name;
            worldCamera.GetUniversalAdditionalCameraData().cameraStack.Add(overlayCamera);
            overlayCamera.name = dataBase.OverlayCamera.name;
            userInterface.name = dataBase.UserInterface.name;
            userInterface.worldCamera = overlayCamera;

            var worldCameraRefPool = world.GetPool<WorldCameraRef>();
            var overlayCameraRefPool = world.GetPool<OverlayCameraRef>();
            var userInterfaceRefPool = world.GetPool<UserInterfaceRef>();

            ref var worldCameraRef = ref worldCameraRefPool.Add(worldCameraEntity);
            ref var overlayCameraRef = ref overlayCameraRefPool.Add(overlayCameraEntity);
            ref var userInterfaceRef = ref userInterfaceRefPool.Add(userInterfaceEntity);

            worldCameraRef.Value = worldCamera;
            overlayCameraRef.Value = overlayCamera;
            userInterfaceRef.Value = userInterface;
        }
    }
}
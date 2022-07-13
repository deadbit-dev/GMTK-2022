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
            
            var worldCamera = world.NewEntity();
            var uiCamera = world.NewEntity();
            var ui = world.NewEntity();

            var worldCameraView = Object.Instantiate(dataBase.WorldCamera);
            var uiCameraView = Object.Instantiate(dataBase.UICamera);
            var uiView = Object.Instantiate(dataBase.UI);

            worldCameraView.GetUniversalAdditionalCameraData().cameraStack.Add(uiCameraView);
            uiView.worldCamera = uiCameraView;

            var worldCameraViewRefPool = world.GetPool<WorldCameraViewRef>();
            var uiCameraViewRefPool = world.GetPool<UICameraViewRef>();
            var uiViewRefPool = world.GetPool<UIViewRef>();

            ref var worldCameraViewRef = ref worldCameraViewRefPool.Add(worldCamera);
            ref var uiCameraViewRef = ref uiCameraViewRefPool.Add(uiCamera);
            ref var uiViewRef = ref uiViewRefPool.Add(ui);

            worldCameraViewRef.Value = worldCameraView;
            uiCameraViewRef.Value = uiCameraView;
            uiViewRef.Value = uiView;
        }
    }
}
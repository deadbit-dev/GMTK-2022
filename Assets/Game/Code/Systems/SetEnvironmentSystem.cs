using Leopotam.EcsLite;
using UnityEngine;

namespace JoyTeam.Game
{
    internal class SetEnvironmentSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var dataBase = systems.GetShared<DataBase>();
            
            var world = systems.GetWorld();
            
            var directionLight = world.NewEntity();
            var postProcessing = world.NewEntity();

            var directionLightView = Object.Instantiate(dataBase.DirectionLight);
            var postProcessingView = Object.Instantiate(dataBase.PostProcessing);

            var directionLightViewRefPool = world.GetPool<DirectionLightViewRef>();
            var postProcessingViewRefPool = world.GetPool<PostProcessingViewRef>();

            ref var directionLightViewRef = ref directionLightViewRefPool.Add(directionLight);
            ref var postProcessingViewRef = ref postProcessingViewRefPool.Add(postProcessing);

            directionLightViewRef.Value = directionLightView;
            postProcessingViewRef.Value = postProcessingView;
        }
    }
}
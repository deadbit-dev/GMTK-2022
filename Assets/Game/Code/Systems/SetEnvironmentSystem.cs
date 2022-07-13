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
            
            var directionLightEntity = world.NewEntity();
            var postProcessingEntity = world.NewEntity();
            
            var directionLight = Object.Instantiate(dataBase.DirectionLight, dataBase.Root);
            var postProcessing = Object.Instantiate(dataBase.PostProcessing, dataBase.Root);

            directionLight.name = dataBase.DirectionLight.name;
            postProcessing.name = dataBase.PostProcessing.name;

            var directionLightRefPool = world.GetPool<DirectionLightRef>();
            var postProcessingRefPool = world.GetPool<PostProcessingRef>();

            ref var directionLightRef = ref directionLightRefPool.Add(directionLightEntity);
            ref var postProcessingRef = ref postProcessingRefPool.Add(postProcessingEntity);

            directionLightRef.Value = directionLight;
            postProcessingRef.Value = postProcessing;
        }
    }
}
using Leopotam.EcsLite;
using UnityEngine;

namespace JoyTeam.Game
{
    internal class SetEnvironmentSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var data = systems.GetShared<SharedData>();
            
            var world = systems.GetWorld();
            
            var directionLightEntity = world.NewEntity();
            var postProcessingEntity = world.NewEntity();
            
            var directionLight = Object.Instantiate(data.Game.DirectionLight, data.Root);
            var postProcessing = Object.Instantiate(data.Game.PostProcessing, data.Root);

            directionLight.name = data.Game.DirectionLight.name;
            postProcessing.name = data.Game.PostProcessing.name;

            var directionLightRefPool = world.GetPool<DirectionLightRef>();
            var postProcessingRefPool = world.GetPool<PostProcessingRef>();

            ref var directionLightRef = ref directionLightRefPool.Add(directionLightEntity);
            ref var postProcessingRef = ref postProcessingRefPool.Add(postProcessingEntity);

            directionLightRef.Value = directionLight;
            postProcessingRef.Value = postProcessing;
        }
    }
}
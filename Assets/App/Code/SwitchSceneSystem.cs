using System.Collections;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JoyTeam.Game
{
    public class SwitchSceneSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var data = systems.GetShared<SharedData>();
            var world = systems.GetWorld();

            var filter = world.Filter<SwitchSceneEvent>().End();
            var switchSceneEventPool = world.GetPool<SwitchSceneEvent>();
            
            foreach (var entity in filter)
            {
                world.GetPool<TransitionEvent>().Add(world.NewEntity()).Value = TransitionType.Hide;
                //SceneManager.LoadScene(switchSceneEventPool.Get(entity).SceneIndex);
                switchSceneEventPool.Del(entity);
            }
        }
    }
}
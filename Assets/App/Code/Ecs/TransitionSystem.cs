using Leopotam.EcsLite;
using UnityEngine;

namespace JoyTeam.Game
{
    internal class TransitionSystem : IEcsInitSystem, IEcsRunSystem
    {
        public void Init(EcsSystems systems)
        {
            var data = systems.GetShared<SharedData>();
            var world = systems.GetWorld();

            var entity = world.NewEntity();
            
            var animator = Object.Instantiate(data.Transition, data.Root);
            animator.name = data.Transition.name;

            ref var transition = ref world.GetPool<Transition>().Add(entity);
            transition.Value = animator;
        }

        public void Run(EcsSystems systems)
        {
            var data = systems.GetShared<SharedData>();
            var world = systems.GetWorld();

            var transitionEventFilter = world.Filter<TransitionEvent>().End();
            var transitionFilter = world.Filter<Transition>().End();
            
            var transitionEventPool = world.GetPool<TransitionEvent>();
            var transitionPool = world.GetPool<Transition>();
            
            foreach (var transitionEventEntity in transitionEventFilter)
            {
                ref var transitionEvent = ref transitionEventPool.Get(transitionEventEntity);
                
                foreach (var transitionEntity in transitionFilter)
                {
                    ref var transition = ref transitionPool.Get(transitionEntity);

                    switch (transitionEvent.Value)
                    {
                        case TransitionType.Hide:
                            transition.Value.SetTrigger("hide");
                            break;
                        case TransitionType.Show:
                            transition.Value.SetTrigger("show");
                            break;
                    }
                }
                
                transitionEventPool.Del(transitionEventEntity);
            }
        }
    }
}
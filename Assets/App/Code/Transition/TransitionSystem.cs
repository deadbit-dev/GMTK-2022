using UnityEngine;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace JoyTeam.Game
{
    internal class TransitionSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = Constants.EventsWorld;
        
        private readonly EcsFilterInject<Inc<TransitionEvent>> _filter = Constants.EventsWorld;
        
        private readonly EcsPoolInject<TransitionEvent> _pool = Constants.EventsWorld;
        
        private readonly EcsCustomInject<TransitionData> _data = default;

        public void Run(EcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                switch (_pool.Value.Get(entity).Type)
                {
                    case TransitionType.Hide:
                        _data.Value.transition.SetTrigger("hide");
                        break;
                    case TransitionType.Show:
                        _data.Value.transition.SetTrigger("show");
                        break;
                }

                _world.Value.DelEntity(entity);
            }
        }
    }
}
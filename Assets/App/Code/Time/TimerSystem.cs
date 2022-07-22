using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace JoyTeam.Game
{
    public class TimerSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = Constants.EventsWorld;
        
        private readonly EcsFilterInject<Inc<Timer>> _filter = Constants.EventsWorld;
        private readonly EcsFilterInject<Inc<Timer, TimerEndEvent>> _delFilter = Constants.EventsWorld;
        
        private readonly EcsPoolInject<Timer> _timerPool = Constants.EventsWorld;
        private readonly EcsPoolInject<TimerEndEvent> _timerEndEventPool = Constants.EventsWorld;
        
        private readonly EcsCustomInject<ITimeService> _timeService = default;

        public void Run(EcsSystems systems)
        {
            foreach (var entity in _delFilter.Value)
            {
                _world.Value.DelEntity(entity);
            }

            foreach (var entity in _filter.Value)
            {
                ref var timer = ref _timerPool.Value.Get(entity);
                timer.TimeLeft -= _timeService.Value.DeltaTime;

                if (timer.TimeLeft <= 0)
                {
                    _timerEndEventPool.Value.Add(entity);
                }
            }
        }
    }
}
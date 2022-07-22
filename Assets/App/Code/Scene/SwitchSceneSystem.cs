using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;

namespace JoyTeam.Game
{
    public class SwitchSceneSystem : IEcsRunSystem
    {
        private readonly EcsWorldInject _world = Constants.EventsWorld;
        
        private readonly EcsFilterInject<Inc<SwitchSceneEvent>, Exc<Timer, TimerEndEvent>> _filterIn = Constants.EventsWorld;
        private readonly EcsFilterInject<Inc<SwitchSceneEvent, Timer, TimerEndEvent>> _filterOut = Constants.EventsWorld;
        
        private readonly EcsPoolInject<SwitchSceneEvent> _switchSceneEventPool = Constants.EventsWorld;
        private readonly EcsPoolInject<TransitionEvent> _transitionEventPool = Constants.EventsWorld;
        private readonly EcsPoolInject<Timer> _timerPool = Constants.EventsWorld;
        
        private readonly EcsCustomInject<TransitionData> _transitionData = default;
        private readonly EcsCustomInject<ISceneService> _sceneService = default;

        public void Run(EcsSystems systems)
        {
            foreach (var entity in _filterIn.Value)
            {
                _transitionEventPool.Value.Add(_world.Value.NewEntity()).Type = TransitionType.Hide;
                
                ref var timer = ref _timerPool.Value.Add(entity);
                timer.TimeLeft = _transitionData.Value.transitionTime;
            }

            foreach (var entity in _filterOut.Value)
            {
                _sceneService.Value.SwitchScene(_switchSceneEventPool.Value.Get(entity).SceneIndex);
            }
        }
    }
}
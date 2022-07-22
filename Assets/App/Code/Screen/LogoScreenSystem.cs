using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine.SceneManagement;

namespace JoyTeam.Game
{
    internal class LogoScreenSystem : IEcsInitSystem, IEcsRunSystem
    {
        private readonly EcsWorldInject _world = Constants.EventsWorld;
        
        private readonly EcsFilterInject<Inc<LogoScreenTag, Timer, TimerEndEvent>> _filter = Constants.EventsWorld;
        
        private readonly EcsPoolInject<Timer> _timerPool = Constants.EventsWorld;
        private readonly EcsPoolInject<LogoScreenTag> _logoScreenTagPool = Constants.EventsWorld;
        private readonly EcsPoolInject<SwitchSceneEvent> _switchSceneEventPool = Constants.EventsWorld;
        
        private readonly EcsCustomInject<StaticData> _staticData = default;
        private readonly EcsCustomInject<ISceneService> _sceneService = default;

        public void Init(EcsSystems systems)
        {
            var entity = _world.Value.NewEntity();
            _logoScreenTagPool.Value.Add(entity);
            
            ref var timer = ref _timerPool.Value.Add(entity);
            timer.TimeLeft = _staticData.Value.entryTime;
        }

        public void Run(EcsSystems systems)
        {
            foreach (var entity in _filter.Value)
            {
                ref var switchSceneEvent = ref _switchSceneEventPool.Value.Add(_world.Value.NewEntity());
                switchSceneEvent.SceneIndex = _sceneService.Value.GetNextScene();
            }
        }
    }
}
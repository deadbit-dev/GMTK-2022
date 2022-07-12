using Leopotam.EcsLite;

namespace JoyTeam.Game
{
    internal class SetEnvironmentSystem : IEcsRunSystem
    {
        public void Run(EcsSystems systems)
        {
            var dataBase = systems.GetShared<DataBase>();
        }
    }
}
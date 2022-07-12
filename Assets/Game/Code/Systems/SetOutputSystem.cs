using Leopotam.EcsLite;

namespace JoyTeam.Game
{
    internal class SetOutputSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var dataBase = systems.GetShared<DataBase>();
        }
    }
}
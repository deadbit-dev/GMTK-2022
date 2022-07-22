using UnityEngine;

namespace JoyTeam.Game
{
    public class UnityTimeService : ITimeService
    {
        public float DeltaTime => Time.deltaTime;
    }
}
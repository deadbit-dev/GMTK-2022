using System.Collections;
using Leopotam.EcsLite;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace JoyTeam.Game
{
    internal class SetLogoScreenSystem : IEcsInitSystem
    {
        public void Init(EcsSystems systems)
        {
            var data = systems.GetShared<SharedData>();
            var world = systems.GetWorld();
            
            var logoScreenEntity = world.NewEntity();
            
            var logoScreen = Object.Instantiate(data.Entry.LogoScreen, data.Root);
            logoScreen.name = data.Entry.LogoScreen.name;

            ref var screenRef = ref world.GetPool<ScreenRef>().Add(logoScreenEntity);
            screenRef.Value = logoScreen;

            ref var switchSceneEvent = ref world.GetPool<SwitchSceneEvent>().Add(world.NewEntity());
            switchSceneEvent.SceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            switchSceneEvent.TransitionTime = data.TransitionTime;
        }
    }
}
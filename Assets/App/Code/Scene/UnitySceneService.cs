using UnityEngine.SceneManagement;

namespace JoyTeam.Game
{
    public class UnitySceneService : ISceneService
    {
        public void SwitchScene(int index) => SceneManager.LoadScene(index);
        public int GetCurrentScene() => SceneManager.GetActiveScene().buildIndex;
        public int GetNextScene() => GetCurrentScene() + 1;
    }
}
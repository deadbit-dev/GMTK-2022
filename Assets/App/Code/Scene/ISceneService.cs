namespace JoyTeam.Game
{
    public interface ISceneService
    {
        void SwitchScene(int index);
        int GetCurrentScene();
        int GetNextScene();
    }
}
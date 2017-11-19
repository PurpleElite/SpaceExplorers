namespace SpaceExplorers
{
    public struct SceneEventReturn
    {
        public bool Pause;

        public SceneEventReturn(bool pause)
        {
            Pause = pause;
        }
    }

    public interface ISceneEvent
    {
        SceneEventReturn Execute(Scene parent);
    }
}
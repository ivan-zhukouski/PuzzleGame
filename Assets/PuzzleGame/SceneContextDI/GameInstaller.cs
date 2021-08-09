using GameStateMachine;
using PuzzleGame.GameStateMachine;
using PuzzleGame.GameStateMachine.PlayGameState;
using PuzzleGame.GameStateMachine.StartGameState;
using PuzzleGame.GameStateMachine.WinGameState;
using PuzzleGame.GUI;
using PuzzleGame.Managers;
using Zenject;

namespace PuzzleGame.SceneContextDI
{ 
    public class GameInstaller : ScriptableObjectInstaller<GameInstaller>
    {
        public override void InstallBindings()
        {
            BindStateMachine();
            BindGameManager();
            BindGui();
        }
        private void BindStateMachine()
        {
            Container.Bind<IState>().To<StartState>().AsCached();
            Container.Bind<IState>().To<PlayState>().AsCached();
            Container.Bind<IState>().To<WinState>().AsCached();
            Container.Bind<CallBackState>().AsCached();
            Container.BindInterfacesAndSelfTo<StateMachine>().AsSingle().NonLazy();
        }
        private void BindGameManager()
        {
            Container.BindInterfacesAndSelfTo<GameManager>().AsSingle();
        }
        private void BindGui()
        {
            Container.Bind<GuiHandler>().FromComponentInHierarchy(true).AsSingle();
        }
    }
}
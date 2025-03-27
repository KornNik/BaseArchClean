using Behaviours;
using Helpers.Extensions;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Behaviours.Initializers
{
    sealed class ComponentsInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;
        [SerializeField] private GameStateBehaviour _gameStateBeh;
        public override void InstallBindings()
        {
            BindCamera();
            BindLevelLoader();
            BindGameState();
        }
        private void BindCamera()
        {
            var mainCamera = Container.
                InstantiatePrefabForComponent<Camera>(_camera).
                With(camera => camera.transform.position = Vector3.zero).
                With(camera => camera.transform.rotation = Quaternion.identity);
        }
        private void BindLevelLoader()
        {
            Container.Bind<LevelLoader>().FromNew().AsSingle().NonLazy();
        }
        private void BindGameState()
        {
            var gameStateContr = Container.
                InstantiatePrefabForComponent<GameStateBehaviour>(_gameStateBeh);
            Container.BindInterfacesTo<GameStateBehaviour>().AsSingle().NonLazy();
        }
        private void BindScreenFactory()
        {

        }
    }
}

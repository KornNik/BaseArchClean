using Controllers;
using Data;
using Helpers;
using Helpers.AssetsPath;
using UnityEngine;
using Zenject;

namespace Behaviours
{
    sealed class SystemsInstaller : MonoInstaller
    {
        [SerializeField] private AudioController _audioController;

        public override void InstallBindings()
        {
            BindData();
            BindSettings();
            BindTimeController();
            BindAudio();
            BindInputs();
        }

        private void BindData()
        {
            var data = Container.InstantiateScriptableObjectResource<DatasBundle>
                (DatasAssetPath.DatasPath[Helpers.DataTypes.BundleData]);
            Container.QueueForInject(data);
            Container.Bind<DataResourcePrefabs>().FromScriptableObject(data.GetData<DataResourcePrefabs>()).AsSingle().NonLazy();
            Container.Bind<DatasBundle>().FromScriptableObject(data).AsSingle().NonLazy();

            Services.Instance.DatasBundle.SetObject(data);
            Services.Instance.DataResourcePrefabs.SetObject(data.GetData<DataResourcePrefabs>());
        }
        private void BindSettings()
        {
            Container.BindInterfacesTo<SettingsController>().AsSingle().NonLazy();
        }
        private void BindTimeController()
        {
            Container.BindInterfacesTo<TimeController>().AsSingle().NonLazy();
        }
        private void BindAudio()
        {
            Container.InstantiatePrefabForComponent<AudioController>(_audioController);
        }
        private void BindInputs()
        {
            Container.Bind<InputLoader>().FromNew().AsSingle().NonLazy();
        }
    }
}

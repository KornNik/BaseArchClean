using Data;
using Helpers.AssetsPath;
using Helpers.Extensions;
using Helpers;
using System.Threading.Tasks;

namespace Behaviours
{
    sealed class DataInitializerAsync : IInitializationAsync
    {
        private DatasBundle _datasBundle;

        public async Task InitializationAsync()
        {
            _datasBundle = CustomResources.Load<DatasBundle>(DatasAssetPath.DatasPath[DataTypes.BundleData]);
            Services.Instance.DatasBundle.SetObject(_datasBundle);
            Services.Instance.DataResourcePrefabs.SetObject(_datasBundle.GetData<DataResourcePrefabs>());

            await Task.Yield();
        }
    }
}

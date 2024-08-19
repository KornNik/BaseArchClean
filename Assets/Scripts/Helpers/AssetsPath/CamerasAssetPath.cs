using System.Collections.Generic;
using Helpers.Extensions;

namespace Helpers.AssetsPath
{
    sealed class CamerasAssetPath
    {
        public static Dictionary<CameraTypes, string> CamerasPath = new Dictionary<CameraTypes, string>
        {
            {
                CameraTypes.MainCamera, StringBuilderExtender.CreateString
                (ResourcesPathManager.CAMERA_FOLDER,ResourcesPathManager.CAMERA_MAIN_NAME) 
            }
        };
    }
}
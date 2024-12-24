using Helpers.Extensions;
using UnityEngine;

namespace Data
{
    enum TweenSettingsType
    {
        None,
        ScreenDefaultSettings
    }

    [CreateAssetMenu(fileName = "TweenBundleData", menuName = "Data/Tween/TweenBundle")]
    sealed class TweensSettingsBundle : ScriptableObject
    {
        [SerializeField] private SerializableDictionary<TweenSettingsType, TweenSettings> _tweenSettings;

        public TweenSettings GetTweenSettings(TweenSettingsType settingsType)
        {
            TweenSettings settings = null;
            if (_tweenSettings.Contains(settingsType))
            {
                settings = _tweenSettings[settingsType];
            }
            return settings;
        }
    }
}

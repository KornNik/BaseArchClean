using Data;
using System;
using System.Collections.Generic;

namespace Behaviours
{
    sealed class SaveDataKeysProvider : IKeysProvider
    {
        private readonly IReadOnlyDictionary<Type, string> _repo =
            new Dictionary<Type, string>
            {
                { typeof(SaveData), "SaveData" },
                { typeof(SettingsData), "SettingsData" },
                { typeof(AudioData), "AudioData" },
            };

        public string Provide<TData>() => _repo[typeof(TData)];
        public IEnumerable<string> ProvideAll() => _repo.Values;
    }
}

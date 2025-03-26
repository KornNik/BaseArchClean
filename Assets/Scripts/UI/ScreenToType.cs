using UnityEngine;
using Helpers;
using System.Collections.Generic;
using System;

namespace UI
{
    sealed class ScreenToType
    {
        private readonly IReadOnlyDictionary<Type, ScreenTypes> _repo = new Dictionary<Type, ScreenTypes>
    {
                { typeof(LoadingScreen), ScreenTypes.LoadingScreen },
                { typeof(MainMenu), ScreenTypes.MainMenu },
                { typeof(GameMenu), ScreenTypes.GameMenu },
                { typeof(Canvas), ScreenTypes.Canvas },
    };

        public ScreenTypes Provide<TType>() => _repo[typeof(TType)];
        public IEnumerable<ScreenTypes> ProvideAll() => _repo.Values;
    }
}
using JetBrains.Annotations;
using System.Collections.Generic;

namespace Behaviours
{
    interface IKeysProvider
    {
        [NotNull] string Provide<TType>();
        [NotNull, ItemNotNull] IEnumerable<string> ProvideAll();
    }
}

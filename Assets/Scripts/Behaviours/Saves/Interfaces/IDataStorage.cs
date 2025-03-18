using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using System.Collections.Generic;
using System;

namespace Behaviours
{
    interface IDataStorage : IDisposable
    {
        UniTask<bool> ExistsAsync([CanBeNull] string key);

        UniTask<IEnumerable<KeyValuePair<string, string>>> ReadAsync([NotNull, ItemNotNull] IReadOnlyCollection<string> keys);
        UniTask<string> ReadAsync([NotNull] string key);

        UniTask WriteAsync([NotNull] IReadOnlyCollection<KeyValuePair<string, string>> serializedData);
        UniTask WriteAsync([NotNull] string key, [NotNull] string serializedData);

        UniTask DeleteAsync([NotNull, ItemNotNull] IReadOnlyCollection<string> keys);
        UniTask DeleteAsync([NotNull] string key);
    }
}

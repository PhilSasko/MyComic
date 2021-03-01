using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyComic.Utilities
{
    public static class EnumerableExtensions
    {
        public static bool TryOffsetBy<TEntity>(
            this IEnumerable<TEntity> entities, 
            Func<TEntity, int> idSelector, 
            int startId, 
            int idOffset, 
            out TEntity offsetEntity) where TEntity : class
        {
            offsetEntity = entities.SingleOrDefault(entity => idSelector(entity) == startId + idOffset);
            return !(offsetEntity is null);
        }
    }
}

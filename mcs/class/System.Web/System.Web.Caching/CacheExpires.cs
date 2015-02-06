using System;

namespace System.Web.Caching
{	
	internal class CacheExpires
	{
		internal static readonly TimeSpan MIN_UPDATE_DELTA = new TimeSpan (0, 0, 1);

		internal CacheExpires (CacheSingle cacheSingle) {
			throw new NotImplementedException ();
		}
		
		internal int FlushExpiredItems (bool useInsertBlock) {
			throw new NotImplementedException ();
		}

		internal void EnableExpirationTimer (bool enable) {
		}

		internal void Add (CacheEntry cacheEntry) {
		}

		internal void Remove (CacheEntry cacheEntry) {
		}

		internal void UtcUpdate (CacheEntry cacheEntry, DateTime utcNewExpires) {
		}
	}
}

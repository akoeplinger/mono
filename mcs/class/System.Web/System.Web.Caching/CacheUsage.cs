using System;

namespace System.Web.Caching
{	
	internal class CacheUsage
	{
		internal static readonly TimeSpan NEWADD_INTERVAL = new TimeSpan (0, 0, 10);
		internal static readonly TimeSpan CORRELATED_REQUEST_TIMEOUT = new TimeSpan (0, 0, 1);
		internal static readonly TimeSpan MIN_LIFETIME_FOR_USAGE = CacheUsage.NEWADD_INTERVAL;

		internal CacheUsage (CacheSingle cacheSingle) {
			throw new NotImplementedException ();
		}

		internal void Add (CacheEntry cacheEntry) {
		}

		internal void Remove (CacheEntry cacheEntry) {
		}

		internal void Update (CacheEntry cacheEntry) {
		}

		internal int FlushUnderUsedItems (int toFlush, ref int publicEntriesFlushed, ref int ocEntriesFlushed) {
			throw new NotImplementedException ();
		}
	}
}

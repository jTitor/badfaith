namespace BadFaith.Math
{
	public static class Hashing
	{
		/**
		FNV hash
		 */
		public static uint FnvHash(uint[] keys)
		{
			uint hash = 2166136261;
			//We want the hash to overflow by wrapping.
			unchecked
			{
				foreach (uint k in keys)
				{
					hash = (hash * 16777619) ^ k;
				}
			}

			return hash;
		}
	}
}
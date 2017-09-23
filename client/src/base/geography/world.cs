using System.Collections.Generic;

namespace BadFaith.Geography
{
	public class World
	{
		public Vector2I Dimensions;
		public List<Sector> Sectors;

		public void AddSector(Sector s)
		{ Sectors.Add(s); }
	}
}
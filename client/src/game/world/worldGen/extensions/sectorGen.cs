using System.Collections.Generic;
using BadFaith.Geography;
using BadFaith.Geography.Fields;

namespace BadFaith.World.WorldGen
{
	public static class XWorldGeneratorSectorMethods
	{
		private static List<Sector> makeSectorColumn(this WorldGenerator cls, int columnLength)
		{
			List<Sector> result = new List<Sector>() { new Sector() };
			for (int i = 1; i < columnLength; ++i)
			{
				result.Add(new Sector());
				result[i - 1].LinkTo(result[i], Direction.North);
			}
			return result;
		}

		/**
		Links column1's west gates to column2's
		east gates.
		*/
		private static void linkSectorColumn(this WorldGenerator cls, List<Sector> column1, List<Sector> column2)
		{
			for (int i = 0; i < column1.Count; ++i)
			{
				Sector currentSector1 = column1[i];
				Sector currentSector2 = column2[i];
				currentSector1.LinkTo(currentSector2, Direction.West);
			}
		}

		private static void generateSectorsForWorld(this WorldGenerator cls, Geography.World world)
		{
			if (world.Dimensions.X * world.Dimensions.Y > WorldGenConstants.SectorNames.Length)
			{ throw new WorldGenError("Trying to generate more sectors than have unique names!"); }

			List<List<Sector>> sectorColumns = new List<List<Sector>>();
			sectorColumns.Add(cls.makeSectorColumn(world.Dimensions.Y));
			for (int i = 1; i < world.Dimensions.X; ++i)
			{
				sectorColumns.Add(cls.makeSectorColumn(world.Dimensions.Y));
				cls.linkSectorColumn(sectorColumns[i], sectorColumns[i - 1]);
			}
			//Now complete the loop.
			cls.linkSectorColumn(sectorColumns[0], sectorColumns[world.Dimensions.X - 1]);
			foreach (List<Sector> col in sectorColumns)
			{
				foreach (Sector sector in col)
				{ world.AddSector(sector); }
			}

			//Do naming and other characterization here.
			List<int> usedNameIndices = new List<int>();
			foreach (Sector sector in world.Sectors)
			{ sector.Name = WorldGenerator.RandomNameWithUsedList(WorldGenConstants.SectorNames, usedNameIndices); }
		}
	}
}
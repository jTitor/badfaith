using System.Collections.Generic;
using BadFaith.Geography;

namespace BadFaith.World.WorldGen
{
	public static class XWorldGeneratorZoneMethods
	{
		public static void generateZonesForSector(WorldGenerator cls, Sector sector, int size)
		{//Size is the n'th odd number.
			int zoneRadius = 2 * size - 1;
			//Max out at size 3 since there's not enough unique names
			//at that point.
			if (size > 2)
			{ throw new WorldGenError("Trying to generate more zones than have unique names!"); }
			if (size < 0)
			{ throw new WorldGenError("Size is out of bounds!"); }

			List<Zone> sectorZones = new List<Zone>();
			if (size == 1)
			{
				//Just place the one zone and link it
				//to all of the gates.
				Zone zone = new Zone();
				foreach (Direction direction in Directions.All)
				{ zone.LinkTo(sector.GateZones[direction.Value], direction); }
				sectorZones.Add(zone);
			}
			else
			{
				List<List<Zone>> columns = new List<List<Zone>>();
				//Create the zone columns...
				for (int i = 0; i < zoneRadius; ++i)
				{
					Zone columnStartZone = new Zone();
					sectorZones.Add(columnStartZone);
					List<Zone> column = new List<Zone>() { columnStartZone };
					int columnLength = max((2 * i + 1, zoneRadius));
					for (int j = 1; j < columnLength; ++j)
					{
						Zone zone = new Zone();
						column.Add(zone);
						sectorZones.Add(zone);
						column[j - 1].LinkTo(column[j], Direction.North);
					}
					columns.Add(column);
				}
				//Link the columns together...
				for (int i = 1; i < columns.Count; ++i)
				{
					List<Zone> currColumn = columns[i];
					List<Zone> prevColumn = columns[i - 1];
					int minLength = min(prevColumn.Count, currColumn.Count);
					int currMid = currColumn.Count / 2;
					int prevMid = prevColumn.Count / 2;
					for (int j = 0; j < minLength; ++j)
					{ currColumn[currMid - (minLength / 2) + j].LinkTo(prevColumn[prevMid - (minLength / 2) + j], Direction.West); }
				}
			}

			foreach (Zone zone in sectorZones)
			{ sector.AddZone(zone); }

			//Actually describe the sectors here.
			List<int> usedNameIndices = new List<int>();
			foreach (Zone zone in sector.Zones)
			{
				zone.Name = WorldGenerator.RandomNameWithUsedList(WorldGenConstants.ZoneNames, usedNameIndices);
				assert zone.name;
			}
		}
	}
}
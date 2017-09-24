using System.Collections.Generic;
using BadFaith.Geography;
using BadFaith.World.WorldGen;

namespace BadFaith.World.WorldGen
{
	public class WorldGenerator
	{
		/**
		Generates a full random name,
		then adds it to the list of used
		names. This tries to pick a name
		that wasn't used before.
		 */
		public static string RandomNameWithUsedList(string[] nameList, List<int> usedIndexList)
		{
			int namesLen = nameList.Length;
			int nameIndex = random.randint(0, namesLen - 1);
			while (usedIndexList.Contains(nameIndex))
			{ nameIndex = random.randint(0, namesLen - 1); }
			usedIndexList.Add(nameIndex);
			return nameList[nameIndex];
		}

		/**
		Returns a new randomly-generated world.
		*/
		public static Geography.World GenerateWorld()
		{
			Geography.World world = new Geography.World();
			world.Dimensions = new Vector2I(8, 3);
			//Generate the sectors.
			WorldGenerator.generateSectorsForWorld(world);
			//Now do the zones...
			foreach (Sector s in world.Sectors)
			{
				WorldGenerator.generateZonesForSector(s, random.randint(1, 2));
				//Now do the fields.
				WorldGenerator.generateFieldsForSector(s, 20);
			}

			return world;
		}
	}
}
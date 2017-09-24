using System.Collections.Generic;
using BadFaith.Geography;
using BadFaith.Geography.Fields;

namespace BadFaith.World.WorldGen
{
	public static class XWorldGeneratorFieldMethods
	{
		private static void generateFieldsForSector(this WorldGenerator cls, Sector sector, int maxNumNewFields)
		{
			//Add size asserts for the name limit for now.
			int namesLen = WorldGenConstants.FieldNames.Length;
			//Remember that every field will have at minimum 4 gate fields.
			if (maxNumNewFields + 4 > namesLen)
			{ throw new WorldGenError("Trying to generate more fields than have unique names!"); }

			foreach (Zone zone in sector.Zones)
			{
				//Add new fields here.
				int numNewFields = random.randint(3, maxNumNewFields);
				for (int i = 0; i < numNewFields; ++i)
				{
					Field newField = new Field();
					//Vary the grid size.
					newField.GridSize = random.randint(10, 30);
					zone.AddField(newField);
				}
				List<int> usedNameIndices = new List<int>();
				foreach (Field field in zone.Fields)
				{
					//Give a name.
					field.Name = WorldGenerator.RandomNameWithUsedList(WorldGenConstants.FieldNames, usedNameIndices);
					assert field.name
				}
			}
		}
	}
}
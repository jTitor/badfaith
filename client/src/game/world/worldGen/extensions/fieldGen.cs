namespace BadFaith.WorldGen
{
	public static class XWorldGeneratorFieldMethods
	{
		@classmethod
	def _generateFieldsForSector(cls, sector, maxNumNewFields):
		#Add size asserts for the name limit for now.
		namesLen = len(WorldGen.FieldNames)
		if maxNumNewFields+4 > namesLen:
			raise WorldGenError("Trying to generate more fields than have unique names!")

		for zone in sector.zones:
			assert isinstance(zone, Zone)
			#Add new fields here.
			numNewFields = random.randint(3, maxNumNewFields)
			for i in range(0, numNewFields):
				newField = Field()
				#Vary the grid size.
				newField.gridSize = random.randint(10, 30)
				zone.addField(newField)
			usedNameIndices = []
			for field in zone.fields:
				#Give a name.
				field.name = randomNameWithUsedList(WorldGen.FieldNames, usedNameIndices)
				assert field.name
	}
}
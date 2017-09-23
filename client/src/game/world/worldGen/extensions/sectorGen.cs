namespace BadFaith.WorldGen
{
	public static class XWorldGeneratorSectorMethods
	{
		@classmethod
	def _makeSectorColumn(cls, columnLength):
		result = [Sector()]
		for i in range(1, columnLength):
			result.append(Sector())
			result[i-1].linkTo(result[i], Directions.North)
		return result

	@classmethod
	def _linkSectorColumn(cls, column1, column2):
		'''Links column1's west gates to column2's
		east gates.
		'''
		for i in range(0, len(column1)):
			currentSector1 = column1[i]
			currentSector2 = column2[i]
			assert isinstance(currentSector1, Sector)
			assert isinstance(currentSector2, Sector)
			currentSector1.linkTo(currentSector2, Directions.West)

	@classmethod
	def _generateSectorsForWorld(cls, world):
		if world.width * world.height > len(WorldGen.SectorNames):
			raise WorldGenError("Trying to generate more sectors than have unique names!")

		sectorColumns = []
		sectorColumns.append(cls._makeSectorColumn(world.height))
		for i in range(1, world.width):
			sectorColumns.append(cls._makeSectorColumn(world.height))
			cls._linkSectorColumn(sectorColumns[i], sectorColumns[i-1])
		#Now complete the loop.
		cls._linkSectorColumn(sectorColumns[0], sectorColumns[world.width-1])
		for col in sectorColumns:
			for sector in col:
				world.addSector(sector)

		#Do naming and other characterization here.
		usedNameIndices = []
		for sector in world.sectors:
			sector.name = randomNameWithUsedList(WorldGen.SectorNames, usedNameIndices)
	}
}
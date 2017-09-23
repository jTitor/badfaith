namespace BadFaith.World.WorldGen
{
	public static class XWorldGeneratorZoneMethods
	{
		@classmethod
	def _generateZonesForSector(cls, sector, size):
		#Size is the n'th odd number.
		zoneRadius = 2*size-1
		#Max out at size 3 since there's not enough unique names
		#at that point.
		if size > 2:
			raise WorldGenError("Trying to generate more zones than have unique names!")
		if size < 0:
			raise WorldGenError("Size is out of bounds!")

		sectorZones = []
		if size == 1:
			#Just place the one zone and link it
			#to all of the gates.
			assert isinstance(sector, Sector)
			zone = Zone()
			for direction in Directions.All:
				zone.linkTo(sector.gateZones[direction.value], direction)
			sectorZones.append(zone)
		else:
			columns = []
			#Create the zone columns...
			for i in range(0, zoneRadius):
				columnStartZone = Zone()
				sectorZones.append(columnStartZone)
				column = [columnStartZone]
				columnLength = max((2*i+1, zoneRadius))
				for j in range(1, columnLength):
					zone = Zone()
					column.append(zone)
					sectorZones.append(zone)
					column[j-1].linkTo(column[j], Directions.North)
				columns.append(column)
			#Link the columns together...
			for i in range(1, len(columns)):
				currColumn = columns[i]
				prevColumn = columns[i-1]
				minLength = min(len(prevColumn), len(currColumn))
				currMid = len(currColumn) / 2
				prevMid = len(prevColumn) / 2
				for j in range(0, minLength):
					currColumn[currMid-(minLength/2)+j].linkTo(prevColumn[prevMid-(minLength/2)+j], Directions.West)

		for zone in sectorZones:
			sector.addZone(zone)

		#Actually describe the sectors here.
		usedNameIndices = []
		for zone in sector.zones:
			zone.name = randomNameWithUsedList(WorldGen.ZoneNames, usedNameIndices)
			assert zone.name
	}
}
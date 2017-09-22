namespace BadFaith.World
{
	public class WorldGenerator
	{
		/**
		Generates a full random name,
		then adds it to the list of used
		names. This tries to pick a name
		that wasn't used before.
		 */
		def randomNameWithUsedList(nameList, usedIndexList):
	namesLen = len(nameList)
	nameIndex = random.randint(0, namesLen-1)
	while nameIndex in usedIndexList:
		nameIndex = random.randint(0, namesLen-1)
	usedIndexList.append(nameIndex)
	return(nameList[nameIndex])

class WorldGen(object):
	'''
	'''

	@classmethod
	def generateWorld(cls):
		'''Returns a new randomly-generated world.
		'''
		world = World()
		world.width = 8
		world.height = 3
		#Generate the sectors.
		cls._generateSectorsForWorld(world)
		#Now do the zones...
		for s in world.sectors:
			cls._generateZonesForSector(s, random.randint(1, 2))
			#Now do the fields.
			cls._generateFieldsForSector(s, 20)

		return world
	}
}
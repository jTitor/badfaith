class Sector(object):
	'''
	'''

	'''The table of all sectors in use.
	Each sector has an ID that is also its index into this array.
	All[0] is a null element that isn't connected to anything and can't be entered.
	'''
	All = []

	def __init__(self):
		self.name = "SECTOR_NAME_UNSET"
		#The zones contained by this sector.
		self.zones = []
		self.sectorID = len(Sector.All)
		Sector.All.append(self)
		#The inter-sector zones; these are the ways
		#in and out of the sector.
		#The zones correspond to the cardinal directions;
		#That zone's gate in that direction jumps to the
		#destination sector's opposite direction gate zone,
		#in the opposite direction gate.
		self.gateZones = (Zone(), Zone(), Zone(), Zone())
		for zone in self.gateZones:
			self.addZone(zone)

	def _doAddZone(self, zone):
		assert isinstance(zone, Zone)
		zone.owningSectorID = self.sectorID
		#Fix up any reverse-lookup tables.
		self.zones.append(zone)
		#raise NotImplementedError

	def addZone(self, zone):
		'''Makes the given zone a member of this sector.
		If `zone` is a tuple, all zones inside of the
		tuple are added.
		'''
		if hasattr(zone, '__iter__'):
			for z in zone:
				self._doAddZone(z)
		else:
			self._doAddZone(zone)

	def fullName(self):
		return self.name

	def linkTo(self, other, direction):
		'''Connects this sector to another zone's sector in the given direction.
		Raises WorldGenError if either sector has a connection that
		would be overriden by this connection.
		'''
		sourceGateZone = self.gateZones[direction.value]
		destinationGateZone = other.gateZones[Directions.opposite(direction).value]
		sourceGate = sourceGateZone.gates[direction.value]
		destinationGate = destinationGateZone.gates[Directions.opposite(direction).value]
		if sourceGate.destinationFieldID != 0:
			raise WorldGenError("Source gate already connected to another sector!")
		if destinationGate.destinationFieldID != 0:
			raise WorldGenError("Destination gate already connected to another sector!")
		sourceGate.linkTo(destinationGate)
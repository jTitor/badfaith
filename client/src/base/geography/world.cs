class World(object):
	def __init__(self):
		self.sectors = []
		self.width = 0
		self.height = 0

	def addSector(self, sector):
		self.sectors.append(sector)

using System.Collections.Generic;
using BadFaith.Geography.Fields;

namespace BadFaith.Geography
{
	public class Sector
	{
		private static List<Sector> all = new List<Sector>();
		/**The table of all sectors in use.
		Each sector has an ID that is also its index into this array.
		All[0] is a null element that isn't connected to anything and can't be entered.
		*/
		public static List<Sector> All { get { return all; } }
		private int sectorId;
		public int SectorId { get { return sectorId; } }
		public string Name;
		private List<Zone> zones = new List<Zone>();
		/**
		The zones contained by this sector.
		*/
		public List<Zone> Zones { get { return zones; } }
		private Zone[] gateZones;
		public Zone[] GateZones { get { return gateZones; } }

		public Sector()
		{
			Name = "SECTOR_NAME_UNSET";
			sectorId = Sector.All.Count;
			Sector.All.Add(this);
			//The inter-sector zones; these are the ways
			//in and out of the sector.
			//The zones correspond to the cardinal directions;
			//That zone's gate in that direction jumps to the
			//destination sector's opposite direction gate zone,
			//in the opposite direction gate.
			gateZones = new Zone[] { new Zone(), new Zone(), new Zone(), new Zone() };
			foreach (Zone z in gateZones)
			{
				AddZone(z);
			}
		}

		private void doAddZone(Zone zone)
		{
			zone.OwningSectorId = sectorId;
			//Fix up any reverse-lookup tables.
			zones.Add(zone);
			//throw new NotImplementedException()
		}
		/**
		Makes the given zone a member of this sector.
		If `zone` is a tuple, all zones inside of the
		tuple are added.
		*/
		public void AddZone(IEnumerable<Zone> zones)
		{
			foreach (Zone z in zones)
			{ doAddZone(z); }
		}
		public void AddZone(Zone zone)
		{
			AddZone(new Zone[] { zone });
		}

		public string FullName()
		{
			return Name;
		}

		/**
		Connects this sector to another zone's sector in the given direction.
		Raises WorldGenError if either sector has a connection that
		would be overriden by this connection.
		*/
		public void LinkTo(Sector other, Direction direction)
		{
			Zone sourceGateZone = gateZones[direction.Value];
			Zone destinationGateZone = other.gateZones[direction.Opposite().Value];
			Gate sourceGate = sourceGateZone.Gates[direction.Value];
			Gate destinationGate = destinationGateZone.Gates[direction.Opposite().Value];
			if (sourceGate.DestinationFieldId != 0)
			{ throw new WorldGenError("Source gate already connected to another sector!"); }
			if (destinationGate.DestinationFieldId != 0)
			{ throw new WorldGenError("Destination gate already connected to another sector!"); }
			sourceGate.LinkTo(destinationGate);
		}
	}
}
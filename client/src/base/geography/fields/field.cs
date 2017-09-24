/**
 */
using System;
using System.Collections.Generic;

namespace BadFaith.Geography.Fields
{
	public class Field
	{
		/**
		The table of all fields in use.
		Each field has an ID that is also its index into this array.
		All[0] is a null element that isn't connected to anything and can't be entered.
		*/
		private static List<Field> _all = new List<Field>();
		public static List<Field> All { get { return _all; } }
		public void InitFields(int numFields)
		{
			throw new NotImplementedException("Implement null element initialization");
		}

		protected enum FieldType
		{
			Generic,
			Gate
		}

		public string Name;
		public List<int> Actors;
		public int FieldId;
		public int OwningZoneId;
		//Fields are square grids.
		public int GridSize;
		protected FieldType Type;

		public Field()
		{
			throw new System.NotImplementedException();
			Name = "FIELD_NAME_UNSET";
			Actors = new List<int>();
			FieldId = Field.All.Count;
			OwningZoneId = 0;
			//Fields are square grids.
			GridSize = 10;
			Type = FieldType.Generic;
			_all.Add(this);
		}

		public string FullName
		{
			get
			{
				throw new NotImplementedException();
				// owningZone = Zone.All[self.owningZoneId]
				// owningSector = Sector.All[owningZone.owningSectorId]
				// return "{0} {1}".format(owningZone.fullName(), self.name)
			}
		}

		public int coordinateAsIndex(Vector2I coordinate)
		{
			throw new System.NotImplementedException();
			/**
			Converts the coordinates to an array index.
			*/
			// return coordinateTuple.value[1] * self.gridSize + coordinateTuple.value[0]
		}

		public bool coordinateIsValid(Vector2I coordinate)
		{
			throw new System.NotImplementedException();
			/**
			Returns True if the given coordinates are in the field's range,
			False otherwise.
			*/
			// return coordinateTuple.value[0] < self.gridSize and coordinateTuple.value[1] < self.gridSize
		}
	}
}
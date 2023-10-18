using System;

namespace Stand_Launchpad
{
	internal class DropDownEntry
	{
		public int Id { get; set; }

		public string Name { get; set; }

		public DropDownEntry(int id, string name)
		{
			this.Id = id;
			this.Name = name;
		}
	}
}

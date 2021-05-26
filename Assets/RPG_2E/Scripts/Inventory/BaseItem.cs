using System;
using UnityEngine;

namespace com.noorcon.rpg2e
{
	[Serializable]
	public class BaseItem
	{
		public enum ItemCatrgory
		{
			Weapon = 0,
			Armour = 1,
			Clothing = 2,
			Health = 3,
			Potion = 4
		}

		[SerializeField]
		private string name;
		[SerializeField]
		private string description;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}

		public string Description
		{
			get { return description; }
			set { description = value; }
		}
	}
}
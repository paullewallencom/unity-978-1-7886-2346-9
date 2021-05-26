using System;
using UnityEngine;

namespace com.noorcon.rpg2e
{
	[Serializable]
	public class InventoryItem : BaseItem
	{
		public enum ItemType
		{
			Helmet = 0,
			Shield = 1,
			ShoulderPad = 2,
			KneePad = 3,
			Shoes = 4,
			Weapon = 5,
			LegPlate = 6
		}
		
		[SerializeField]
		private ItemCatrgory category;
		[SerializeField]
		private ItemType type;
		[SerializeField]
		private float strength;
		[SerializeField]
		private float weight;

		public ItemCatrgory Category
		{
			get { return category; }
			set { category = value; }
		}

		public ItemType Type
		{
			get { return type; }
			set { type = value; }
		}

		public float Strength
		{
			get { return strength; }
			set { strength = value; }
		}

		public float Weight
		{
			get { return weight; }
			set { weight = value; }
		}

		public void CopyInventoryItem(InventoryItem item)
		{
			Category = item.Category;
			Type = item.Type;
			Description = item.Description;
			Name = item.Name;
			Strength = item.Strength;
			Weight = item.Weight;
		}
	}
}
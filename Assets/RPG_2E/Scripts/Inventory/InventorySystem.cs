using System;
using System.Collections.Generic;
using UnityEngine;

namespace com.noorcon.rpg2e
{
	[Serializable]
	public class InventorySystem
	{
		[SerializeField]
		private List<InventoryItem> weapons
			= new List<InventoryItem>();
		[SerializeField]
		private List<InventoryItem> armour 
			= new List<InventoryItem>();
		[SerializeField]
		private List<InventoryItem> clothing 
			= new List<InventoryItem>();
		[SerializeField]
		private List<InventoryItem> health 
			= new List<InventoryItem>();
		[SerializeField]
		private List<InventoryItem> potion 
			= new List<InventoryItem>();

		public List<InventoryItem> Weapons
		{
			get { return weapons; }
		}

		public List<InventoryItem> Armour
		{
			get { return armour; }
		}

		public List<InventoryItem> Clothing
		{
			get { return clothing; }
		}

		public List<InventoryItem> Health
		{
			get { return health; }
		}

		public List<InventoryItem> Potion
		{
			get { return potion; }
		}

		private InventoryItem selectedWeapon;
		private InventoryItem selectedArmour;

		public InventoryItem SelectedWeapon
		{
			get { return selectedWeapon; }
			set { selectedWeapon = value; }
		}
		public InventoryItem SelectedArmour
		{
			get { return selectedArmour; }
			set { selectedArmour = value; }
		}

		public InventorySystem()
		{
			ClearInventory();
		}

		public void ClearInventory()
		{
			weapons.Clear();
			armour.Clear();
			clothing.Clear();
			health.Clear();
			potion.Clear();
		}

		// this function will add an inventory item
		public void AddItem(InventoryItem item)
		{
			switch (item.Category)
			{
				case BaseItem.ItemCatrgory.Armour:
					{
						armour.Add(item);
						break;
					}
				case BaseItem.ItemCatrgory.Clothing:
					{
						clothing.Add(item);
						break;
					}
				case BaseItem.ItemCatrgory.Health:
					{
						health.Add(item);
						GameMaster.instance.Ui.AddSpecialInventoryItem(item);
						break;
					}
				case BaseItem.ItemCatrgory.Potion:
					{
						potion.Add(item);
						break;
					}
				case BaseItem.ItemCatrgory.Weapon:
					{
						weapons.Add(item);
						break;
					}
			}
		}

		// this function will remove an inventory item
		public void DeleteItem(InventoryItem item)
		{
			switch (item.Category)
			{
				case BaseItem.ItemCatrgory.Armour:
					{
						armour.Remove(item);
						break;
					}
				case BaseItem.ItemCatrgory.Clothing:
					{
						clothing.Remove(item);
						break;
					}
				case BaseItem.ItemCatrgory.Health:
					{
						// let's find the item and mark it for removal
						InventoryItem tmp = null;
						foreach (InventoryItem i in this.health)
						{
							if (item.Category.Equals(i.Category) 
								&& item.Name.Equals(i.Name) 
								&& item.Strength.Equals(i.Strength))
							{
								tmp = i;
							}
						}

						health.Remove(tmp);
						break;
					}
				case BaseItem.ItemCatrgory.Potion:
					{
						// let's find the item and mark it for removal
						InventoryItem tmp = null;
						foreach (InventoryItem i in this.health)
						{
							if (item.Category.Equals(i.Category) 
								&& item.Name.Equals(i.Name) 
								&& item.Strength.Equals(i.Strength))
							{
								tmp = i;
							}
						}

						potion.Remove(tmp);
						break;
					}
				case BaseItem.ItemCatrgory.Weapon:
					{
						weapons.Remove(item);
						break;
					}
			}
		}
	}
}
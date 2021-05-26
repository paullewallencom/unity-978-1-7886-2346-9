using System;
using UnityEngine;
using UnityEngine.Networking;

namespace com.noorcon.rpg2e
{
	public class InventoryItemAgentNetwork : NetworkBehaviour
	{
		public InventoryItem Item;

		public void OnTriggerEnter(Collider c)
		{
			// make sure we are colliding with the player
			if (c.gameObject.tag.Equals("Player"))
			{
				// Make a copy of the Inventory Item Object
				InventoryItem myItem = new InventoryItem();
				myItem.CopyInventoryItem(Item);

				//GameMasterNetwork.instance.PlayerCharacterData.SelectedArmour = myItem;
				GameMasterNetwork.instance.PlayerCharacterData.SelectedWeapon
							= (PlayerCharacter.WeaponType)Enum.Parse(
									typeof(PlayerCharacter.WeaponType), myItem.Name);
				GameMasterNetwork.instance.PlayerWeaponChanged(c.gameObject, myItem); // PlayerArmourChanged(myItem);				

				// Add the item to our inventory
				GameMasterNetwork.instance.Inventory.AddItem(myItem);

				// Destroy the GameObject from the scene
				GameMasterNetwork.instance.RpgDestroy(gameObject);
			}
		}
	}
}
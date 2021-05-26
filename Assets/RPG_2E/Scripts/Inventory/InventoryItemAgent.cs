using UnityEngine;

namespace com.noorcon.rpg2e
{
	public class InventoryItemAgent : MonoBehaviour
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

				// Add the item to our inventory
				GameMaster.instance.Inventory.AddItem(myItem);

				// Destroy the GameObject from the scene
				GameMaster.instance.RpgDestroy(gameObject);
			}
		}
	}
}
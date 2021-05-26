using UnityEngine;

public class InventoryItemAgent : MonoBehaviour
{
  public com.noorcon.rpg2e.InventoryItem ItemDescription;

  public void OnTriggerEnter(Collider c)
  {
    // make sure we are colliding with the player
    if(c.gameObject.tag.Equals("Player"))
    {
			// Make a copy of the Inventory Item Object
			com.noorcon.rpg2e.InventoryItem myItem = new com.noorcon.rpg2e.InventoryItem();
      myItem.CopyInventoryItem(ItemDescription);

      // Add the item to our inventory
      com.noorcon.rpg2e.GameMaster.instance.Inventory.AddItem(myItem);

			// Destroy the GameObject from the scene
			com.noorcon.rpg2e.GameMaster.instance.RpgDestroy(gameObject);
    }
  }

}

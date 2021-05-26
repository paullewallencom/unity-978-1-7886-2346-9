
using UnityEngine.EventSystems;

namespace com.noorcon.rpg2e
{
	public class ActiveSpecialItemUi : EventTrigger
	{
		public override void OnPointerClick(PointerEventData data)
		{
			InventoryItem iia =
				gameObject.GetComponent<ActiveInventoryItemUi>().item;

			switch (iia.Category)
			{
				case BaseItem.ItemCatrgory.Health:
					{
						// add the item to the special items panel
						GameMaster.instance.Ui.ApplySpecialInventoryItem(iia);
						Destroy(gameObject);

						break;
					}
				case BaseItem.ItemCatrgory.Potion:
					{
						break;
					}
			}
		}
	}
}
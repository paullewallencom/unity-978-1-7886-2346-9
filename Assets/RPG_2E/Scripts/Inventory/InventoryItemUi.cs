using UnityEngine;
using UnityEngine.UI;

namespace com.noorcon.rpg2e
{
	public class InventoryItemUi : MonoBehaviour
	{
		public Image ItemElementImage;
		public Text ItemElementText;
		public Button AddButton;
		public Button DeleteButton;

		public InventoryItem Item;
	}
}
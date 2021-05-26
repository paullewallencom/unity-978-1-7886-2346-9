
using UnityEngine;
using UnityEngine.UI;

namespace com.noorcon.rpg2e
{
	public class HudElementUi : MonoBehaviour
	{
		public Image imgHealthBar;
		public Image imgManaBar;

		public GameObject activeInventoryItem;
		public GameObject activeSpecialItem;

		public Transform panelActiveInventoryItems;
		public Transform panelActiveSpecialItems;
	}
}
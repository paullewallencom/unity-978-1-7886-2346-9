using System;
using UnityEngine;
using UnityEngine.UI;

namespace com.noorcon.rpg2e
{
	public class UiController : MonoBehaviour
	{
		[Header("Main Menu Canvas")]
		public RectTransform MainMenuCanvas;

		[Header("Settings Window")]
		public RectTransform OptionsPanel;
		public Slider ControlMainVolume;
		public Slider ControlFXVolume;

		[Header("Inventory Window")]
		public RectTransform InventoryCanvas;
		[Tooltip("root for inventory items")]
		public Transform InventoryPanelItem;
		[Tooltip("prefab representing invenotry item UI")]
		public GameObject InventoryItemElement;

		[Header("HUD Window")]
		public RectTransform HudCanvas;
		public HudElementUi HudUi;

		public void Update()
		{

		}

		public void DisplayMainMenu()
		{
			GameMaster.instance.DisplayMainMenu = !GameMaster.instance.DisplayMainMenu;
			if (MainMenuCanvas != null)
			{
				MainMenuCanvas.gameObject.SetActive(GameMaster.instance.DisplayMainMenu);
			}
		}

		public void DisplayGameHud()
		{
			GameMaster.instance.DisplayHud = !GameMaster.instance.DisplayHud;
			if(HudCanvas != null)
			{
				HudCanvas.gameObject.SetActive(GameMaster.instance.DisplayHud);
			}
		}

		public void DisplaySettings()
		{
			GameMaster.instance.DisplaySettings = !GameMaster.instance.DisplaySettings;
			OptionsPanel.gameObject.SetActive(GameMaster.instance.DisplaySettings);
		}

		public void MainVolume()
		{
			GameMaster.instance.MasterVolume(ControlMainVolume.value);
		}

		public void FXVolume()
		{
			GameMaster.instance.SoundFxVolume(ControlFXVolume.value);
		}

		#region INVENTORY UI FUNCTIONS
		public void DisplayInventory()
		{
			InventoryCanvas.gameObject.SetActive(GameMaster.instance.DisplayInventory);
			Debug.Log("Display Inventory Function");
		}

		public void DisplayWeaponsCategory()
		{
			if (GameMaster.instance.DisplayInventory)
			{
				ClearInventoryPanelItems();

				foreach (InventoryItem item in GameMaster.instance.Inventory.Weapons)
				{
					GameObject newItem
						= Instantiate(InventoryItemElement) as GameObject;
					InventoryItemUi InventoryItemControl
						= newItem.GetComponent<InventoryItemUi>();
					InventoryItemControl.ItemElementText.text =
						string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
																		item.Name,
																		item.Description,
																		item.Strength,
																		item.Weight);

					InventoryItemControl.Item = item;

					// button triggers
					InventoryItemControl.AddButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("ADD button for {0}",
							InventoryItemControl.ItemElementText.text));

						// apply selected weapon
						GameMaster.instance.PlayerCharacterData.SelectedWeapon 
							= (PlayerCharacter.WeaponType)Enum.Parse(
									typeof(PlayerCharacter.WeaponType), InventoryItemControl.Item.Name);
						GameMaster.instance.PlayerWeaponChanged();
						AddActiveInventoryItem(InventoryItemControl.Item);
					});

					InventoryItemControl.DeleteButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("DELETE button for {0}",
							InventoryItemControl.ItemElementText.text));
						Destroy(newItem);
					});

					newItem.transform.SetParent(InventoryPanelItem);
				}
			}
		}

		public void DisplayArmourCategory()
		{
			if (GameMaster.instance.DisplayInventory)
			{
				ClearInventoryPanelItems();

				foreach (InventoryItem item in GameMaster.instance.Inventory.Armour)
				{
					GameObject newItem
						= Instantiate(InventoryItemElement) as GameObject;
					InventoryItemUi InventoryItemControl
						= newItem.GetComponent<InventoryItemUi>();
					InventoryItemControl.ItemElementText.text =
						string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
																		item.Name,
																		item.Description,
																		item.Strength,
																		item.Weight);

					InventoryItemControl.Item = item;

					// button triggers
					InventoryItemControl.AddButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("ADD button for {0}",
							InventoryItemControl.ItemElementText.text));

						// apply selected weapon
						GameMaster.instance.PlayerCharacterData.SelectedArmour = InventoryItemControl.Item;
						GameMaster.instance.PlayerArmourChanged(InventoryItemControl.Item);
						AddActiveInventoryItem(InventoryItemControl.Item);
					});

					InventoryItemControl.DeleteButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("DELETE button for {0}",
							InventoryItemControl.ItemElementText.text));
						Destroy(newItem);
					});

					newItem.transform.SetParent(InventoryPanelItem);
				}
			}
		}

		public void DisplayClothingCategory()
		{
			if (GameMaster.instance.DisplayInventory)
			{
				ClearInventoryPanelItems();

				foreach (InventoryItem item in GameMaster.instance.Inventory.Clothing)
				{
					GameObject newItem
						= Instantiate(InventoryItemElement) as GameObject;
					InventoryItemUi InventoryItemControl
						= newItem.GetComponent<InventoryItemUi>();
					InventoryItemControl.ItemElementText.text =
						string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
																		item.Name,
																		item.Description,
																		item.Strength,
																		item.Weight);

					InventoryItemControl.Item = item;

					// button triggers
					InventoryItemControl.AddButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("ADD button for {0}",
							InventoryItemControl.ItemElementText.text));

						// apply selected weapon
						GameMaster.instance.PlayerCharacterData.SelectedClothing
							= (PlayerCharacter.ClothingType)Enum.Parse(
									typeof(PlayerCharacter.ClothingType), InventoryItemControl.Item.Name);

					});

					InventoryItemControl.DeleteButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("DELETE button for {0}",
							InventoryItemControl.ItemElementText.text));
						Destroy(newItem);
					});

					newItem.transform.SetParent(InventoryPanelItem);
				}
			}
		}

		public void DisplayHealthCategory()
		{
			if (GameMaster.instance.DisplayInventory)
			{
				ClearInventoryPanelItems();

				foreach (InventoryItem item in GameMaster.instance.Inventory.Health)
				{
					GameObject newItem
						= Instantiate(InventoryItemElement) as GameObject;
					InventoryItemUi InventoryItemControl
						= newItem.GetComponent<InventoryItemUi>();
					InventoryItemControl.ItemElementText.text =
						string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
																		item.Name,
																		item.Description,
																		item.Strength,
																		item.Weight);

					InventoryItemControl.Item = item;

					// button triggers
					InventoryItemControl.AddButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("ADD button for {0}",
							InventoryItemControl.ItemElementText.text));

						// let's apply the selected item to the player character
						GameMaster.instance.PlayerCharacterData.Health 
						+= InventoryItemControl.Item.Strength * 100;
						if (GameMaster.instance.PlayerCharacterData.Health > 100f)
						{
							GameMaster.instance.PlayerCharacterData.Health = 100f;
						}

						GameMaster.instance.Inventory.DeleteItem(InventoryItemControl.Item);

						Destroy(newItem);
					});

					InventoryItemControl.DeleteButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("DELETE button for {0}",
							InventoryItemControl.ItemElementText.text));
						Destroy(newItem);
					});

					newItem.transform.SetParent(InventoryPanelItem);
				}
			}
		}

		public void DisplayPotionCategory()
		{
			if (GameMaster.instance.DisplayInventory)
			{
				ClearInventoryPanelItems();

				foreach (InventoryItem item in GameMaster.instance.Inventory.Potion)
				{
					GameObject newItem
						= Instantiate(InventoryItemElement) as GameObject;
					InventoryItemUi InventoryItemControl
						= newItem.GetComponent<InventoryItemUi>();
					InventoryItemControl.ItemElementText.text =
						string.Format("Name: {0}, Description: {1}, Strength: {2}, Weight: {3}",
																		item.Name,
																		item.Description,
																		item.Strength,
																		item.Weight);

					InventoryItemControl.Item = item;

					// button triggers
					InventoryItemControl.AddButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("ADD button for {0}",
							InventoryItemControl.ItemElementText.text));

						// apply the potion ...

					});

					InventoryItemControl.DeleteButton.GetComponent<Button>().onClick.AddListener(() =>
					{
						Debug.Log(string.Format("DELETE button for {0}",
							InventoryItemControl.ItemElementText.text));
						Destroy(newItem);
					});

					newItem.transform.SetParent(InventoryPanelItem);
				}
			}
		}

		public void ClearInventoryPanelItems()
		{
			while (InventoryPanelItem.childCount > 0)
			{
				Transform t = InventoryPanelItem.GetChild(0).transform;
				t.parent = null;
				Destroy(t.gameObject);
			}
		}
		#endregion

		#region Adding Active Inventory Item to the UI
		public void AddActiveInventoryItem(InventoryItem item)
		{
			// Make a copy of the Inventory Item Object
			InventoryItem myItem = new InventoryItem();
			myItem.CopyInventoryItem(item);

			GameObject objItem = 
				Instantiate(HudUi.activeInventoryItem) as GameObject;
			ActiveInventoryItemUi aeUI = 
				objItem.GetComponent<ActiveInventoryItemUi>();
			aeUI.txtActiveItem.text = myItem.Name.ToString();

			aeUI.item = myItem;

			objItem.transform.SetParent(HudUi.panelActiveInventoryItems);

			LayoutRebuilder.MarkLayoutForRebuild(HudUi.panelActiveInventoryItems as RectTransform);
		}

		public void AddSpecialInventoryItem(InventoryItem item)
		{
			// Make a copy of the Inventory Item Object
			InventoryItem myItem = new InventoryItem();
			myItem.CopyInventoryItem(item);

			GameObject objItem = 
				Instantiate(HudUi.activeSpecialItem) as GameObject;
			ActiveInventoryItemUi aeUI = 
				objItem.GetComponent<ActiveInventoryItemUi>();
			aeUI.txtActiveItem.text = myItem.Name.ToString();
			aeUI.item = myItem;

			objItem.transform.SetParent(HudUi.panelActiveSpecialItems);

			LayoutRebuilder.MarkLayoutForRebuild(HudUi.panelActiveSpecialItems as RectTransform);
		}

		public void ApplySpecialInventoryItem(InventoryItem item)
		{
			GameMaster.instance.PlayerCharacterData.Health 
				+= item.Strength * 100;
			if (GameMaster.instance.PlayerCharacterData.Health > 100f)
			{
				GameMaster.instance.PlayerCharacterData.Health = 100f;
			}

			GameMaster.instance.Inventory.DeleteItem(item);
		}
		#endregion
	}
}
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.noorcon.rpg2e
{

	[RequireComponent(typeof(AudioSource))]
	public class GameMaster : MonoBehaviour
	{
		public static GameMaster instance;

		// let's have a reference to the player character
		// and start position of player character
		public GameObject PlayerCharacterGameObject;
		public GameObject StartPosition;
		public GameObject CharacterCustomization;

		public PlayerCharacter PlayerCharacterData;

		public InventorySystem Inventory;

		public GameLevelController LevelController;
		public GameAudioController AudioController;

		// Ref to UI Elements ...
		public bool DisplayMainMenu = false;
		public bool DisplaySettings = false;
		public UiController Ui;

		public bool DisplayInventory = false;
		public bool DisplayHud = false;

		public List<GameObject> NpcEnemyListGameObjects;
		public GameObject ClosestNpcEnemy;

		void Awake()
		{
			// simple singlton
			if (instance == null)
			{
				instance = this;

				// initialize level controller
				instance.LevelController = new GameLevelController();

				// initialize audio controller
				instance.AudioController = new GameAudioController();
				instance.AudioController.audioSource = instance.GetComponent<AudioSource>();
				instance.AudioController.SetDefaultVolume();

				// initialize Inventory System
				instance.Inventory = new InventorySystem();
			}
			else if (instance != this)
			{
				Destroy(this);
			}

			// keep the game object when moving from
			// one scene to the next scene
			DontDestroyOnLoad(this);
		}

		// for each level/scene that has been loaded
		// do some of the preparation work
		private void OnLevelWasLoaded(int level)
		{
			instance.LevelController.OnLevelWasLoaded();

			// find all NPC GameObjects of Enemy type
			if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0)
			{
				var tmpGONPCEnemy = GameObject.FindGameObjectsWithTag("Enemy");

				instance.NpcEnemyListGameObjects.Clear();
				foreach (GameObject goTmpNPCEnemy in tmpGONPCEnemy)
				{
					instance.NpcEnemyListGameObjects.Add(goTmpNPCEnemy);
					instance.ClosestNpcEnemy = goTmpNPCEnemy;
				}
			}
		}

		// Use this for initialization
		void Start()
		{
			// let's find a reference to the UI controller of the loaded scene
			if (GameObject.FindGameObjectWithTag("Ui") != null)
			{
				instance.Ui = GameObject.FindGameObjectWithTag("Ui").GetComponent<UiController>();
			}

			instance.Ui.OptionsPanel.gameObject.SetActive(instance.DisplaySettings);
		}

		// Update is called once per frame
		void Update()
		{
			if (instance.LevelController.CurrentScene.name != SceneName.MainMenu)
			{
				if (Input.GetKeyUp(KeyCode.J))
				{
					instance.DisplayInventory = !DisplayInventory;
					instance.Ui.DisplayInventory();
				}
			}
		}

		#region Player Inventory Items Applied
		public void PlayerWeaponChanged()
		{
			Debug.Log(string.Format("Weapon changed to: {0}", 
				instance.PlayerCharacterData.SelectedWeapon.ToString()));
			instance.PlayerCharacterGameObject.GetComponent<BarbarianCharacterCustomization>().SetWeaponType(instance.PlayerCharacterData.SelectedWeapon);
		}

		public void PlayerArmourChanged(InventoryItem item)
		{
			Debug.Log(string.Format("Armour changed to: {0} {1}", 
				instance.PlayerCharacterData.SelectedArmour.Name, 
				instance.PlayerCharacterData.SelectedArmour.Type));

			switch (item.Type)
			{
				case InventoryItem.ItemType.Helmet:
					{
						instance.PlayerCharacterData.SelectedHelmet = (PlayerCharacter.HelmetType)Enum.Parse(typeof(PlayerCharacter.HelmetType), 
							instance.PlayerCharacterData.SelectedArmour.Name);
						instance.PlayerCharacterGameObject.GetComponent<BarbarianCharacterCustomization>().SetHelmetType(instance.PlayerCharacterData.SelectedHelmet);
						break;
					}
				case InventoryItem.ItemType.Shield:
					{
						instance.PlayerCharacterData.SelectedShield = (PlayerCharacter.ShieldType)Enum.Parse(typeof(PlayerCharacter.ShieldType), 
							instance.PlayerCharacterData.SelectedArmour.Name);
						instance.PlayerCharacterGameObject.GetComponent<BarbarianCharacterCustomization>().SetShieldType(instance.PlayerCharacterData.SelectedShield);
						break;
					}
				case InventoryItem.ItemType.ShoulderPad:
					{
						instance.PlayerCharacterData.SelectedShoulderPad = (PlayerCharacter.ShoulderPad)Enum.Parse(typeof(PlayerCharacter.ShoulderPad), 
							instance.PlayerCharacterData.SelectedArmour.Name);
						instance.PlayerCharacterGameObject.GetComponent<BarbarianCharacterCustomization>().SetShoulderPad(instance.PlayerCharacterData.SelectedShoulderPad);
						break;
					}
				case InventoryItem.ItemType.KneePad:
					{
						break;
					}
				case InventoryItem.ItemType.Shoes:
					{
						break;
					}

			}
		}
		#endregion

		public void MasterVolume(float volume)
		{
			instance.AudioController.MasterVolume(volume);
		}

		public void SoundFxVolume(float volume)
		{
			instance.AudioController.SoundFxVolume(volume);
		}

		public void StartGame()
		{
			instance.LoadLevel();
		}

		public void LoadLevel()
		{
			instance.LevelController.LoadLevel();
		}

		public void LoadMultiplayerLobby()
		{
			SceneManager.LoadScene("NetworkingMenu");
		}

		public void RpgDestroy(GameObject obj)
		{
			Destroy(obj);
		}

		public void AttackEnemy(float value)
		{
			Npc npc = 
				instance.ClosestNpcEnemy.GetComponent<NpcAgent>().NpcData;
			npc.Health -= value;
		}

		public void AttackPlayer(float value)
		{
			instance.PlayerCharacterData.Health -= value;
		}
	}
}

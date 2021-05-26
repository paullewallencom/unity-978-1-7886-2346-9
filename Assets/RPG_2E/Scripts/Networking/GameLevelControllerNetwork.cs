using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

namespace com.noorcon.rpg2e
{
	public class GameLevelControllerNetwork
	{
		// let's have a reference to the current scene/level
		public Scene CurrentScene
		{
			get { return SceneManager.GetActiveScene(); }
		}

		// keep the numerical level value
		public int Level = 0;
		public void OnLevelWasLoaded()
		{
			// if we are in the character customization scene, 
			// let's get a reference to the Base game object for future use.
			if (CurrentScene.Equals(SceneName.CharacterCustomization))
			{
				if (GameObject.FindGameObjectWithTag("Base") != null)
				{
					GameMasterNetwork.instance.CharacterCustomization = GameObject.FindGameObjectWithTag("Base") as GameObject;
				}
			}

			// If we are at any other scene except character customization
			// let's go ahead and get reference to player and player
			// stat position
			if (CurrentScene.name.Equals(SceneName.CharacterCustomization))
			{
				// let's get a reference to our player character
				if (GameMasterNetwork.instance.PlayerCharacterGameObject == null)
				{
					if (GameObject.FindGameObjectWithTag("Player") != null)
					{
						GameMasterNetwork.instance.PlayerCharacterGameObject = GameObject.FindGameObjectWithTag("Player") as GameObject;
					}
				}

				// let's get a reference to our player character
				if (GameMasterNetwork.instance.PlayerCharacterGameObject == null)
				{
					if (GameObject.FindGameObjectWithTag("Player") != null)
					{
						GameMaster.instance.PlayerCharacterGameObject = GameObject.FindGameObjectWithTag("Player") as GameObject;
					}
				}
			}


			#region for all scenes - if start position exist, assign it
			if (GameObject.FindGameObjectWithTag("StartPosition") != null)
			{
				GameMasterNetwork.instance.StartPosition = GameObject.FindGameObjectWithTag("StartPosition") as GameObject;
			}

			if (GameMasterNetwork.instance.StartPosition != null && GameMasterNetwork.instance.PlayerCharacterGameObject != null)
			{
				GameMasterNetwork.instance.PlayerCharacterGameObject.transform.position = GameMasterNetwork.instance.StartPosition.transform.position;
				GameMasterNetwork.instance.PlayerCharacterGameObject.transform.rotation = GameMasterNetwork.instance.StartPosition.transform.rotation;
			}
			#endregion

			// determine what level we are on
			DetermineLevel();
		}

		// this function will set a numerical value for our levels
		private void DetermineLevel()
		{
			switch (CurrentScene.name)
			{
				case SceneName.MainMenu:
					{
						GameMasterNetwork.instance.Ui.DisplayMainMenu(); // show
						break;
					}
				case SceneName.CharacterCustomization:
					{
						GameMasterNetwork.instance.Ui.DisplayMainMenu(); // hide
						Level = 0;
						break;
					}

				case SceneName.Level_1:
					{
						Level = 1;
						GameMasterNetwork.instance.PlayerCharacterGameObject.GetComponent<IKHandle>().enabled = true;
						GameMasterNetwork.instance.Ui.DisplayGameHud();
						break;
					}
				default:
					{
						Level = 0;
						break;
					}
			}
		}

		// this function will be used to load our scenes
		public void LoadLevel()
		{
			switch (GameMasterNetwork.instance.LevelController.Level)
			{
				case 0:
					{
						SceneManager.LoadScene(SceneName.CharacterCustomization);
						break;
					}

				// load level 1
				case 1:
					{
						GameMasterNetwork.instance.PlayerCharacterGameObject = GameObject.FindGameObjectWithTag("Player") as GameObject;
						SceneManager.LoadScene(SceneName.Level_1);
						break;
					}
			}
		}
	}
}
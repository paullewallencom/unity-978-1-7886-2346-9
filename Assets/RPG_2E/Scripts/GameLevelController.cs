
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.noorcon.rpg2e
{
	public static class SceneName
	{
		public const string MainMenu = "MainMenu";
		public const string CharacterCustomization = "CharacterCustomization";
		public const string Level_1 = "Awakening";
	}

	public class GameLevelController
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
					GameMaster.instance.CharacterCustomization = GameObject.FindGameObjectWithTag("Base") as GameObject;
				}
			}

			// If we are at any other scene except character customization
			// let's go ahead and get reference to player and player
			// stat position
			if (CurrentScene.name.Equals(SceneName.CharacterCustomization))
			{
				// let's get a reference to our player character
				if (GameMaster.instance.PlayerCharacterGameObject == null)
				{
					if (GameObject.FindGameObjectWithTag("Player") != null)
					{
						GameMaster.instance.PlayerCharacterGameObject = GameObject.FindGameObjectWithTag("Player") as GameObject;
					}
				}

				// let's get a reference to our player character
				if (GameMaster.instance.PlayerCharacterGameObject == null)
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
				GameMaster.instance.StartPosition = GameObject.FindGameObjectWithTag("StartPosition") as GameObject;
			}

			if (GameMaster.instance.StartPosition != null && GameMaster.instance.PlayerCharacterGameObject != null)
			{
				GameMaster.instance.PlayerCharacterGameObject.transform.position = GameMaster.instance.StartPosition.transform.position;
				GameMaster.instance.PlayerCharacterGameObject.transform.rotation = GameMaster.instance.StartPosition.transform.rotation;
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
						GameMaster.instance.Ui.DisplayMainMenu();	// show
						break;
					}
				case SceneName.CharacterCustomization:
					{
						GameMaster.instance.Ui.DisplayMainMenu();	// hide
						Level = 0;
						break;
					}

				case SceneName.Level_1:
					{
						Level = 1;
						GameMaster.instance.PlayerCharacterGameObject.GetComponent<IKHandle>().enabled = true;
						GameMaster.instance.Ui.DisplayGameHud();
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
			switch (GameMaster.instance.LevelController.Level)
			{
				case 0:
					{
						SceneManager.LoadScene(SceneName.CharacterCustomization);
						break;
					}

				// load level 1
				case 1:
					{
						GameMaster.instance.PlayerCharacterGameObject = GameObject.FindGameObjectWithTag("Player") as GameObject;
						SceneManager.LoadScene(SceneName.Level_1);
						break;
					}
			}
		}
	}
}
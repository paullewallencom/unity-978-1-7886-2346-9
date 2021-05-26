using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

namespace com.noorcon.rpg2e
{
	public class BarbarianCharacterNetworkCustomization : NetworkBehaviour
	{
		public GameObject PLAYER_CHARACTER;

		public PlayerCharacter PlayerCharacterData;

		public Material[] PLAYER_SKIN;

		public GameObject CLOTH_01LOD0;
		public GameObject CLOTH_01LOD0_SKIN;
		public GameObject CLOTH_02LOD0;
		public GameObject CLOTH_02LOD0_SKIN;
		public GameObject CLOTH_03LOD0;
		public GameObject CLOTH_03LOD0_SKIN;
		public GameObject CLOTH_03LOD0_FAT;

		public GameObject BELT_LOD0;

		public GameObject SKN_LOD0;
		//public GameObject FAT_LOD0;
		//public GameObject RGL_LOD0;

		public GameObject HAIR_LOD0;

		public GameObject BOW_LOD0;

		// Head Equipment
		public GameObject GLADIATOR_01LOD0;
		public GameObject HELMET_01LOD0;
		public GameObject HELMET_02LOD0;
		public GameObject HELMET_03LOD0;
		public GameObject HELMET_04LOD0;

		// Shoulder Pad - Right Arm / Left Arm
		public GameObject SHOULDER_PAD_R_01LOD0;
		public GameObject SHOULDER_PAD_R_02LOD0;
		public GameObject SHOULDER_PAD_R_03LOD0;
		public GameObject SHOULDER_PAD_R_04LOD0;

		public GameObject SHOULDER_PAD_L_01LOD0;
		public GameObject SHOULDER_PAD_L_02LOD0;
		public GameObject SHOULDER_PAD_L_03LOD0;
		public GameObject SHOULDER_PAD_L_04LOD0;

		// Fore Arm - Right / Left Plates
		public GameObject ARM_PLATE_R_1LOD0;
		public GameObject ARM_PLATE_R_2LOD0;

		public GameObject ARM_PLATE_L_1LOD0;
		public GameObject ARM_PLATE_L_2LOD0;

		// Player Character Weapons
		public GameObject AXE_01LOD0;
		public GameObject AXE_02LOD0;
		public GameObject CLUB_01LOD0;
		public GameObject CLUB_02LOD0;
		public GameObject FALCHION_LOD0;
		public GameObject GLADIUS_LOD0;
		public GameObject MACE_LOD0;
		public GameObject MAUL_LOD0;
		public GameObject SCIMITAR_LOD0;
		public GameObject SPEAR_LOD0;
		public GameObject SWORD_BASTARD_LOD0;
		public GameObject SWORD_BOARD_01LOD0;
		public GameObject SWORD_SHORT_LOD0;

		// Player Character Defense Weapons
		public GameObject SHIELD_01LOD0;
		public GameObject SHIELD_02LOD0;

		public GameObject QUIVER_LOD0;
		public GameObject BOW_01_LOD0;

		// Player Character Calf - Right / Left
		public GameObject KNEE_PAD_R_LOD0;
		public GameObject LEG_PLATE_R_LOD0;

		public GameObject KNEE_PAD_L_LOD0;
		public GameObject LEG_PLATE_L_LOD0;

		public GameObject BOOT_01LOD0;
		public GameObject BOOT_02LOD0;

		// Use this for initialization
		void Start()
		{
			PlayerCharacterData = PLAYER_CHARACTER.GetComponent<PlayerAgentNetwork>().playerCharacterData;
		}

		public bool ROTATE_MODEL = false;

		// Update is called once per frame
		void Update()
		{
			if (Input.GetKeyUp(KeyCode.R))
			{
				ROTATE_MODEL = !ROTATE_MODEL;
			}

			if (ROTATE_MODEL)
			{
				PLAYER_CHARACTER.transform.Rotate(new Vector3(0, 1, 0), 33.0f * Time.deltaTime);
			}

			if (Input.GetKeyUp(KeyCode.L))
			{
				Debug.Log(PlayerPrefs.GetString("Name"));
			}

		}


		public void SetShoulderPad(Toggle id)
		{
			try
			{
				PlayerCharacter.ShoulderPad name
					= (PlayerCharacter.ShoulderPad)Enum.Parse(typeof(PlayerCharacter.ShoulderPad), id.name, true);
				if (id.isOn)
				{
					PlayerCharacterData.SelectedShoulderPad = name;
				}
				else
				{
					PlayerCharacterData.SelectedShoulderPad
						= PlayerCharacter.ShoulderPad.none;
				}
			}
			catch
			{
				// if the value passed is not in the enumeration set it to none
				PlayerCharacterData.SelectedShoulderPad
					= PlayerCharacter.ShoulderPad.none;
			}

			switch (id.name)
			{
				case "SP01":
					{
						SHOULDER_PAD_R_01LOD0.SetActive(id.isOn);
						SHOULDER_PAD_R_02LOD0.SetActive(false);
						SHOULDER_PAD_R_03LOD0.SetActive(false);
						SHOULDER_PAD_R_04LOD0.SetActive(false);

						SHOULDER_PAD_L_01LOD0.SetActive(id.isOn);
						SHOULDER_PAD_L_02LOD0.SetActive(false);
						SHOULDER_PAD_L_03LOD0.SetActive(false);
						SHOULDER_PAD_L_04LOD0.SetActive(false);
						break;
					}
				case "SP02":
					{
						SHOULDER_PAD_R_01LOD0.SetActive(false);
						SHOULDER_PAD_R_02LOD0.SetActive(id.isOn);
						SHOULDER_PAD_R_03LOD0.SetActive(false);
						SHOULDER_PAD_R_04LOD0.SetActive(false);

						SHOULDER_PAD_L_01LOD0.SetActive(false);
						SHOULDER_PAD_L_02LOD0.SetActive(id.isOn);
						SHOULDER_PAD_L_03LOD0.SetActive(false);
						SHOULDER_PAD_L_04LOD0.SetActive(false);
						break;
					}
				case "SP03":
					{
						SHOULDER_PAD_R_01LOD0.SetActive(false);
						SHOULDER_PAD_R_02LOD0.SetActive(false);
						SHOULDER_PAD_R_03LOD0.SetActive(id.isOn);
						SHOULDER_PAD_R_04LOD0.SetActive(false);

						SHOULDER_PAD_L_01LOD0.SetActive(false);
						SHOULDER_PAD_L_02LOD0.SetActive(false);
						SHOULDER_PAD_L_03LOD0.SetActive(id.isOn);
						SHOULDER_PAD_L_04LOD0.SetActive(false);
						break;
					}
				case "SP04":
					{
						SHOULDER_PAD_R_01LOD0.SetActive(false);
						SHOULDER_PAD_R_02LOD0.SetActive(false);
						SHOULDER_PAD_R_03LOD0.SetActive(false);
						SHOULDER_PAD_R_04LOD0.SetActive(id.isOn);

						SHOULDER_PAD_L_01LOD0.SetActive(false);
						SHOULDER_PAD_L_02LOD0.SetActive(false);
						SHOULDER_PAD_L_03LOD0.SetActive(false);
						SHOULDER_PAD_L_04LOD0.SetActive(id.isOn);
						break;
					}
			}
		}

		public void SetShoulderPad(PlayerCharacter.ShoulderPad id)
		{
			switch (id.ToString())
			{
				case "SP01":
					{
						SHOULDER_PAD_R_01LOD0.SetActive(true);
						SHOULDER_PAD_R_02LOD0.SetActive(false);
						SHOULDER_PAD_R_03LOD0.SetActive(false);
						SHOULDER_PAD_R_04LOD0.SetActive(false);

						SHOULDER_PAD_L_01LOD0.SetActive(true);
						SHOULDER_PAD_L_02LOD0.SetActive(false);
						SHOULDER_PAD_L_03LOD0.SetActive(false);
						SHOULDER_PAD_L_04LOD0.SetActive(false);
						break;
					}
				case "SP02":
					{
						SHOULDER_PAD_R_01LOD0.SetActive(false);
						SHOULDER_PAD_R_02LOD0.SetActive(true);
						SHOULDER_PAD_R_03LOD0.SetActive(false);
						SHOULDER_PAD_R_04LOD0.SetActive(false);

						SHOULDER_PAD_L_01LOD0.SetActive(false);
						SHOULDER_PAD_L_02LOD0.SetActive(true);
						SHOULDER_PAD_L_03LOD0.SetActive(false);
						SHOULDER_PAD_L_04LOD0.SetActive(false);
						break;
					}
				case "SP03":
					{
						SHOULDER_PAD_R_01LOD0.SetActive(false);
						SHOULDER_PAD_R_02LOD0.SetActive(false);
						SHOULDER_PAD_R_03LOD0.SetActive(true);
						SHOULDER_PAD_R_04LOD0.SetActive(false);

						SHOULDER_PAD_L_01LOD0.SetActive(false);
						SHOULDER_PAD_L_02LOD0.SetActive(false);
						SHOULDER_PAD_L_03LOD0.SetActive(true);
						SHOULDER_PAD_L_04LOD0.SetActive(false);
						break;
					}
				case "SP04":
					{
						SHOULDER_PAD_R_01LOD0.SetActive(false);
						SHOULDER_PAD_R_02LOD0.SetActive(false);
						SHOULDER_PAD_R_03LOD0.SetActive(false);
						SHOULDER_PAD_R_04LOD0.SetActive(true);

						SHOULDER_PAD_L_01LOD0.SetActive(false);
						SHOULDER_PAD_L_02LOD0.SetActive(false);
						SHOULDER_PAD_L_03LOD0.SetActive(false);
						SHOULDER_PAD_L_04LOD0.SetActive(true);
						break;
					}
			}
		}

		#region DEPRICATED
		//public void SetBodyType(Toggle id)
		//{
		//	switch (id.name)
		//	{
		//		case "BT-01":
		//			{
		//				RGL_LOD0.SetActive(id.isOn);
		//				FAT_LOD0.SetActive(false);
		//				break;
		//			}
		//		case "BT-02":
		//			{
		//				RGL_LOD0.SetActive(false);
		//				FAT_LOD0.SetActive(id.isOn);
		//				break;
		//			}
		//	}
		//}
		#endregion

		public void SetKneePad(Toggle id)
		{
			KNEE_PAD_R_LOD0.SetActive(id.isOn);
			KNEE_PAD_L_LOD0.SetActive(id.isOn);
		}

		public void SetLegPlate(Toggle id)
		{
			LEG_PLATE_R_LOD0.SetActive(id.isOn);
			LEG_PLATE_L_LOD0.SetActive(id.isOn);
		}

		public void SetWeaponType(Slider id)
		{
			try
			{
				PlayerCharacter.WeaponType weapon = (PlayerCharacter.WeaponType)Convert.ToInt32(id.value);

				PlayerCharacterData.SelectedWeapon = weapon;
			}
			catch
			{
				PlayerCharacterData.SelectedWeapon = PlayerCharacter.WeaponType.none;
			}

			switch (Convert.ToInt32(id.value))
			{
				case 0:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 1:
					{
						AXE_01LOD0.SetActive(true);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 2:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(true);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 3:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(true);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 4:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(true);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 5:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(true);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 6:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(true);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 7:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(true);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 8:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(true);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 9:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(true);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 10:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(true);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 11:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(true);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 12:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(true);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 13:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(true);
						break;
					}
			}
		}

		public void SetWeaponType(PlayerCharacter.WeaponType id)
		{
			switch (Convert.ToInt32(id))
			{
				case 0:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 1:
					{
						AXE_01LOD0.SetActive(true);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 2:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(true);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 3:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(true);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 4:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(true);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 5:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(true);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 6:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(true);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 7:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(true);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 8:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(true);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 9:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(true);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 10:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(true);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 11:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(true);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 12:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(true);
						SWORD_SHORT_LOD0.SetActive(false);
						break;
					}
				case 13:
					{
						AXE_01LOD0.SetActive(false);
						AXE_02LOD0.SetActive(false);
						CLUB_01LOD0.SetActive(false);
						CLUB_02LOD0.SetActive(false);
						FALCHION_LOD0.SetActive(false);
						GLADIUS_LOD0.SetActive(false);
						MACE_LOD0.SetActive(false);
						MAUL_LOD0.SetActive(false);
						SCIMITAR_LOD0.SetActive(false);
						SPEAR_LOD0.SetActive(false);
						SWORD_BASTARD_LOD0.SetActive(false);
						SWORD_BOARD_01LOD0.SetActive(false);
						SWORD_SHORT_LOD0.SetActive(true);
						break;
					}
			}
		}

		public void SetHelmetType(Toggle id)
		{
			try
			{
				PlayerCharacter.HelmetType helmet
					= (PlayerCharacter.HelmetType)Enum.Parse(typeof(PlayerCharacter.HelmetType), id.name, true);
				if (id.isOn)
				{
					PlayerCharacterData.SelectedHelmet = helmet;
				}
				else
				{
					PlayerCharacterData.SelectedHelmet
						= PlayerCharacter.HelmetType.none;
				}
			}
			catch
			{
				// if the value passed is not in the enumeration set it to none
				PlayerCharacterData.SelectedHelmet
					= PlayerCharacter.HelmetType.none;
			}

			switch (id.name)
			{
				case "HL01":
					{
						HELMET_01LOD0.SetActive(id.isOn);
						HELMET_02LOD0.SetActive(false);
						HELMET_03LOD0.SetActive(false);
						HELMET_04LOD0.SetActive(false);
						break;
					}
				case "HL02":
					{
						HELMET_01LOD0.SetActive(false);
						HELMET_02LOD0.SetActive(id.isOn);
						HELMET_03LOD0.SetActive(false);
						HELMET_04LOD0.SetActive(false);
						break;
					}
				case "HL03":
					{
						HELMET_01LOD0.SetActive(false);
						HELMET_02LOD0.SetActive(false);
						HELMET_03LOD0.SetActive(id.isOn);
						HELMET_04LOD0.SetActive(false);
						break;
					}
				case "HL04":
					{
						HELMET_01LOD0.SetActive(false);
						HELMET_02LOD0.SetActive(false);
						HELMET_03LOD0.SetActive(false);
						HELMET_04LOD0.SetActive(id.isOn);
						break;
					}
			}
		}

		public void SetHelmetType(PlayerCharacter.HelmetType id)
		{
			switch (id.ToString())
			{
				case "HL01":
					{
						HELMET_01LOD0.SetActive(true);
						HELMET_02LOD0.SetActive(false);
						HELMET_03LOD0.SetActive(false);
						HELMET_04LOD0.SetActive(false);
						break;
					}
				case "HL02":
					{
						HELMET_01LOD0.SetActive(false);
						HELMET_02LOD0.SetActive(true);
						HELMET_03LOD0.SetActive(false);
						HELMET_04LOD0.SetActive(false);
						break;
					}
				case "HL03":
					{
						HELMET_01LOD0.SetActive(false);
						HELMET_02LOD0.SetActive(false);
						HELMET_03LOD0.SetActive(true);
						HELMET_04LOD0.SetActive(false);
						break;
					}
				case "HL04":
					{
						HELMET_01LOD0.SetActive(false);
						HELMET_02LOD0.SetActive(false);
						HELMET_03LOD0.SetActive(false);
						HELMET_04LOD0.SetActive(true);
						break;
					}
			}
		}

		public void SetShieldType(Toggle id)
		{
			try
			{
				PlayerCharacter.ShieldType shield
					= (PlayerCharacter.ShieldType)Enum.Parse(typeof(PlayerCharacter.ShieldType), id.name, true);
				if (id.isOn)
				{
					PlayerCharacterData.SelectedShield = shield;
				}
				else
				{
					PlayerCharacterData.SelectedShield = PlayerCharacter.ShieldType.none;
				}
			}
			catch
			{
				// if the value passed is not in the enumeration set it to none
				PlayerCharacterData.SelectedShield = PlayerCharacter.ShieldType.none;
			}

			switch (id.name)
			{
				case "SL01":
					{
						SHIELD_01LOD0.SetActive(id.isOn);
						SHIELD_02LOD0.SetActive(false);
						break;
					}
				case "SL02":
					{
						SHIELD_01LOD0.SetActive(false);
						SHIELD_02LOD0.SetActive(id.isOn);
						break;
					}
			}
		}

		public void SetShieldType(PlayerCharacter.ShieldType id)
		{
			switch (id.ToString())
			{
				case "SL01":
					{
						SHIELD_01LOD0.SetActive(true);
						SHIELD_02LOD0.SetActive(false);
						break;
					}
				case "SL02":
					{
						SHIELD_01LOD0.SetActive(false);
						SHIELD_02LOD0.SetActive(true);
						break;
					}
			}
		}

		public void SetSkinType(Slider id)
		{
			PlayerCharacterData.SkinId = Convert.ToInt32(id.value);
			SKN_LOD0.GetComponent<Renderer>().material = PLAYER_SKIN[System.Convert.ToInt32(id.value)];
		}

		public void SetBodyFat(Slider id)
		{
			PlayerCharacterData.BodyFat = (float)Convert.ToDouble(id.value);
			SKN_LOD0.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(5, id.value);
		}

		public void SetBodySkinny(Slider id)
		{
			PlayerCharacterData.BodySkinny = (float)Convert.ToDouble(id.value);
			SKN_LOD0.GetComponent<SkinnedMeshRenderer>().SetBlendShapeWeight(6, id.value);
		}

		public void SetClothingType(Toggle id)
		{
			try
			{
				PlayerCharacter.ClothingType clothing
					= (PlayerCharacter.ClothingType)Enum.Parse(typeof(PlayerCharacter.ClothingType), id.name, true);
				if (id.isOn)
				{
					PlayerCharacterData.SelectedClothing = clothing;
				}
				else
				{
					PlayerCharacterData.SelectedClothing
						= PlayerCharacter.ClothingType.none;
				}
			}
			catch
			{
				// if the value passed is not in the enumeration set it to none
				PlayerCharacterData.SelectedClothing
					= PlayerCharacter.ClothingType.none;
			}

			switch (id.name)
			{
				case "CT01":
					{
						CLOTH_01LOD0.SetActive(id.isOn);
						CLOTH_02LOD0.SetActive(false);
						CLOTH_03LOD0.SetActive(false);
						break;
					}
				case "CT02":
					{
						CLOTH_01LOD0.SetActive(false);
						CLOTH_02LOD0.SetActive(id.isOn);
						CLOTH_03LOD0.SetActive(false);
						break;
					}
				case "CT03":
					{
						CLOTH_01LOD0.SetActive(false);
						CLOTH_02LOD0.SetActive(false);
						CLOTH_03LOD0.SetActive(id.isOn);
						break;
					}
				case "CT04":
					{
						BELT_LOD0.SetActive(id.isOn);
						break;
					}
			}
		}

		public void SetClothingType(PlayerCharacter.ClothingType id)
		{
			switch (id.ToString())
			{
				case "CT01":
					{
						CLOTH_01LOD0.SetActive(true);
						CLOTH_02LOD0.SetActive(false);
						CLOTH_03LOD0.SetActive(false);
						break;
					}
				case "CT02":
					{
						CLOTH_01LOD0.SetActive(false);
						CLOTH_02LOD0.SetActive(true);
						CLOTH_03LOD0.SetActive(false);
						break;
					}
				case "CT03":
					{
						CLOTH_01LOD0.SetActive(false);
						CLOTH_02LOD0.SetActive(false);
						CLOTH_03LOD0.SetActive(true);
						break;
					}
				case "CT04":
					{
						BELT_LOD0.SetActive(true);
						break;
					}
			}
		}

		public void SetBootType(Toggle id)
		{
			try
			{
				PlayerCharacter.ShoeType shoe
					= (PlayerCharacter.ShoeType)Enum.Parse(typeof(PlayerCharacter.ShoeType), id.name, true);
				if (id.isOn)
				{
					PlayerCharacterData.SelectedShoe = shoe;
				}
				else
				{
					PlayerCharacterData.SelectedShoe
						= PlayerCharacter.ShoeType.none;
				}
			}
			catch
			{
				// if the value passed is not in the enumeration set it to none
				PlayerCharacterData.SelectedShoe
					= PlayerCharacter.ShoeType.none;
			}

			switch (id.name)
			{
				case "BT01":
					{
						BOOT_01LOD0.SetActive(id.isOn);
						BOOT_02LOD0.SetActive(false);
						break;
					}
				case "BT02":
					{
						BOOT_01LOD0.SetActive(false);
						BOOT_02LOD0.SetActive(id.isOn);
						break;
					}
			}
		}

		public void SetBootType(PlayerCharacter.ShoeType id)
		{
			switch (id.ToString())
			{
				case "BT01":
					{
						BOOT_01LOD0.SetActive(true);
						BOOT_02LOD0.SetActive(false);
						break;
					}
				case "BT02":
					{
						BOOT_01LOD0.SetActive(false);
						BOOT_02LOD0.SetActive(true);
						break;
					}
			}
		}

		public void SaveCharacter()
		{
			GameMaster.instance.PlayerCharacterData = PlayerCharacterData;
			GameMaster.instance.LevelController.Level = 1;
			GameMaster.instance.LoadLevel();
		}

	}
}

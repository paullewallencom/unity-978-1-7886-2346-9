using System;
using UnityEngine;

namespace com.noorcon.rpg2e
{
	public delegate void WeaponChangedEventHandler(PlayerCharacter.WeaponType weapon);

	[Serializable]
	public class PlayerCharacter : BaseCharacter
	{
		public enum ShoulderPad
		{
			none = 0,
			SP01 = 1,
			SP02 = 2,
			SP03 = 3,
			SP04 = 4
		};

		// Older version of the model
		public enum BodyType { normal = 1, BT01 = 2, BT02 = 3 };
		// New support for character model
		public float BodyFat = 0.0f;
		public float BodySkinny = 0.0f;


		// Shoulder Pad
		[SerializeField]
		private ShoulderPad selectedShoulderPad = ShoulderPad.none;
		public ShoulderPad SelectedShoulderPad
		{
			get { return selectedShoulderPad; }
			set { selectedShoulderPad = value; }
		}

		// Body Type
		[SerializeField]
		private BodyType selectedBodyType = BodyType.normal;
		public BodyType SelectedBodyType
		{
			get { return selectedBodyType; }
			set { selectedBodyType = value; }
		}

		public bool kneePad = false;
		public bool legPlate = false;

		public enum WeaponType
		{
			none = 0,
			axe1 = 1,
			axe2 = 2,
			club1 = 3,
			club2 = 4,
			falchion = 5,
			gladius = 6,
			mace = 7,
			maul = 8,
			scimitar = 9,
			spear = 10,
			sword1 = 11,
			sword2 = 12,
			sword3 = 13
		};

		[SerializeField]
		private WeaponType selectedWeapon = WeaponType.none;
		public WeaponType SelectedWeapon
		{
			get { return selectedWeapon; }
			set { selectedWeapon = value; }
		}

		public enum HelmetType { none = 0, HL01 = 1, HL02 = 2, HL03 = 3, HL04 = 4 };

		[SerializeField]
		private HelmetType selectedHelmet = HelmetType.none;
		public HelmetType SelectedHelmet
		{
			get { return selectedHelmet; }
			set { selectedHelmet = value; }
		}

		public enum ShieldType { none = 0, SL01 = 1, SL02 = 2 };
		[SerializeField]
		private ShieldType selectedShield = ShieldType.none;
		public ShieldType SelectedShield
		{
			get { return selectedShield; }
			set { selectedShield = value; }
		}

		public int SkinId = 1;

		public enum ClothingType { none=0, CT01=1, CT02=2, CT03=3, CT04=4 };
		[SerializeField]
		private ClothingType selectedClothing = ClothingType.none;
		public ClothingType SelectedClothing
		{
			get { return selectedClothing; }
			set { selectedClothing = value; }
		}

		public enum ShoeType { none = 0, BT01 = 1, BT02 = 2 };
		[SerializeField]
		private ShoeType selectedShoe = ShoeType.none;
		public ShoeType SelectedShoe
		{
			get { return selectedShoe; }
			set { selectedShoe = value; }
		}

		[SerializeField]
		private InventoryItem selectedArmour;
		public InventoryItem SelectedArmour
		{
			get { return selectedArmour; }
			set { selectedArmour = value; }
		}
	}
}
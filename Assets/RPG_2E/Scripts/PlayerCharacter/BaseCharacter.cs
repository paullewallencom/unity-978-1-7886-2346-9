using System;
using UnityEngine;

namespace com.noorcon.rpg2e
{
	[Serializable]
	public class BaseCharacter
	{
		[SerializeField]
		public string Name;
		[SerializeField]
		public string Description;
		[SerializeField]
		public string Tag;

		internal GameObject CharacterGameObject;

		[SerializeField]
		public float Strength;
		[SerializeField]
		public float Defense;
		[SerializeField]
		private float dexterity;
		public float Dexterity
		{
			get { return dexterity; }
			set
			{
				dexterity = value;

				if (Tag.Equals("Player"))
				{
					try
					{
						if (GameMaster.instance.Ui.HudUi != null)
						{
							GameMaster.instance.Ui.HudUi.imgManaBar.fillAmount
								= dexterity / 100.0f;
						}
					}
					catch (Exception ex)
					{
						Debug.Log("HUD UI missing ...");
					}
				}
				//else
				//{
				//	CharacterGameObject.GetComponent<NPC_Agent>().SetHealthValue(this.health / 100.0f);
				//}
			}
		}


		[SerializeField]
		public float Intelligence;


		[SerializeField]
		private float health;
		public float Health
		{
			get { return health; }
			set
			{
				health = value;

				if (Tag.Equals("Player"))
				{
					try
					{
						if (GameMaster.instance.Ui.HudUi != null)
						{
							GameMaster.instance.Ui.HudUi.imgHealthBar.fillAmount
								= health / 100.0f;
						}
					}
					catch (Exception ex)
					{
						Debug.Log("HUD UI missing ...");
					}
				}
				else
				{
					CharacterGameObject.GetComponent<NpcAgent>().SetHealthValue(health / 100.0f);
				}
			}
		}
	}
}
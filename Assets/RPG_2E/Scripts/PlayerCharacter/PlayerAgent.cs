using System;
using UnityEngine;
using UnityEngine.Networking;

namespace com.noorcon.rpg2e
{
	[Serializable]
	public class PlayerAgent : MonoBehaviour
	{
		public PlayerCharacter playerCharacterData;

		public bool NetworkGame = false;

		void Awake()
		{
			PlayerCharacter tmp = new PlayerCharacter();
			tmp.Name = "Maximilian";
			tmp.Tag = transform.gameObject.tag;
			tmp.CharacterGameObject = transform.gameObject;
			tmp.Health = 100.0f;
			tmp.Defense = 50.0f;
			tmp.Description = "Our Hero";
			tmp.Dexterity = 33.0f;
			tmp.Intelligence = 80.0f;
			tmp.Strength = 60.0f;

			playerCharacterData = tmp;
		}

		// Use this for initialization
		void Start()
		{

		}

		// Update is called once per frame
		void Update()
		{
			if (playerCharacterData.Health < 0.0f)
			{
				playerCharacterData.Health = 0.0f;

				if (!NetworkGame)
					transform.GetComponent<BarbarianCharacterController>().die = true;
				else
				{
					transform.GetComponent<BarbarianCharacterNetworkController>().die = true;
					//RpcKillPlayer();
				}
			}
		}

		//[ClientRpc]
		//public void RpcKillPlayer()
		//{
		//	transform.GetComponent<BarbarianCharacterNetworkController>().die = true;
		//	//PlayerCharacter pc
		//	//	= gameObject.GetComponent<PlayerAgent>().playerCharacterData;
		//	//float impact = (pc.Strength + pc.Health) / 100.0f;

		//	//// Need to replace with new Network version
		//	////GameMasterNetwork.instance.AttackEnemy(impact);
		//	//EnemyToAttack.GetComponent<BarbarianCharacterNetworkController>().Health -= 20.0f; // impact;

		//	//if (EnemyToAttack.GetComponent<BarbarianCharacterNetworkController>().Health <= 0.0f)
		//	//{
		//	//	EnemyToAttack.GetComponent<BarbarianCharacterNetworkController>().dead = true;
		//	//	//RpcPlayerCharacterIsDead();
		//	//}
		//}
	}
}
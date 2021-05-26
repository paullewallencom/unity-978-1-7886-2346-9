using UnityEngine;

namespace com.noorcon.rpg2e
{
	public class NpcAgent : MonoBehaviour
	{
		[SerializeField]
		public Npc NpcData;

		[SerializeField]
		public Transform CanvasAttachmentPoint;

		[SerializeField]
		public Canvas CanvasNpcStats;

		[SerializeField]
		public GameObject CanvasNpcStatsPrefab;

		public bool NetworkedGame = false;

		public void SetHealthValue(float value)
		{
			Debug.Log("SetHealthValue");
			CanvasNpcStats.GetComponent<NpcStatusUi>().imgHealthBar.fillAmount = value;
		}

		public void SetStrengthValue(float value)
		{
			CanvasNpcStats.GetComponent<NpcStatusUi>().imgManaBar.fillAmount = value;
		}

		//// Use this for initialization
		void Start()
		{
			// let's go ahead and instantiate our stats
			GameObject tmpCanvasGO = Instantiate(
				CanvasNpcStatsPrefab,
				new Vector3(CanvasAttachmentPoint.position.x, 2, 0),
				CanvasNpcStatsPrefab.transform.rotation) as GameObject;

			tmpCanvasGO.transform.SetParent(CanvasAttachmentPoint, false);

			CanvasNpcStats = tmpCanvasGO.GetComponent<Canvas>();
			CanvasNpcStats.GetComponent<NpcStatusUi>().imgHealthBar.fillAmount = 1.0f;
			CanvasNpcStats.GetComponent<NpcStatusUi>().imgManaBar.fillAmount = 1.0f;

			Npc tmp = new Npc();
			tmp.Tag = "Enemy";
			tmp.CharacterGameObject = transform.gameObject;
			tmp.Name = "B1";
			tmp.Health = 100.0f;
			tmp.Defense= 50.0f;
			tmp.Description = "The Beast";
			tmp.Dexterity = 33.0f;
			tmp.Intelligence = 80.0f;
			tmp.Strength = 60.0f;

			NpcData = tmp;
		}

		//// Update is called once per frame
		void Update()
		{
			if (NpcData.Health < 0.0f)
			{
				NpcData.Health = 0.0f;

				if(!NetworkedGame)
					transform.GetComponent<NpcBarbarianMovement>().die = true;
				else
					transform.GetComponent<NpcBarbarianMovementNetwork>().die = true;
			}
		}

	}
}
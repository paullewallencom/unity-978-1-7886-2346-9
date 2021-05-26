using UnityEngine;

namespace com.noorcon.rpg2e
{
	public class BarbarianCharacterController : MonoBehaviour
	{
		public Animator animator;
		public float directionDampTime;

		public float speed = 6.0f;
		public float h = 0.0f;
		public float v = 0.0f;

		bool attack = false;
		bool punch = false;
		bool run = false;

		bool jump = false;

		[HideInInspector]
		public bool die = false;
		bool dead = false;

		public bool EnemyInSight;
		public GameObject EnemyToAttack;

		Quaternion StartingAttackAngle = Quaternion.AngleAxis(-25, Vector3.up);
		Quaternion StepAttackAngle = Quaternion.AngleAxis(5, Vector3.up);
		Vector3 AttackDistance = new Vector3(0, 0, 2);

		// Use this for initialization
		void Start()
		{
			animator = GetComponent<Animator>() as Animator;
			EnemyInSight = false;
		}

		// Update is called once per frame
		private Vector3 moveDirection = Vector3.zero;

		void Update()
		{
			if (dead)
			{
				animator.SetBool("Die", false);
				return;
			}

			if (Input.GetKeyDown(KeyCode.C))
			{
				attack = true;
				this.GetComponent<IKHandle>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.C))
			{
				attack = false;
				this.GetComponent<IKHandle>().enabled = true;
			}
			animator.SetBool("Attack", attack);

			if (Input.GetKeyDown(KeyCode.P))
			{
				punch = true;
				this.GetComponent<IKHandle>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.P))
			{
				punch = false;
				this.GetComponent<IKHandle>().enabled = true;
			}
			animator.SetBool("Punch", punch);

			if (Input.GetKeyDown(KeyCode.LeftShift))
			{
				this.run = true;
				this.GetComponent<IKHandle>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.LeftShift))
			{
				this.run = false;
				this.GetComponent<IKHandle>().enabled = true;
			}
			animator.SetBool("Run", run);

			if (Input.GetKeyDown(KeyCode.Space))
			{
				jump = true;
				this.GetComponent<IKHandle>().enabled = false;
			}
			if (Input.GetKeyUp(KeyCode.Space))
			{
				jump = false;
				this.GetComponent<IKHandle>().enabled = true;
			}
			animator.SetBool("Jump", jump);

			//if (Input.GetKeyUp(KeyCode.I))
			//{
			//	die = true;
			//	dead = true;
			//	//SendMessage("Die");
			//}

			animator.SetBool("Die", die);

		}

		void FixedUpdate()
		{
			// The Inputs are defined in the Input Manager
			// get value for horizontal axis
			h = Input.GetAxis("Horizontal");
			// get value for vertical axis
			v = Input.GetAxis("Vertical");

			speed = new Vector2(h, v).sqrMagnitude;

			animator.SetFloat("Speed", speed);
			animator.SetFloat("Horizontal", h);
			animator.SetFloat("Vertical", v);

			#region used for attack range
			RaycastHit hitAttack;
			var angleAttack = transform.rotation * StartingAttackAngle;
			var directionAttack = angleAttack * AttackDistance;
			var posAttack = transform.position + Vector3.up;
			for (var i = 0; i < 10; i++)
			{
				Debug.DrawRay(posAttack, directionAttack, Color.yellow);
				if (Physics.Raycast(posAttack, directionAttack, out hitAttack, 1.0f))
				{
					var enemy = hitAttack.collider.GetComponent<NpcAgent>();
					if (enemy)
					{
						//Enemy was seen
						EnemyInSight = true;
						EnemyToAttack = hitAttack.collider.gameObject;
						GameMaster.instance.ClosestNpcEnemy = hitAttack.collider.gameObject;
					}
					else
					{
						this.EnemyInSight = false;
					}
				}
				directionAttack = StepAttackAngle * directionAttack;
			}
			#endregion

			if (EnemyInSight)
			{
				if (animator.GetFloat("Attack1") == 1.0f)
				{
					PlayerCharacter pc 
						= gameObject.GetComponent<PlayerAgent>().playerCharacterData;
					float impact = (pc.Strength + pc.Health) / 100.0f;

					GameMaster.instance.AttackEnemy(impact);
				}
			}
		}
	}
}
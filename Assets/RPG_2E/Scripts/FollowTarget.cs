using UnityEngine;

namespace com.noorcon.rpg2e
{
	public class FollowTarget : MonoBehaviour
	{
		public float distanceAway;
		public float distanceUp;
		public float smooth;

		public Transform Follow;
		public Vector3 TargetPosition;

		public bool FollowMe = false;

		// Use this for initialization
		void Start()
		{
			if (FollowMe)
				Follow = GameObject.FindGameObjectWithTag("Follow").transform;
		}

		// Update is called once per frame
		void Update()
		{

		}

		void LateUpdate()
		{
			if (FollowMe)
			{
				TargetPosition = Follow.position + Follow.up * distanceUp - Follow.forward * distanceAway;

				transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.deltaTime * smooth);
				transform.LookAt(Follow);
			}
		}
	}
}
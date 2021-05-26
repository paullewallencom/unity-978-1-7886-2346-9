using UnityEngine;

namespace com.noorcon.rpg2e
{
	public class IKHandle : MonoBehaviour
	{
		Animator anim;

		#region USED FOR MANUAL TESTING
		Transform leftIKTarget;
		Transform rightIKTarget;

		Transform hintLeft;
		Transform hintRight;

		float ikWeight = 1f;
		#endregion

		// to make it dynamic
		[Header("Dynamic IK Values")]
		Vector3 LeftFootPosition;
		Vector3 RightFootPosition;

		Quaternion LeftFootRotation;
		Quaternion RightFootRotation;

		float LeftFootWeight;
		float RightFootWeight;

		public Transform LeftFoot;
		public Transform RightFoot;

		[Header("Adjustment Properties for IK")]
		public float OffsetY;

		public float LookIkWeight = 1.0f;
		public float BodyWeight = 0.7f;
		public float HeadWeight = 0.9f;
		public float EyesWeight = 1.0f;
		public float ClampWeight = 1.0f;

		public Transform LookPosition;

		//public Transform diePosition;
		//public Transform body;

		// Use this for initialization
		void Start()
		{
			anim = GetComponent<Animator>();

			LeftFoot = anim.GetBoneTransform(HumanBodyBones.LeftFoot);
			RightFoot = anim.GetBoneTransform(HumanBodyBones.RightFoot);

			LeftFootRotation = LeftFoot.rotation;
			RightFootRotation = RightFoot.rotation;

		}

		// Update is called once per frame
		void Update()
		{
			// we can set the look position here somewhere
			Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

			//Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 15, Color.cyan);

			//lookPosition.position = ray.GetPoint(15);

			RaycastHit leftHit;
			RaycastHit rightHit;

			Vector3 lpos = LeftFoot.TransformPoint(Vector3.zero);
			Vector3 rpos = RightFoot.TransformPoint(Vector3.zero);

			if (Physics.Raycast(lpos, -Vector3.up, out leftHit, 1))
			{
				LeftFootPosition = leftHit.point;
				LeftFootRotation = Quaternion.FromToRotation(transform.up, leftHit.normal) * transform.rotation;
			}

			if (Physics.Raycast(rpos, -Vector3.up, out rightHit, 1))
			{
				RightFootPosition = rightHit.point;
				RightFootRotation = Quaternion.FromToRotation(transform.up, rightHit.normal) * transform.rotation;
			}
		}

		//public bool Die = false;
		//public void Died()
		//{

		//	Debug.Log("I AM DEAD!");
		//	this.Die = true;
		//}

		void OnAnimatorIK()
		{
			LeftFootWeight = anim.GetFloat("MyLeftFoot");
			RightFootWeight = anim.GetFloat("MyRightFoot");

			anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, LeftFootWeight);
			anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, RightFootWeight);
			anim.SetIKPosition(AvatarIKGoal.LeftFoot, LeftFootPosition + new Vector3(0f, OffsetY, 0f));
			anim.SetIKPosition(AvatarIKGoal.RightFoot, RightFootPosition + new Vector3(0f, OffsetY, 0f));

			anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, LeftFootWeight);
			anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, RightFootWeight);
			anim.SetIKRotation(AvatarIKGoal.LeftFoot, LeftFootRotation);
			anim.SetIKRotation(AvatarIKGoal.RightFoot, RightFootRotation);

		}
	}
}
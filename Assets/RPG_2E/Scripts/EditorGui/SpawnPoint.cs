using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.noorcon.rpg2e
{
	public class SpawnPoint : MonoBehaviour
	{
		public void OnDrawGizmos()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireCube(transform.position, Vector3.one * 0.5f);
		}
	}
}
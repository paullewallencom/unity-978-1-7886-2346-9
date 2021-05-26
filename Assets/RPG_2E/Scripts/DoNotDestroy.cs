using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.noorcon.rpg2e
{
	public class DoNotDestroy : MonoBehaviour
	{

		// Use this for initialization
		void Start()
		{
			DontDestroyOnLoad(this);
		}

		// Update is called once per frame
		void Update()
		{

		}
	}
}
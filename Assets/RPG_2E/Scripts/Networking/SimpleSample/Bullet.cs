using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class Bullet : NetworkBehaviour
{
	[SyncVar]
	public Color myColor;

	private void Start()
	{
		GetComponent<MeshRenderer>().material.color = myColor;
	}

	void OnCollisionEnter(Collision collision)
  {
    var hit = collision.gameObject;
    var health = hit.GetComponent<Health>();
    if (health != null)
    {
      health.TakeDamage(10);
    }

    Destroy(gameObject);
  }
}

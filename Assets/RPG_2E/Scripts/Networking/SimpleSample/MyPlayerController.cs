using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class MyPlayerController : NetworkBehaviour
{

	public Transform mainCamera;
	public float cameraDistance = 16f;
	public float cameraHeight = 16f;
	public Vector3 cameraOffset;

	[SyncVar]
	public Color myColor;

  public GameObject bulletPrefab;
  public Transform bulletSpawn;

	//public override void OnStartLocalPlayer()
	//{
	//	GetComponent<MeshRenderer>().material.color = myColor;
	//}

	private void Start()
	{
		GetComponent<MeshRenderer>().material.color = myColor;

		cameraOffset = new Vector3(0f, cameraHeight, -cameraDistance);
		mainCamera = Camera.main.transform;
		MoveCamera();
	}

	void Update()
  {
    // only execute the following code if local player ...
    if (!isLocalPlayer)
      return;

    var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
    var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

    transform.Rotate(0, x, 0);
    transform.Translate(0, 0, z);

    if (Input.GetKeyDown(KeyCode.Space))
    {
      CmdFire();
    }

		MoveCamera();
  }

	[Command]
  void CmdFire()
  {
    // Create the Bullet from the Bullet Prefab
    var bullet = Instantiate(
        bulletPrefab,
        bulletSpawn.position,
        bulletSpawn.rotation) as GameObject;

    // Add velocity to the bullet
    bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * 6;

    //if(isLocalPlayer)
      bullet.GetComponent<Bullet>().myColor = myColor;


		// Spawn the bullet on the Clients
		NetworkServer.Spawn(bullet);

    // Destroy the bullet after 2 seconds
    Destroy(bullet, 2.0f);
  }

	void MoveCamera()
	{
		mainCamera.position = transform.position;
		mainCamera.rotation = transform.rotation;
		mainCamera.Translate(cameraOffset);
		mainCamera.LookAt(transform);
	}

}

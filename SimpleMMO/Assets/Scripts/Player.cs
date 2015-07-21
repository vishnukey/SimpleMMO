using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {

    int moveX = 0;
    int moveY = 0;
	public float speed = 10f;
	private Rigidbody rigidbody;
	public GameObject gameObject;

	[SyncVar]
	public Color colour;

	// Use this for initialization
	void Start () 
	{
		rigidbody = gameObject.GetComponent<Rigidbody>();
		colour = new Color(0.5f, 0.5f, 0.5f);
		GetComponent<Renderer>().material.color = colour;
		InvokeRepeating("UpdateColour", 1f, 0.5f);
	}

	void UpdateColour()
	{
		GetComponent<Renderer>().material.color = colour;
	}
	
	// Update is called once per frame
	void Update () 
	{
        DoMovement();
	}

    //[Command]	
	void DoMovement()
    {

        if (!isLocalPlayer)
        {
            return;
        }

		print("Moving");

		/*
        int oldMoveX = moveX;
        int  oldMoveY = moveY;

        if (Input.GetKey(KeyCode.W)) {
            moveY += 1;
        }
        if (Input.GetKey(KeyCode.S)) {
            moveY -= 1;
        }
        if (Input.GetKey(KeyCode.A)) {
            moveX -= 1;
        }
        if (Input.GetKey(KeyCode.D)) {
            moveX += 1;
        }

        if (moveX != oldMoveX || moveY != oldMoveY) {
			rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * moveY * Time.deltaTime);
			rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * moveX * Time.deltaTime);

        }
		*/

		if (Input.GetKey(KeyCode.W))
			rigidbody.MovePosition(rigidbody.position + Vector3.forward * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.S))
			rigidbody.MovePosition(rigidbody.position - Vector3.forward * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.D))
			rigidbody.MovePosition(rigidbody.position + Vector3.right * speed * Time.deltaTime);

		if (Input.GetKey(KeyCode.A))
			rigidbody.MovePosition(rigidbody.position - Vector3.right * speed * Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour {
	 
	 
    
	public float moveSpeed= 10.0f;
    public float drag = 0.5f;
    public float terminalRotationSpeed = 25.0f;
    public VirtualJoystick moveJoystick;

    private Rigidbody controller;
    private Transform camTransform;

    private int count;
	public Text countText;
	public Text winText;

    

	private void Start () {
        controller = GetComponent<Rigidbody>();
        controller.maxAngularVelocity = terminalRotationSpeed;
        controller.drag = drag;

        camTransform = Camera.main.transform;

        
		count = 0;
		SetCountText ();
		winText.text = "";
        
	}

	private void Update () {

        Vector3 dir = Vector3.zero;

        dir.x = Input.GetAxis("Horizontal");
        dir.z = Input.GetAxis("Vertical");

        if (dir.magnitude > 1)
            dir.Normalize ();

        if (moveJoystick.InputDirection != Vector3.zero)
        {
            dir = moveJoystick.InputDirection;
        }

        Vector3 rotatedDir = camTransform.TransformDirection(dir);
        rotatedDir = new Vector3(rotatedDir.x, 0, rotatedDir.z);
        rotatedDir = rotatedDir.normalized * dir.magnitude;

        controller.AddForce(rotatedDir * moveSpeed);
       
    }


	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Capsule")) {
			other.gameObject.SetActive (false);
			count = count + 500;
			SetCountText ();
		}
		else if (other.gameObject.CompareTag ("Cube")) {
			other.gameObject.SetActive (false);
			count = count + 100;
			SetCountText ();
		}
	}
	void SetCountText () {
		countText.text = "Score: " + count.ToString (); 
		if (count >= 1900) {
			winText.text = "You Win!";
		}
        else if (count < 1900)
        {
            winText.text = "Score 1900 To Win!";
        }
	}

}

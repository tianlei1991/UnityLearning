using UnityEngine;
using System.Collections;

public class PickUpbehav : MonoBehaviour {
	private Rigidbody rb;
	public float sizeValue;
	private PlayerController player;
	void OncollisionEnter (Collider other){
		if (gameObject.CompareTag ("pickup") && other.gameObject.CompareTag ("player")) {
			float mass = rb.mass;
			transform.parent = other.gameObject.transform;
			other.gameObject.GetComponent<Rigidbody> ().mass += mass;
			Destroy (rb);
			player = other.gameObject.GetComponent<PlayerController> ();
			player.SizeValue = sizeValue;
		} else if (gameObject.CompareTag ("resetSize") && other.gameObject.CompareTag ("Player")) {
			player = other.gameObject.GetComponent<PlayerController> ();
			player.removeChildren ();
			Destroy (gameObject);
			player.SizeValue = -player.SizeValue;

		} else if (gameObject.CompareTag ("levelDown") && other.gameObject.CompareTag ("Player")) {
			
			player = other.gameObject.GetComponent<PlayerController> ();
			other.gameObject.GetComponent<Rigidbody> ().mass = other.gameObject.GetComponent<Rigidbody> ().mass;
			player.removeChildren ();
			Destroy (gameObject);
			player.shrink ();
		}
		
	

	
	
	}
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

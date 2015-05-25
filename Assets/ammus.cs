using UnityEngine;
using System.Collections;

public class ammus : MonoBehaviour {
	public int dmg = 5;
	public float speed = 50;
	public string omistaja;
	Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		Destroy (gameObject, 5);
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void FixedUpdate(){
		rb.AddForce (transform.up * speed);

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag != omistaja && other.tag != "Untagged") {
			Debug.Log ("Osui "+other.tag);
			other.SendMessageUpwards ("TakeDamage", dmg, SendMessageOptions.DontRequireReceiver);
			Destroy (gameObject);
		}

	}
}

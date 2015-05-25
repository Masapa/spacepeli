using UnityEngine;
using System.Collections;



public class asteroidi : MonoBehaviour {

	public int hp = 1;
	public int speed;
	public int rotaatio;
	void TakeDamage(int dbm){

		hp -= dbm;

	}

	Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 10);
		rb = GetComponent<Rigidbody2D> ();
		float tmp = Random.Range (1.0f, 3.0f);
		transform.localScale = new Vector2 (tmp, tmp);

		rotaatio = Random.Range (0, 360);


	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.rotation = rotaatio;
		if (hp <= 0)
			Destroy (gameObject);

		rb.AddForce (transform.up * speed);
	}
}

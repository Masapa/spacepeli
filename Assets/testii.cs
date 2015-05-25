using UnityEngine;
using System.Collections;

public class testii : MonoBehaviour {
	public GameObject target;
	Rigidbody2D rb;
	Vector2 dir;
	Vector2 forward;
	Vector2 side;
	Vector2 cross;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		forward = transform.up;
		dir = target.transform.position - transform.position;

	}


	// Update is called once per frame
	void Update () {
		dir = target.transform.position - transform.position;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg-90	;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		rb.AddForce(transform.up * 50);
		rb.AddForce (transform.right * 10);
	}
}

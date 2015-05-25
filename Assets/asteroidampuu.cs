using UnityEngine;
using System.Collections;

public class asteroidampuu : MonoBehaviour {
	GameObject target;
	// Use this for initialization
	void Start () {
	
	}
	float timer;


	void shoot(){
		if (timer <= Time.time) {
			GameObject tmp = Instantiate (Resources.Load ("ammus"), transform.position, transform.rotation) as GameObject;
			ammus tmp2 = tmp.GetComponent<ammus> ();
			tmp2.dmg = 10;
			tmp2.omistaja = "Player";
			tmp2.speed = 80;
			timer = Time.time + 0.1f;
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.tag == "asteroid") {

			target = other.gameObject;

			Vector2 katso = other.transform.position - transform.position;
			float angle = Mathf.Atan2 (katso.y, katso.x) * Mathf.Rad2Deg-90	;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);

			shoot ();
			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}

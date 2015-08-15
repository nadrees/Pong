using UnityEngine;

public class BallController : MonoBehaviour {
	public float Speed;

	Rigidbody rigidBody;

	void Start () {
		rigidBody = GetComponent<Rigidbody>();

		var lrStartingDirection = Random.value < .5 ? -1 : 1;
		var udStartingDirection = 1; //Random.value * 2 - 1;
		rigidBody.velocity = (new Vector3(lrStartingDirection, udStartingDirection) * Speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Wall"))
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y * -1);
	}
}

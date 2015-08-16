using UnityEngine;

public class BallController : MonoBehaviour {
	public static BallController Instance { get; private set; }

	public float InitialSpeed;

	Rigidbody rigidBody;

	void Start () {
		Instance = this;

		rigidBody = GetComponent<Rigidbody>();

		var lrStartingDirection = Random.value < .5 ? -1 : 1;
		var udStartingDirection = Random.value * 2 - 1;
		rigidBody.velocity = (new Vector3(lrStartingDirection, udStartingDirection) * InitialSpeed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Wall"))
			rigidBody.velocity = new Vector3(rigidBody.velocity.x, rigidBody.velocity.y * -1);
		else if (other.CompareTag("Player")) {
			var angle = (transform.position - other.transform.position) / other.bounds.size.y;
			angle *= InitialSpeed;
			rigidBody.velocity = new Vector3(rigidBody.velocity.x * -1, angle.y);
		}
	}
}

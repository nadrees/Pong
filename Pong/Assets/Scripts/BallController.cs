using UnityEngine;

public class BallController : MonoBehaviour {
	public static BallController Instance { get; private set; }

	public float InitialSpeed;
	public float BounceStrength;

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
			var angle = Vector2.Angle(other.transform.position, transform.position);
			if (other.transform.position.y > transform.position.y)
				angle *= -1;
			rigidBody.velocity = new Vector3(rigidBody.velocity.x * -1, angle) * BounceStrength;
		}
	}
}

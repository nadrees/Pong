using UnityEngine;

public class BallController : MonoBehaviour {
	public static BallController Instance { get; private set; }

	public float InitialSpeed;
	public float SpeedBump;
	public int BumpFrequency;

	Rigidbody rigidBody;
	float lrDirection;
	float udDirection;
	float currentSpeed;
	int bumpCount;

	void Start () {
		Instance = this;

		rigidBody = GetComponent<Rigidbody>();

		lrDirection = Random.value < .5 ? -1 : 1;
		udDirection = Random.value * 2 - 1;
		rigidBody.velocity = (new Vector3(lrDirection, udDirection) * InitialSpeed);

		currentSpeed = InitialSpeed;
		bumpCount = 0;
	}

	void OnTriggerEnter(Collider other) {
		if (other.CompareTag("Goal")) {
			other.gameObject.GetComponent<GoalController>().IncrimentScore();
			GameController.Instance.GoalScored();

			Destroy(this.gameObject);
			Instance = null;
		}
		else if (other.CompareTag("Wall"))
			udDirection *= -1;
		else if (other.CompareTag("Player")) {
			bumpCount++;
			if (bumpCount == BumpFrequency) {
				bumpCount = 0;
				currentSpeed *= SpeedBump;
			}

			var angle = (transform.position - other.transform.position) / other.bounds.size.y;
			udDirection = angle.y;

			lrDirection *= -1;
		}

		rigidBody.velocity = new Vector2(lrDirection, udDirection) * currentSpeed;
	}
}

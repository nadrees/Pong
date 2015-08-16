using UnityEngine;

public class PaddleController : MonoBehaviour {
	public float MaxTopPosition;
	public float MaxBottomPosition;
	public bool IsLeftPaddle;
	public float Speed;

	Rigidbody rigidBody;

	void Start() {
		rigidBody = GetComponent<Rigidbody>();
	}

	void FixedUpdate() {
		if (IsLeftPaddle) {
			rigidBody.velocity = new Vector2(0, Input.GetAxis("VerticalLeft"));
		}
		else {
			rigidBody.velocity = new Vector2(0, Input.GetAxis("VerticalRight"));
		}
		rigidBody.velocity *= Speed;
	}
}

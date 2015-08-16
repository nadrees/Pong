using UnityEngine;

public abstract class PaddleController : MonoBehaviour {
	public float MaxTopPosition;
	public float MaxBottomPosition;

	protected abstract float GetUpdatedYPosition();

	void Update() {
		transform.position = new Vector3(transform.position.x, 
	                                 	 Mathf.Clamp(GetUpdatedYPosition(), MaxBottomPosition, MaxTopPosition));
	}
}

using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public Text StartText;
	public Text GoalText;
	public BallController Ball;

	bool gameStarted = false;

	void Update () {
		if (!gameStarted && Input.GetKeyDown(KeyCode.Space)) {
			GoalText.enabled = false;
			StartText.enabled = false;

			Instantiate(Ball, new Vector3(), Quaternion.identity);

			gameStarted = true;
		}
	}
}

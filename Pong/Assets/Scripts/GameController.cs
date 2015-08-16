using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public static GameController Instance { get; private set; }

	public Text StartText;
	public Text GoalText;
	public BallController Ball;

	bool gameStarted = false;

	public void GoalScored() {
		gameStarted = false;
		StartText.enabled = true;
		GoalText.enabled = true;
	}

	void Start() {
		Instance = this;
		GoalText.enabled = false;
	}

	void Update () {
		if (!gameStarted && Input.GetKeyDown(KeyCode.Space)) {
			GoalText.enabled = false;
			StartText.enabled = false;

			Instantiate(Ball, new Vector3(), Quaternion.identity);

			gameStarted = true;
		}
	}
}

using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
	public static GameController Instance { get; private set; }

	public Text StartText;
	public Text GoalText;
	public Text ToasterText;

	public BallController Ball;
	public float BlinkSpeed;
	public float ToastMessageDisplayLength;

	bool gameStarted = false;

	public void GoalScored() {
		gameStarted = false;
		StartText.enabled = true;
		StartCoroutine(BlinkText());
	}

	public void DisplayToast(string message) {
		ToasterText.text = message;
		StartCoroutine(DisplayToastMessage());
	}

	void Start() {
		Instance = this;
		GoalText.enabled = false;
		ToasterText.enabled = false;
	}

	void Update () {
		if (!gameStarted && Input.GetKeyDown(KeyCode.Space)) {
			GoalText.enabled = false;
			StartText.enabled = false;

			Instantiate(Ball, new Vector3(), Quaternion.identity);

			gameStarted = true;
		}
	}

	IEnumerator DisplayToastMessage() {
		ToasterText.enabled = true;
		yield return new WaitForSeconds(ToastMessageDisplayLength);
		ToasterText.enabled = false;
	}

	IEnumerator BlinkText() {
		while (!gameStarted) {
			GoalText.enabled = true;
			yield return new WaitForSeconds(BlinkSpeed);
			GoalText.enabled = false;
			yield return new WaitForSeconds(BlinkSpeed);
		}
	}
}

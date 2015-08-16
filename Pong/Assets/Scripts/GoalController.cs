using UnityEngine;
using UnityEngine.UI;

public class GoalController : MonoBehaviour {
	public Text ScoreDisplay;

	int Score = 0;

	public void IncrimentScore() {
		Score++;
		UpdateDisplay();
	}

	void Start() {
		if (ScoreDisplay == null)
			Debug.LogError("ScoreDisplay = null");
		UpdateDisplay();
	}

	void UpdateDisplay() {
		ScoreDisplay.text = "" + Score;
	}
}

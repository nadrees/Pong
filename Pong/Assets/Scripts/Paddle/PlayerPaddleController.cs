using UnityEngine;

public class PlayerPaddleController : PaddleController {
	protected override float GetUpdatedYPosition ()	{
		var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		return mousePosition.y;
	}
}

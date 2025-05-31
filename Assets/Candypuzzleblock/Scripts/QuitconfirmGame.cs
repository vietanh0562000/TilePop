using UnityEngine;
using System.Collections;

public class QuitconfirmGame : MonoBehaviour
{
	/// <summary>
	/// Raises the close button pressed event.
	/// </summary>
	public void OnStayButtonPressed ()
	{
		if (InputManager.Instance.CanInput ()) {
			AudioManager.Instance.PlayButtonClickSound ();
			StackManager.Instance.OnCloseButtonPressed ();
		}
	}

	/// <summary>
	/// Raises the ok button pressed event.
	/// </summary>
	public void OnQuitButtonPressed ()
	{
		if (InputManager.Instance.CanInput ()) {
			AudioManager.Instance.PlayButtonClickSound ();
			GameController.Instance.QuitGame ();
			StackManager.Instance.OnCloseButtonPressed ();
		}
	}
}

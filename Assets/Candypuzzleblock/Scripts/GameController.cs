using UnityEngine;
using System.Collections;
using TMPro;

public class GameController : Singleton<GameController> 
{
	public static GameMode gameMode = GameMode.CLASSIC;
	public Canvas UICanvas; 
	
	public TextMeshProUGUI ResetPowerQuantityText;
	public TextMeshProUGUI ClearPowerQuantityText;

	// Checks if interner is available or not.
	public bool isInternetAvailable()
	{
		if (Application.internetReachability == NetworkReachability.ReachableViaCarrierDataNetwork || Application.internetReachability == NetworkReachability.ReachableViaLocalAreaNetwork) {
			return true;
		}
		return false;
	}

	/// <summary>
	/// Quits the game.
	/// </summary>
	public void QuitGame()
	{
		Invoke ("QuitGameWithDelay", 0.5F);
	}

	/// <summary>
	/// Quits the game with delay.
	/// </summary>
	void QuitGameWithDelay ()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit ();
		#endif
	}

	public void TryUseResetPower()
	{
		var resetPowerQuantity = PlayerPrefs.GetInt("ResetPower");
		if (resetPowerQuantity < 1)
		{
			GamePlayUI.Instance.ShowShop();
		}
		else
		{
			GamePlay.Instance.ResetShape();	
			UpdateResetPowerQuantityText();
		}
	}

	public void TryUseClearPower()
	{
		var clearPowerQuantity = PlayerPrefs.GetInt("ClearPower");
		if (clearPowerQuantity < 1)
		{
			GamePlayUI.Instance.ShowShop();
		}
		else
		{
			GamePlay.Instance.ClearMap();
			UpdateClearPowerQuantityText();
		}
	}

	public void UpdateResetPowerQuantityText()
	{
		var resetPowerQuantity = PlayerPrefs.GetInt("ResetPower");
		ResetPowerQuantityText.text = resetPowerQuantity.ToString();
	}
	
	public void UpdateClearPowerQuantityText()
	{
		var clearPowerQuantity = PlayerPrefs.GetInt("ClearPower");
		ClearPowerQuantityText.text = clearPowerQuantity.ToString();
	}
	// Use this for initialization
	void Start () 
	{
		UpdateResetPowerQuantityText();
		UpdateClearPowerQuantityText();
	}
}

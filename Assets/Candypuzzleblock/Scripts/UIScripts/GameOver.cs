﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {

	[SerializeField] Text txtScore;
	[SerializeField] private Text txtBestScore;
	[SerializeField] private Text txtCoinReward;

	public void SetLevelScore(int score, int coinReward)
	{
		int bestScore = PlayerPrefs.GetInt ("BestScore_" + GameController.gameMode.ToString (), score);

		if (score >= bestScore) {
			PlayerPrefs.SetInt ("BestScore_" + GameController.gameMode.ToString (), score);
		}

		txtScore.text = string.Format("{0:#,#.}", score.ToString("0"));
        txtBestScore.text = string.Format("{0:#,#.}", (PlayerPrefs.GetInt("BestScore_" +
                                                                          GameController.gameMode.ToString()).ToString("0")));
		txtCoinReward.text = string.Format("{0:#,#.}", coinReward.ToString("0"));

		CurrencyManager.Instance.AddCoinBalance (coinReward);
	}



	public void OnHomeButtonPressed()
	{
		if (InputManager.Instance.CanInput ()) {
			AudioManager.Instance.PlayButtonClickSound ();
			StackManager.Instance.OnCloseButtonPressed ();
		}
	}

	public void OnReplayButtonPressed()
	{
		if (InputManager.Instance.CanInput ()) {
			AudioManager.Instance.PlayButtonClickSound ();
			StackManager.Instance.RestartGamePlay ();
		}
	}

    public void OnRewardedVideoButtonPressed()
    {
        if(InputManager.Instance.CanInput())
        {
            AudioManager.Instance.PlayButtonClickSound();
            StackManager.Instance.ContinueGameplay();
            GamePlay.Instance.InstantRescue();
        }
    }

    public void Rate()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.alhamad.legopuzzleblocklego");
    }
}

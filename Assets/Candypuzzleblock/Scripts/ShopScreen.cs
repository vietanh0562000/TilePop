using UnityEngine;
using System.Collections;

public class ShopScreen : MonoBehaviour
{
    bool hasGameExit = false;

    /// <summary>
    /// Raises the enable event.
    /// </summary>
    void OnEnable()
    {
        #region time mode
        if (GamePlay.Instance != null && (GameController.gameMode == GameMode.TIMED || GameController.gameMode == GameMode.CHALLENGE)) {
            GamePlay.Instance.timeSlider.PauseTimer ();
        }
        #endregion
    }

    /// <summary>
    /// Raises the disable event.
    /// </summary>
    void OnDisable()
    {
        #region time mode
        if(!hasGameExit)
        {
            if (GamePlay.Instance != null && (GameController.gameMode == GameMode.TIMED || GameController.gameMode == GameMode.CHALLENGE)) {
                GamePlay.Instance.timeSlider.ResumeTimer ();
            }
        }
        #endregion
    }
    
    /// <summary>
    /// Raises the close button pressed event.
    /// 
    /// </summary>
    public void OnCloseButtonPressed ()
    {
        if (InputManager.Instance.CanInput ()) {
            AudioManager.Instance.PlayButtonClickSound ();
            StackManager.Instance.OnCloseButtonPressed ();
        }
    }
}
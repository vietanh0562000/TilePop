using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

 public class RateManager : Singleton<RateManager>
{
    [SerializeField]
    private RateBox rateBox;

    [SerializeField]
    private Text playCountText;

    public int countToRate =0;

    [HideInInspector]
    public int playCount;

    [HideInInspector]
    public bool rateOff = false;

    public void ClickPlay()
    {
        playCount++;
        playCountText.text = playCount.ToString();

        if (playCount % countToRate == 0 && !rateOff)

        {
            rateBox.gameObject.SetActive(true);
        }
    }
}

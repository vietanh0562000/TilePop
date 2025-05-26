using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RateBox : MonoBehaviour
{
       public void ClickNoThanks()
       {
           RateManager.Instance.rateOff = true;
           gameObject.SetActive(false);
       }
       public void ClickLater()
       {
           gameObject.SetActive(false);
       }
       public void ClickRateNow()
       {
           Application.OpenURL("https://play.google.com/store/apps/details?id=com.alhamad.legopuzzleblock");
           gameObject.SetActive(false);
       }

}

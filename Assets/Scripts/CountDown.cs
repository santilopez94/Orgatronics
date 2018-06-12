using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using UnityEngine.Networking;
using System.Xml;

public class CountDown : MonoBehaviour
{

    public int timeLeft = 60; //Seconds Overall
    public Text countdown; //UI Text Object
    public static bool flag = true;

    void Start()
    {
        StartCoroutine("LoseTime");
        countdown = GameObject.Find("Tiempo").GetComponent<Text>();
        countdown.text = "" + timeLeft;
        Time.timeScale = 1;
        flag = true;
    }

    public void cambiarBandera()
    {
        flag = false;
    }

    void Update()
    {
        countdown.text = ("" + timeLeft);
    }

    IEnumerator LoseTime()
    {
        bool flag = true;
        while (flag==true)
        {
            if (timeLeft>0)
            {
                yield return new WaitForSeconds(1);
                timeLeft--;
            }
            else
            {
                flag=false;
            }
            
        }
    }
}
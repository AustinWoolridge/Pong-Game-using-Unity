using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

public class WebConnection : MonoBehaviour
{
    string leftPlayer;
    string rightPlayer;
    bool doOnce = false;
    // Start is called before the first frame update

    void Update()
    {
        Debug.Log(Ball.gameOver);
        if (Ball.gameOver==true&&doOnce==false)
        {
            StartCoroutine(Register());
            doOnce = true;
        }

    }
    void OnEnable()
    {
        leftPlayer = PlayerPrefs.GetString("leftPlayer");
        rightPlayer = PlayerPrefs.GetString("rightPlayer");

    }
    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("score", GameManager.ballHit.ToString());
        if (Ball.isRightPlayerWin == true)
        {
            form.AddField("player", rightPlayer);
        }
        else
        {
            form.AddField("player", leftPlayer);
        }
        UnityWebRequest www =UnityWebRequest.Post("https://batuhanok1375.000webhostapp.com/index.php", form);

        yield return www.SendWebRequest();

    }

    public void ButtonCallIEnumerator()
    {
        StartCoroutine(Register());
    }
    

    public void ExitGame()
    {
        Application.Quit();
    }
}

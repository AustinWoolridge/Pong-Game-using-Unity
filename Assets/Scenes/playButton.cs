using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class playButton : MonoBehaviour
{
    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }

    public InputField InputFieldleft;
    public InputField InputFieldright;
    private void FixedUpdate()
    {
        PlayerPrefs.SetString("leftPlayer", InputFieldleft.text);
        PlayerPrefs.SetString("rightPlayer", InputFieldright.text);
    }
}

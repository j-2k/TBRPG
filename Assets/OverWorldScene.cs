using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorldScene : MonoBehaviour
{
    int currentscenenum;

    public void BacktoWorld()
    {
        currentscenenum = SceneManager.GetActiveScene().buildIndex;
        PlayerPrefs.SetInt("Continue_Game", currentscenenum);
        SceneManager.LoadScene(1);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void MoveToTitle()
    {
        SceneManager.LoadScene("TitleScene");
    }

    public void MoveToGame()
    {
        SceneManager.LoadScene("GameScene");
        Resume();
    }
}

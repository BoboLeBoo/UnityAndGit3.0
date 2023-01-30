using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenueScript : MonoBehaviour
{
    private int sceneBuildIdx = 1;
 [SerializeField] 
 GameObject pauseMenue;

    public void pause()
    {
        pauseMenue.SetActive(true);
        Time.timeScale = 0f;
    }

    public void resume()
    {
        pauseMenue.SetActive(false);
        Time.timeScale = 1f;
    }

    public void mainMenue()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneBuildIdx, LoadSceneMode.Single);
    }

}

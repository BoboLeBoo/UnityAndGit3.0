using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenueScript : MonoBehaviour
{
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
}

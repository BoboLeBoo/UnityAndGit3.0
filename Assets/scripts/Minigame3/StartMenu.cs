using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private int sceneBuildIdx = 0;

    public void Home()
    {
        SceneManager.LoadScene(sceneBuildIdx, LoadSceneMode.Single);
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }

}

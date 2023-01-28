using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{

    private int sceneBuildIdx = 1;
    

    void Start()
    {
        Screen.SetResolution(1920, 1080, false);
    }

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerMoverObj>())
        {
            Screen.SetResolution(540, 960, false);
            SceneManager.LoadScene(sceneBuildIdx, LoadSceneMode.Single);
            
        }
    }


}

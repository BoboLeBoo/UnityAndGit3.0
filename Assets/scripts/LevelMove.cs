using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMove : MonoBehaviour
{

    private int sceneBuildIdxmini1 = 1;
    private int sceneBuildIdxmini3 = 3;

    

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
            SceneManager.LoadScene(sceneBuildIdxmini1, LoadSceneMode.Single);
            
        }

        if(other.GetComponent <playerMoverMinigame3>())
        {
            SceneManager.LoadScene(sceneBuildIdxmini3, LoadSceneMode.Single);
        }
    }


}

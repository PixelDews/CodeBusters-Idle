using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLeft : MonoBehaviour
{
    private int sceneIndex;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex - 1;
            SceneManager.LoadScene(sceneIndex);
            Debug.Log(sceneIndex);
        }
        else if (Input.GetKey("right"))
        {
            sceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(sceneIndex);
            Debug.Log(sceneIndex);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToLeft : MonoBehaviour
{
    private int Farm;

    // Start is called before the first frame update
    void Start()
    {
        Farm = SceneManager.GetActiveScene().buildIndex - 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("left"))
        {
            SceneManager.LoadScene(Farm);
        }

    }
}
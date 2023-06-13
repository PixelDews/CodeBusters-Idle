using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToRight : MonoBehaviour
{
    private int Factory;

    // Start is called before the first frame update
    void Start()
    {
        Factory = SceneManager.GetActiveScene().buildIndex + 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("right"))
        {
            SceneManager.LoadScene(Factory);
        }

    }
}


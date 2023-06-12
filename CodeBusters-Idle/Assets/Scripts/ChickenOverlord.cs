using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenOverlord : MonoBehaviour
{

    

    public int eggCount = 0;


    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void OnMouseDown()
    {
        eggCount = eggCount + 1;
        print(eggCount);
        GameObject.Find("GameManager").GetComponent<GameManager>().EggIncrease();
    }
}

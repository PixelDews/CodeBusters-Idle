using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    [Header("Chicken Overlord")]
    public GameObject ChickenOverlord;

    [Header("UI")]
    public GameObject EggCountText;

    public int eggCount;

    public void EggIncrease()
    {
        eggCount++;
        EggCountText.GetComponent<TextMeshProUGUI>().text = "Egg Count: " + eggCount.ToString();
    }


    void Start()
    {
        eggCount = 0;
        EggCountText.GetComponent<TextMeshProUGUI>().text = "Egg Count: " + eggCount.ToString();

    }

    void Update()
    {
        
    }
}

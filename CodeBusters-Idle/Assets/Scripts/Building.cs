using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    public int cost;
    public GameObject prefab;

    public int goldIncrease;

    public float timeBtwIncreases;
    private float nextIncreaseTime;

    private GridBuildingSystem gb;

    private void Start()
    {
        gb = FindObjectOfType<GridBuildingSystem>();
    }

    private void update()
    {
        if(Time.time > nextIncreaseTime)
        {
            nextIncreaseTime = Time.time + timeBtwIncreases;
            gb.gold += goldIncrease;
        }
    }
}

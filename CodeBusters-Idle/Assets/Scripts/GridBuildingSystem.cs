using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GridBuildingSystem : MonoBehaviour
{
    [SerializeField]
    private List<FactoryObject> factoryObjectList;
    private FactoryObject factoryObject;

    private GridXY<GridObject> grid;
    private GameUtilities utils = new GameUtilities();

    public int gold;
    public TextMeshProUGUI goldDisplay;

    public GridBuildingSystem buildingToPlace;


    public CustomCursor customCursor;



    private void Awake()
    {
        int gridWidth = 8;
        int gridHeight = 16;
        float cellSize = 5f;
        grid = new GridXY<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXY<GridObject> g, int x, int y) => new GridObject(g, x, y));


        factoryObject = factoryObjectList[0];
    }

    public class GridObject
    {
        private GridXY<GridObject> grid;
        private int x;
        private int y;
        private Transform transform;

        public GridObject(GridXY<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void SetTransform(Transform transform)
        {
            this.transform = transform;
            grid.TriggerGridObjectChanged(x, y);
        }

        public void ClearTransform()
        {
            transform = null;
            grid.TriggerGridObjectChanged(x, y);

        }

        public bool CanBuild()
        {
            return transform == null;
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { factoryObject = factoryObjectList[0]; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { factoryObject = factoryObjectList[1]; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { factoryObject = factoryObjectList[2]; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { factoryObject = factoryObjectList[3]; }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { factoryObject = factoryObjectList[4]; }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { factoryObject = factoryObjectList[5]; }
        if (Input.GetKeyDown(KeyCode.Alpha7)) { factoryObject = factoryObjectList[6]; }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            factoryObject = factoryObjectList[7];


            if (Input.GetMouseButtonDown(0))
            {
                grid.GetXY(utils.GetMouseWorldPosition(), out int x, out int y);

                GridObject gridObject = grid.GetGridObject(x, y);

                if (gridObject.CanBuild())
                {
                    Transform builtTransform = Instantiate(factoryObject.prefab, grid.GetWorldPosition(x, y), Quaternion.identity);
                    gridObject.SetTransform(builtTransform);
                    Debug.Log(grid.GetWorldPosition(x, y));
                }
                else
                {
                    Debug.Log("Cannot Build!");
                }
            }

        }

        goldDisplay.text = gold.ToString();
    }

    public void BuyBuilding(GridBuildingSystem building)
    {
        if (gold >= building.cost)
        {
            customCursor.gameObject.SetActive(true);
            customCursor.GetComponent<SpriteRenderer>().sprite = building.GetComponent<SpriteRenderer>().sprite;
            Cursor.visible = false;

            gold -= building.cost;
            buildingToPlace = building;
            grid.SetActive(true);
        }
    }
}


   

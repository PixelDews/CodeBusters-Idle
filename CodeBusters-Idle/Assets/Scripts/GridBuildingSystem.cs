using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public CustomCursor customCursor;
    private Building buildingToPlace;
    [System.Serializable]
    public class FactoryObject
    {
        public Building buildingPrefab;
    }


    private void Awake()
    {
        int gridWidth = 8;
        int gridHeight = 16;
        float cellSize = 5f;
        grid = new GridXY<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXY<GridObject> g, int x, int y) => new GridObject(g, x, y));

        factoryObject = factoryObjectList[0];
    }

    private int mouseClickCount = 0;

    public void BuyBuilding(Building selectedBuilding) // Renamed the parameter to selectedBuilding
    {
        if (Input.GetMouseButtonDown(0))
        {
            mouseClickCount++;

            grid.GetXY(utils.GetMouseWorldPosition(), out int x, out int y);

            GridObject gridObject = grid.GetGridObject(x, y);

            if (gridObject.CanBuild())
            {
                // Calculate the index based on the number of mouse clicks
                int index = mouseClickCount - 1;

                // Check if the index is within the range of factoryObjectList
                if (index >= 0 && index < factoryObjectList.Count)
                {
                    factoryObject = factoryObjectList[index];
                    Building building = factoryObject.buildingPrefab;

                    if (gold >= selectedBuilding.cost) // Use selectedBuilding here
                    {
                        customCursor.gameObject.SetActive(true);
                        customCursor.GetComponent<SpriteRenderer>().sprite = selectedBuilding.GetComponent<SpriteRenderer>().sprite;
                        Cursor.visible = false;
                        Transform builtTransform = Instantiate(selectedBuilding.prefab.transform, grid.GetWorldPosition(x, y), Quaternion.identity);
                        gridObject.SetTransform(builtTransform);
                        gold -= selectedBuilding.cost;
                        goldDisplay.text = gold.ToString();
                    }
                    else
                    {
                        Debug.Log("Cannot Build! Not enough gold.");
                    }
                }
                else
                {
                    Debug.Log("Invalid factoryObject index.");
                }
            }
            else
            {
                Debug.Log("Cannot Build! Grid position is occupied.");
            }
        }
    }







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






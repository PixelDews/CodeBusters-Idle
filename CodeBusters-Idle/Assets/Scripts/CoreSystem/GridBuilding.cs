using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuilding : MonoBehaviour
{
    private GameUtilities utils = new GameUtilities();

    [SerializeField]
    private List<FactoryObject> factoryObjectList;
    private FactoryObject factoryObject;

    private GridXY<GridObject> grid; //REFERENCES GRIDXY
    public static int gridWidth = 8;
    public static int gridHeight = 16;
    public static float cellSize = 5f;


    public class GridObject
    {
        private GridXY<GridObject> grid;
        private int x;
        private int y;

        private ObjectPlaced objectPlaced; //BUILT OBJECT

        public GridObject(GridXY<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }

        public void SetObjectPlaced(ObjectPlaced objectPlaced)
        {
            this.objectPlaced = objectPlaced;
        }

        public ObjectPlaced GetObjectPlaced()
        {
            return objectPlaced;
        }

        //public void ClearTransform()
        //{
        //transform = null;
        //grid.TriggerGridObjectChanged(x, y);
        //}

        public bool CanBuild()
        {
            return objectPlaced == null;
        }

    }

    public List<ObjectPlaced> GetRowObjectPlacedList(int y)
    {
        List<ObjectPlaced> rowObjectPlacedList = new List<ObjectPlaced>();

        int x;

        if (y <= gridHeight && y >= 0)
        {
            for (x = 0; x < gridWidth; x++)
            {
                GridObject gridObject = grid.GetGridObject(x, y);
                ObjectPlaced objectPlaced = gridObject.GetObjectPlaced();
                rowObjectPlacedList.Add(objectPlaced);

                Debug.Log(rowObjectPlacedList[x]);
            }
            return rowObjectPlacedList;
        }
        else
        {
            Debug.Log("Error");
            return null;
        }
    }

    private void Awake()
    {
        //INITIALIZING GRID
        grid = new GridXY<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXY<GridObject> g, int x, int y) => new GridObject(g, x, y));
        factoryObject = factoryObjectList[0];
    }

    private void Update()
    {
        //ALL FACTORY TYPES
        if (Input.GetKeyDown(KeyCode.Alpha1)) { factoryObject = factoryObjectList[0]; }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { factoryObject = factoryObjectList[1]; }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { factoryObject = factoryObjectList[2]; }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { factoryObject = factoryObjectList[3]; }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { factoryObject = factoryObjectList[4]; }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { factoryObject = factoryObjectList[5]; }
        if (Input.GetKeyDown(KeyCode.Alpha7)) { factoryObject = factoryObjectList[6]; }
        if (Input.GetKeyDown(KeyCode.Alpha8)) { factoryObject = factoryObjectList[7]; }

        if (Input.GetMouseButtonDown(0))
        {
            grid.GetXY(utils.GetMouseWorldPosition(), out int x, out int y);

            GridObject gridObject = grid.GetGridObject(x, y);

            if (gridObject.CanBuild())
            {
                ObjectPlaced objectPlaced = ObjectPlaced.Create(factoryObject, grid.GetWorldPosition(x, y));
                objectPlaced.name = objectPlaced.name.Replace("(clone)", "").Trim();
                gridObject.SetObjectPlaced(objectPlaced);
            } else
            {
                Debug.Log("Cannot Build!");
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            grid.GetXY(utils.GetMouseWorldPosition(), out int x, out int y);
            Debug.Log(GetRowObjectPlacedList(y));

        }
    }
}


   

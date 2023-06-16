using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridBuildingSystem : MonoBehaviour
{

    private GridXY<GridObject> grid;


    private void Awake()
    {
        int gridWidth = 15;
        int gridHeight = 15;
        float cellSize = 5f;
        grid = new GridXY<GridObject>(gridWidth, gridHeight, cellSize, Vector3.zero, (GridXY<GridObject> g, int x, int y) => new GridObject(g, x, y));
    }

    public class GridObject
    {
        private GridXY<GridObject> grid;
        private int x;
        private int y;

        public GridObject(GridXY<GridObject> grid, int x, int y)
        {
            this.grid = grid;
            this.x = x;
            this.y = y;
        }
    }
}

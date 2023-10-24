 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem
{
    private int width;
    private int height;
    private int cellSize;
    private GridObject[,] gridObjectArray;

    public GridSystem(int width, int height, int cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width,height];

        for(int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition pos = new GridPosition(x,z);
                gridObjectArray[x, z] = new GridObject(this, pos);
            }
        }
    }

   public Vector3 GetWorldPosition(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0 , gridPosition.z) * cellSize;
    }

   public GridPosition GetGridPosition(Vector3 worldPosition)
    {
        return new GridPosition
        (
            Mathf.RoundToInt(worldPosition.x / cellSize),
            Mathf.RoundToInt(worldPosition.z / cellSize)
         );
    }

    public void CreateDebug(Transform debug)
    { 
        for(int x = 0; x<width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);

                Transform debugTransform = GameObject.Instantiate(debug, GetWorldPosition(gridPosition), Quaternion.identity);  
                GridDebugObject gridDebugObject = debugTransform.GetComponent<GridDebugObject>();     
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));
             } 
      
      
        }     
             
    }

    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x , gridPosition.z];
    }
 
}
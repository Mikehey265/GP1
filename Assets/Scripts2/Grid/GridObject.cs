using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject
{
    private GridSystem grid;
    private GridPosition pos;

    public GridObject(GridSystem grid, GridPosition pos)
    {
        this.grid = grid;
        this.pos = pos;
    }

    public override string ToString()
    {
        return pos.ToString();
    }
}


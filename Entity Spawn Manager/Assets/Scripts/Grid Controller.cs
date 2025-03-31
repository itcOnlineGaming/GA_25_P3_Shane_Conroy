using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject gridTile;
    public GameObject enityOne;
    public GameObject enityTwo;

    public int gridWidth;
    public int gridHeight;

    private float tileSpacing = 1.10f;

    // Button Function
    // When button clicked, will increase/decrease the grid's row size
    public void changeSizeRow(string value)
    {
        if (value == "more")
        {
            // Increase num of rows
        }
        else if(value == "less")
        {
            // Decrease num of rows
        }
    }

    public void createGrid()
    {
        // Zero checks
        if (gridWidth == 0)
        {
            gridWidth = 1;
        }
        if (gridHeight == 0)
        {
            gridHeight = 1;
        }

        // Create the grid
        for (int i = 0; i < gridWidth; i++)
        {
            for (int j = 0; j < gridHeight; j++)
            {
                Vector3 tilePos = new Vector3(i * tileSpacing, j * tileSpacing, 0);
                GameObject tile = Instantiate(gridTile, tilePos, Quaternion.identity, transform);
            }
        }
    }
}

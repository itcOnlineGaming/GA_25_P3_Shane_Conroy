using System.Collections.Generic;
using UnityEngine;

public class GridController : MonoBehaviour
{
    public GameObject gridTile;
    public List<GameObject> entities = new List<GameObject>();

    public int gridWidth = 4;
    public int gridHeight = 4;
    private float tileSpacing = 1.10f;

    [HideInInspector] public int[,] entityPositions;

    private void OnValidate()
    {
        // Ensure entityPositions array is correctly sized
        if (entityPositions == null || entityPositions.GetLength(0) != gridWidth || entityPositions.GetLength(1) != gridHeight)
        {
            entityPositions = new int[gridWidth, gridHeight];
        }
    }

    public void CreateGrid()
    {
        foreach (Transform child in transform)
        {
            if (child.tag == "Canvas")
            {
                continue;
            }
            Destroy(child.gameObject);
        }

        if (gridWidth <= 0)
            gridWidth = 1;
        if (gridHeight <= 0)
            gridHeight = 1;


        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Vector3 tilePos = new Vector3(x * tileSpacing, (gridHeight - 1 - y) * tileSpacing, 0);

                GameObject tile = Instantiate(gridTile, tilePos, Quaternion.identity, transform);

                int entityIndex = entityPositions[x, y] - 1;
                if (entityIndex >= 0 && entityIndex < entities.Count)
                {
                    GameObject entity = Instantiate(entities[entityIndex], tilePos, Quaternion.identity, transform);
                    entity.name = $"Entity_{entityIndex + 1}_{x}_{y}";
                }
            }
        }
    }
}

using UnityEngine;
using System.Collections.Generic;

public class GridController : MonoBehaviour
{
    [Header("Grid Settings")]
    public GameObject gridTile;
    public int gridWidth = 4;
    public int gridHeight = 4;
    private float tileSpacing = 1.10f;

    [Header("Entities")]
    public List<GameObject> entities = new List<GameObject>();
    public List<int> entityMinimums = new List<int>();

    [HideInInspector] public int[,] entityPositions;

    private void OnValidate()
    {
        // Ensure entityMinimums matches entity list length
        while (entityMinimums.Count < entities.Count)
            entityMinimums.Add(0);
        while (entityMinimums.Count > entities.Count)
            entityMinimums.RemoveAt(entityMinimums.Count - 1);

        // Ensure entityPositions matches grid size
        if (entityPositions == null ||
            entityPositions.GetLength(0) != gridWidth ||
            entityPositions.GetLength(1) != gridHeight)
        {
            entityPositions = new int[gridWidth, gridHeight];
        }
    }

    public void CreateGrid()
    {
#if UNITY_EDITOR
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
#endif

        gridWidth = Mathf.Max(1, gridWidth);
        gridHeight = Mathf.Max(1, gridHeight);

        // Ensure entityPositions is valid
        if (entityPositions == null ||
            entityPositions.GetLength(0) != gridWidth ||
            entityPositions.GetLength(1) != gridHeight)
        {
            entityPositions = new int[gridWidth, gridHeight];
        }

        // Collect empty cells
        List<Vector2Int> emptyPositions = new List<Vector2Int>();
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                if (entityPositions[x, y] == 0)
                {
                    emptyPositions.Add(new Vector2Int(x, y));
                }
            }
        }

        // Shuffle empty positions
        for (int i = 0; i < emptyPositions.Count; i++)
        {
            int randIndex = Random.Range(i, emptyPositions.Count);
            (emptyPositions[i], emptyPositions[randIndex]) = (emptyPositions[randIndex], emptyPositions[i]);
        }

        int positionIndex = 0;

        // Enforce minimums for each entity without overwriting manual placements
        for (int i = 0; i < entityMinimums.Count; i++)
        {
            int minCount = entityMinimums[i];

            // Count how many of this entity already exist to help with the minimum check
            int existingCount = 0;
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    if (entityPositions[x, y] == i + 1)
                        existingCount++;
                }
            }

            int needed = Mathf.Max(0, minCount - existingCount);

            for (int j = 0; j < needed && positionIndex < emptyPositions.Count; j++, positionIndex++)
            {
                Vector2Int pos = emptyPositions[positionIndex];
                entityPositions[pos.x, pos.y] = i + 1;
            }
        }

        // Instantiate tiles and entities
        for (int y = 0; y < gridHeight; y++)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                Vector3 tilePos = new Vector3(x * tileSpacing, (gridHeight - 1 - y) * tileSpacing, 0);
                Instantiate(gridTile, tilePos, Quaternion.identity, transform);

                int entityIndex = entityPositions[x, y] - 1;
                if (entityIndex >= 0 && entityIndex < entities.Count)
                {
                    Instantiate(entities[entityIndex], tilePos, Quaternion.identity, transform);
                }
            }
        }
    }
}

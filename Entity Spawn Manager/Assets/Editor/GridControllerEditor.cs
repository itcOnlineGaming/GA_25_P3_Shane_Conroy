using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GridController))]
public class GridControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GridController grid = (GridController)target;

        GUILayout.Space(10);
        GUILayout.Label("Grid Preview", EditorStyles.boldLabel);

        DrawInteractiveGrid(grid);

        GUILayout.Space(10);
    }

    void DrawInteractiveGrid(GridController grid)
    {
        int cellSize = 30;
        int maxEntities = grid.entities.Count;

        if (grid.entityPositions == null || grid.entityPositions.GetLength(0) != grid.gridWidth || grid.entityPositions.GetLength(1) != grid.gridHeight)
        {
            grid.entityPositions = new int[grid.gridWidth, grid.gridHeight];
        }

        for (int y = 0; y < grid.gridHeight; y++)
        {
            GUILayout.BeginHorizontal();
            for (int x = 0; x < grid.gridWidth; x++)
            {
                int entityValue = grid.entityPositions[x, y];

                string buttonText = entityValue > 0 ? $"[ {entityValue} ]" : "[   ]";

                if (GUILayout.Button(buttonText, GUILayout.Width(cellSize + 3), GUILayout.Height(cellSize)))
                {
                    grid.entityPositions[x, y] = (grid.entityPositions[x, y] + 1) % (maxEntities + 1);
                }
            }
            GUILayout.EndHorizontal();
        }
    }
}

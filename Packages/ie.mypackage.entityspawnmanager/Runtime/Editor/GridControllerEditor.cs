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
        GUILayout.Label("Entity Minimums", EditorStyles.boldLabel);

        for (int i = 0; i < grid.entities.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();

            grid.entityMinimums[i] = EditorGUILayout.IntField(
                new GUIContent($"Min for Entity {i + 1}"),
                grid.entityMinimums[i]);

            EditorGUILayout.ObjectField(grid.entities[i], typeof(GameObject), false);

            EditorGUILayout.EndHorizontal();
        }

        GUILayout.Space(10);
        GUILayout.Label("Grid Preview", EditorStyles.boldLabel);

        DrawInteractiveGrid(grid);

        GUILayout.Space(10);

        if (GUILayout.Button("Generate Grid"))
        {
            grid.CreateGrid();
        }
    }

    void DrawInteractiveGrid(GridController grid)
    {
        int cellSize = 30;
        int maxEntities = grid.entities.Count;

        if (grid.entityPositions == null ||
            grid.entityPositions.GetLength(0) != grid.gridWidth ||
            grid.entityPositions.GetLength(1) != grid.gridHeight)
        {
            grid.entityPositions = new int[grid.gridWidth, grid.gridHeight];
        }

        // Main grid
        for (int y = 0; y < grid.gridHeight; y++)
        {
            GUILayout.BeginHorizontal();

            for (int x = 0; x < grid.gridWidth; x++)
            {
                if (x > 0) GUILayout.Space(3);

                int entityValue = grid.entityPositions[x, y];
                string buttonText = entityValue > 0 ? $"[ {entityValue} ]" : "[   ]";

                if (GUILayout.Button(buttonText, GUILayout.Width(cellSize + 5), GUILayout.Height(cellSize)))
                {
                    grid.entityPositions[x, y] = (grid.entityPositions[x, y] + 1) % (maxEntities + 1);
                    EditorUtility.SetDirty(grid);
                }
            }

            GUILayout.Space(10);

            // Row-fill buttons
            string rowButtonText = "[ → ]";
            if (GUILayout.Button(rowButtonText, GUILayout.Width(cellSize + 5), GUILayout.Height(cellSize)))
            {
                int firstCellValue = grid.entityPositions[0, y];
                int newValue = (firstCellValue + 1) % (maxEntities + 1);

                for (int x = 0; x < grid.gridWidth; x++)
                {
                    grid.entityPositions[x, y] = newValue;
                }

                EditorUtility.SetDirty(grid);
            }

            GUILayout.EndHorizontal();
            GUILayout.Space(3);
        }

        // Column-fill buttons
        GUILayout.BeginHorizontal();

        for (int x = 0; x < grid.gridWidth; x++)
        {
            if (x > 0) GUILayout.Space(3);

            string colButtonText = "[ ↓ ]";
            if (GUILayout.Button(colButtonText, GUILayout.Width(cellSize + 5), GUILayout.Height(cellSize)))
            {
                int topCellValue = grid.entityPositions[x, 0];
                int newValue = (topCellValue + 1) % (maxEntities + 1);

                for (int y = 0; y < grid.gridHeight; y++)
                {
                    grid.entityPositions[x, y] = newValue;
                }

                EditorUtility.SetDirty(grid);
            }
        }

        GUILayout.Space(cellSize + 10);
        GUILayout.EndHorizontal();
    }
}

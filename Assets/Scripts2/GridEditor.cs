using UnityEditor;
using UnityEngine;

public class GridEditor : EditorWindow
{
    #region member fields
    GameObject parent;
    GameObject tile;
    Vector3 gridPosition;
    Vector2Int gridSize = new Vector2Int(15, 12);
    #endregion

    [MenuItem("Window / Tools / Grid Generator")]

    public static void ShowWindow()
    {
        EditorWindow window = GetWindow(typeof(GridEditor));
    }

    void OnGUI()
    {
        if (!CanShowWindow())
            return;

        SetFields();
    }

    void SetFields()
    {
        gridPosition = EditorGUILayout.Vector3Field("Grid Start Position", gridPosition);

        EditorGUILayout.Space();

        gridSize.x = Mathf.Clamp(EditorGUILayout.IntField("Width", gridSize.x), 0, 99);
        gridSize.y = Mathf.Clamp(EditorGUILayout.IntField("Length", gridSize.y), 0, 99);

        EditorGUILayout.Space(20f);

        if (GUILayout.Button("(re)Generate"))
            CreateGrid();

        if (GUILayout.Button("Connect two tiles"))
            CreateLadder();

    }

    /// <summary>
    /// Add the TileGenerator script to a new object with the currently selected values
    /// </summary>
    void CreateGrid()
    {
        TileGenerator tg;

        AssignGridParent();

        if (!parent.GetComponent<TileGenerator>())
            tg = parent.AddComponent<TileGenerator>();
        else
            tg = parent.GetComponent<TileGenerator>();

        tg.GenerateGrid(tile, gridSize);
    }

    void AssignGridParent()
    {
        if (parent == null)
            parent = new GameObject("Grid");

        parent.transform.position = gridPosition;
    }

    bool CanShowWindow()
    {
        tile = (GameObject)EditorGUILayout.ObjectField("Tile2", tile, typeof(GameObject), true);

        if (tile == null)
        {
            GUILayout.Label("Please attach a GameObject to create a grid from");
            return false;
        }

        return true;
    }

    void CreateLadder()
    {
        GameObject[] tiles = Selection.gameObjects;
        if (tiles.Length != 2)
            return;

        if (tiles[0].GetComponent<Tile2>() && tiles[1].GetComponent<Tile2>())
        {
            tiles[0].GetComponent<Tile2>().connectedTile = tiles[1].GetComponent<Tile2>();
            tiles[1].GetComponent<Tile2>().connectedTile = tiles[0].GetComponent<Tile2>();
        }
    }
}

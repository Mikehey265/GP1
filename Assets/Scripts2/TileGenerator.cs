using UnityEngine;

public class TileGenerator : MonoBehaviour
{
    void ClearGrid()
    {
        // Clear the existing grid by destroying child objects.
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }

    Vector2 DetermineTileSize(Bounds tileBounds)
    {
        // Calculate the size of the hexagonal tile.
        // Assuming you have a hexagon mesh, you'll need to adjust this calculation.
        // Hexagon size may vary depending on the orientation.
        float hexRadius = Mathf.Max(tileBounds.extents.x, tileBounds.extents.z);
        return new Vector2(hexRadius * 2, hexRadius * 2 * Mathf.Sqrt(3));
    }

    public void GenerateGrid(GameObject tile, Vector2Int gridSize)
    {
        ClearGrid();
        Vector2 tileSize = DetermineTileSize(tile.GetComponent<MeshFilter>().sharedMesh.bounds);
        Vector3 position = transform.position;

        for (int x = 0; x < gridSize.x; x++)
        {
            for (int y = 0; y < gridSize.y; y++)
            {
                position.x = transform.position.x + tileSize.x * x;

                // Adjust the tile position for hexagonal grid based on row and column.
                position.z = transform.position.z + tileSize.y * y;
                position.z += OffsetUnevenRow(x, tileSize.y);

                CreateTile(tile, position, new Vector2Int(x, y));
            }
        }
    }

    float OffsetUnevenRow(float x, float tileSizeY)
    {
        // Adjust the offset for hexagonal grid. Even rows are shifted.
        return x % 2 == 0 ? tileSizeY / 2 : 0f;
    }

    void CreateTile(GameObject tilePrefab, Vector3 position, Vector2Int id)
    {
        // Instantiate the hexagonal tile at the specified position.
        GameObject newTile = Instantiate(tilePrefab, position, Quaternion.identity, transform);
        newTile.name = "Tile " + id;

        Debug.Log("Created a tile!");
    }
}

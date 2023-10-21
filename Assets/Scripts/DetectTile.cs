using System;
using UnityEngine;

public class DetectTile : MonoBehaviour
{
    private MovePlayerOld movePlayer;
    private string currentPlayerTile;

    private void Awake()
    {
        movePlayer = GetComponent<MovePlayerOld>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Tile"))
        {
            currentPlayerTile = other.gameObject.name;
            if (currentPlayerTile == movePlayer.GetSelectedTileName())
            {
                Debug.Log("Tile underneath is: " + currentPlayerTile);   
            }
        }
    }
}

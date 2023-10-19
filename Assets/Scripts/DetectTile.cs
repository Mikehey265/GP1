using System;
using UnityEngine;

public class DetectTile : MonoBehaviour
{
    private MovePlayer movePlayer;
    private string currentPlayerTile;

    private void Awake()
    {
        movePlayer = GetComponent<MovePlayer>();
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

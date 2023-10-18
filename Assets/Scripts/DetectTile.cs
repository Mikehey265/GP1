using UnityEngine;

public class DetectTile : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision other)
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            Debug.Log("Tile underneath is: " + other.gameObject.name);
        }
    }
}

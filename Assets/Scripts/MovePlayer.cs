using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    private float speed = 2f;
    private Camera cameraVar;
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private string tileName;
    
    private void Awake()
    {
        cameraVar = Camera.main;
        targetPosition = transform.position;
    }

    private void Update()
    {
        
        Mouse mouse = Mouse.current;
        if (mouse.leftButton.wasPressedThisFrame)
        {
            Vector3 mousePosition = mouse.position.ReadValue();
            Ray ray = cameraVar.ScreenPointToRay(mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                targetPosition = new Vector3(hit.transform.position.x, 1, hit.transform.position.z);
                tileName = hit.transform.name;
                Debug.Log("Tile selected: " + tileName);
            }
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        currentPosition = targetPosition;
    }

    public string GetSelectedTileName()
    {
        return tileName;
    }
}

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
    
    //for highlighting
    public GridManager gridManager;
    private RaycastHit rayHit;
    private void Awake()
    {
        cameraVar = Camera.main;
        targetPosition = transform.position;
    }

    private void Update()
    {
        
        Mouse mouse = Mouse.current;
        Vector3 mousePosition = mouse.position.ReadValue();
        Ray ray = cameraVar.ScreenPointToRay(mousePosition);
        if (mouse.leftButton.wasPressedThisFrame)
        {
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                //highlight selected tile
                gridManager.HandleMouseSelectedTile(rayHit.transform);
                
                targetPosition = new Vector3(hit.transform.position.x, 1, hit.transform.position.z);
                tileName = hit.transform.name;
                Debug.Log("Tile selected: " + tileName);
            }
        }
        else if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out rayHit))
        {
            //highlight the tile when just hovering
            gridManager.HandleMouseOverTile(rayHit.transform);
        }
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
        currentPosition = targetPosition;
    }

    public string GetSelectedTileName()
    {
        return tileName;
    }
}

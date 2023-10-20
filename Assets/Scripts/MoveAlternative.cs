using UnityEngine;
using UnityEngine.InputSystem;

public class MoveAlternative : MonoBehaviour
{
    private Camera cameraVar;
    private Vector3 currentPosition;
    private Vector3 clickedPosition;
    private bool isMoving;
    private float maxRange = 3f;

    private void Awake()
    {
        cameraVar = Camera.main;
    }

    private void Start()
    {
        currentPosition = transform.position;
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
                clickedPosition = new Vector3(hit.transform.position.x, 1, hit.transform.position.z);
                CheckPosition();
            }
        }
    }

    private void CheckPosition()
    {
        float distance = Vector3.Distance(currentPosition, clickedPosition);
        Debug.Log("current position: " + currentPosition);
        Debug.Log("click position: " + clickedPosition);
        Debug.Log("distance: " + distance);
        Debug.Log(currentPosition - clickedPosition);
        if (distance <= maxRange)
        {
            Debug.Log("in range");
        }
    }
}

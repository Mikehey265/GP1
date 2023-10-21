using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public static MovePlayer Instance { get; private set; }
    
    private Camera cameraVar;
    [SerializeField] private GridManager gridManager;
    private RaycastHit hit;
    
    private Vector3 currentPosition;
    private Vector3 clickedPosition;
    private bool isMoving;
    private float maxRange = 3f;
    private float speed = 5f;

    private void Awake()
    {
        Instance = this;
        cameraVar = Camera.main;
    }

    private void Start()
    {
        currentPosition = transform.position;
    }

    private void Update()
    {
        Mouse mouse = Mouse.current;
        Vector3 mousePosition = mouse.position.ReadValue();
        Ray ray = cameraVar.ScreenPointToRay(mousePosition);
        if (!isMoving)
        {
            gridManager.ResetTileHighlight();
            if (mouse.leftButton.wasPressedThisFrame)
            {
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    clickedPosition = new Vector3(hit.transform.position.x, 1, hit.transform.position.z);
                    CheckPosition();
                }
            }   
            if(!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit))
            {
                //highlight the tile when just hovering
                gridManager.HandleMouseOverTile(hit.transform);
            }
        }

        Debug.Log("current: " +currentPosition + ", clicked: " + clickedPosition);
        Debug.Log(clickedPosition - currentPosition);
        if (isMoving)
        {
            Move();
            gridManager.HandleMouseSelectedTile(hit.transform);
        }
    }

    private void CheckPosition()
    {
        float distance = Vector3.Distance(currentPosition, clickedPosition);
        Vector3 position = clickedPosition - currentPosition;
        if (distance <= maxRange)
        {
            if (Mathf.Abs(position.x) > Mathf.Abs(position.z) && (int)currentPosition.z == (int)clickedPosition.z)
            {
                isMoving = true;
            }
            else if(Mathf.Abs(position.x) < Mathf.Abs(position.z) && (int)currentPosition.x == (int)clickedPosition.x)
            {
                isMoving = true;
            }
        }
        else
        {
            isMoving = false;
        }
    }

    private void Move()
    {
        float step = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, clickedPosition, step);
        transform.LookAt(clickedPosition);
        if (transform.position == clickedPosition)
        {
            currentPosition = transform.position;
            gridManager.ResetSelectedTileHighlight();
            isMoving = false;
        }
    }

    public void StopMoving(Vector3 newPosition)
    {
        if (isMoving)
        {
            isMoving = false;
            transform.position = newPosition;
            currentPosition = transform.position;
            clickedPosition = currentPosition;
        }
    }
}

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    public static MovePlayer Instance { get; private set; }

    [SerializeField] private float maxRange = 3f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GridManager gridManager;
    [SerializeField] private GameEventInt playerMoved;
    private RaycastHit hit;
    private Camera cameraVar;

    private Vector3 currentPosition;
    private Vector3 clickedPosition;
    private Vector3 previousPosition;
    private int stepsTaken;
    private bool isMoving;

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
            if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out hit))
            {
                //highlight the tile when just hovering
                gridManager.HandleMouseOverTile(hit.transform);
            }
        }

        if (isMoving)
        {
            Move();
            gridManager.HandleMouseSelectedTile(hit.transform);     //highlight the tile when clicked
        }
    }

    private void CheckPosition()
    {
        float distance = Vector3.Distance(currentPosition, clickedPosition);
        Vector3 position = clickedPosition - currentPosition;

        if (distance <= maxRange)
        {
            if (clickedPosition == previousPosition && clickedPosition != currentPosition)
            {
                StressManager.Instance.AddStressPoints(1);
            }

            //if x is greater than z, and both z coordinates are the same, player can move on x axis
            if (Mathf.Abs(position.x) > Mathf.Abs(position.z) && (int)currentPosition.z == (int)clickedPosition.z)
            {
                stepsTaken = (int)distance;
                isMoving = true;
                previousPosition = currentPosition;
            }
            //if z is greater than x, and both x coordinates are the same, player can move on z axis
            else if (Mathf.Abs(position.x) < Mathf.Abs(position.z) && (int)currentPosition.x == (int)clickedPosition.x)
            {
                stepsTaken = (int)distance;
                isMoving = true;
                previousPosition = currentPosition;
            }
        }
        else
        {
            stepsTaken = 0;
            isMoving = false;
        }
    }

    //Move and rotate towards clicked position
    private void Move()
    {
        float step = Time.deltaTime * moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, clickedPosition, step);
        // transform.LookAt(clickedPosition);

        //player arrived at clicked position
        if (transform.position == clickedPosition)
        {
            currentPosition = transform.position;
            gridManager.ResetSelectedTileHighlight();
            playerMoved.EventRaised(stepsTaken);
            stepsTaken = 0;
            isMoving = false;
        }
    }

    //function performed in TileDetector script. When player detects a wall, he stops on last detected tile.
    //when player click on tile behind the wall it should not count as a move for player and enemy
    public void StopMoving(Vector3 newPosition)
    {
        if (isMoving)
        {
            isMoving = false;
            stepsTaken = 0;
            transform.position = newPosition;
            currentPosition = transform.position;
            clickedPosition = currentPosition;
        }
    }
}

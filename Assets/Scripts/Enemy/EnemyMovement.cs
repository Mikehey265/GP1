using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 currentPos;
    [SerializeField] private List<GameObject> patrolPoints;

    [SerializeField] private int playerMoveAmount;
    public bool moved = false;
    [SerializeField] private EnemyVision enemyVision;
    [SerializeField]private GameObject currentTile;
    public GameEventInt playerMoved;
    [SerializeField] private int currentPatrolIndex = 0;
    private GameObject startPoint;
    // 1 = up, 2 = right, 3 = down, 4 = left
    public int facingDirection;

    private void OnEnable()
    {
        playerMoved.onEventRaised += MovementListen;
    }

    private void OnDisable()
    {
        playerMoved.onEventRaised -= MovementListen;
    }

    private void Start()
    {
        startPoint = patrolPoints[0];
        currentPos.x = patrolPoints[currentPatrolIndex].gameObject.transform.position.x;
        currentPos.z = patrolPoints[currentPatrolIndex].gameObject.transform.position.z;
        transform.position = currentPos;
        CalculateDifferenceBetweenPoints();
        enemyVision = enemyVision.GetComponent<EnemyVision>();
    }

    private void Update()
    {
        transform.position = currentPos;
    }
    private void MovementListen(int playerSteps)
    {
        currentPos = SimulateMove(playerSteps);
        moved = true;
    }
    private void ReadInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentPos = SimulateMove(playerMoveAmount);
        }
    }
    
    private void CalculateDifferenceBetweenPoints()
    {
        Vector3 fromPos = patrolPoints[currentPatrolIndex].gameObject.transform.position;
        Vector3 toPos = patrolPoints[currentPatrolIndex + 1].gameObject.transform.position;
        Vector3 vectorDiff = fromPos - toPos;
        var distanceInX = Mathf.Abs(vectorDiff.x);
        var distanceInY = Mathf.Abs(vectorDiff.z);
        Debug.Log("difference is: X: " + distanceInX + " Y: " + distanceInY);
    }
    
    
    
    //Each following object in the list needs to have a common value on one of the axes
    private Vector3 SimulateMove(int steps)
    {
        Vector3 simulateMovement = new Vector3();
        Vector3 simulatePosition = currentPos;
        int simulatePatrolIndex = currentPatrolIndex;
        for (int i = 0; i < steps; i++)
        {
            simulateMovement = Vector3.zero;
            if (simulatePosition != patrolPoints[simulatePatrolIndex + 1].gameObject.transform.position)
            {
                //Compare on the X axis
                //Check if patrol point is to the left of position
                if (simulatePosition.x >
                    patrolPoints[simulatePatrolIndex + 1].gameObject.transform.position.x)
                {
                    simulateMovement.x--;
                    facingDirection = 2;
                }

                //Check if patrol point is to the right of position
                if (simulatePosition.x <
                    patrolPoints[simulatePatrolIndex + 1].gameObject.transform.position.x)
                {
                    simulateMovement.x++;
                    facingDirection = 4;
                }
                //compare on the Y axis
                //Check if patrol point is below position
                if (simulatePosition.z >
                    patrolPoints[simulatePatrolIndex + 1].gameObject.transform.position.z)
                {
                    simulateMovement.z--;
                    facingDirection = 3;
                }

                //Check if patrol point is above position
                if (simulatePosition.z <
                    patrolPoints[simulatePatrolIndex + 1].gameObject.transform.position.z)
                {
                    simulateMovement.z++;
                    facingDirection = 1;
                }
            }
            //Adds the simulated movement to the simulated position
            simulatePosition += simulateMovement;
            //Checks if the enemy has arrived at a patrol point after it's latest movement
            if (patrolPoints[simulatePatrolIndex + 1].gameObject.transform.position == simulatePosition)
            {
                simulatePatrolIndex++;
            }
            if (simulatePatrolIndex == patrolPoints.Count - 1)
            {
                simulatePatrolIndex = 0;
            }
        }
        currentPatrolIndex = simulatePatrolIndex;
        return simulatePosition;
    }
}

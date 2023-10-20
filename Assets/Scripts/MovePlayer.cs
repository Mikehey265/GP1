using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePlayer : MonoBehaviour
{
    private float speed = 10f;
    private Camera cameraVar;
    private Vector3 targetPosition;
    private Vector3 currentPosition;
    private int moveRange;
    private bool isMoving;

    private void Awake()
    {
        cameraVar = Camera.main;
        targetPosition = transform.position;
        currentPosition = transform.position;
        moveRange = 3;
        isMoving = false;
    }

    private void Update()
    {

        if (CheckIfInRange())
        {
            Move();
        }
        
        if (!isMoving)
        {
            Mouse mouse = Mouse.current;
            if (mouse.leftButton.wasPressedThisFrame)
            {
                isMoving = true;
                Vector3 mousePosition = mouse.position.ReadValue();
                Ray ray = cameraVar.ScreenPointToRay(mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    targetPosition = new Vector3(hit.transform.position.x, 1, hit.transform.position.z);
                    // Debug.Log("click " + targetPosition);
                }
            }
            // Debug.Log(Vector3.Distance(currentPosition, targetPosition));
        }

        if (transform.position == targetPosition && isMoving)
        {
            currentPosition = transform.position;
            isMoving = false;
        }
    }

    private bool CheckIfInRange()
    {
        float distance = Vector3.Distance(currentPosition, targetPosition);
        Vector3 position = targetPosition - currentPosition;
        if (distance <= moveRange && ((Math.Abs(position.x) > 0.01f && Math.Abs(position.z) < 0.01f) || (Math.Abs(position.x) < 0.01f && Math.Abs(position.z) > 0.01f)))
        {
            return true;
        }
        
        targetPosition = transform.position;
        isMoving = false;
        return false;
    }
    
    private void Move()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * speed);
    }
}

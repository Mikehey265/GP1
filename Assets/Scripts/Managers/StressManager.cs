using System;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StressManager : MonoBehaviour
{
    public static StressManager Instance { get; private set; }
    
    [SerializeField] private int maxStressPoints;
    private Vector3 playerPos = new Vector3();
    public GameEventVoid gameEventVoid;
    private List<StressBehaviour> stressTiles = new List<StressBehaviour>();
    private int currentStressPoints;

    private void Awake()
    {
        Instance = this;
        currentStressPoints = 0;
    }

    private void OnEnable()
    {
        gameEventVoid.onEventRaised += CheckPlayerPosition;
    }

    private void OnDisable()
    {
        gameEventVoid.onEventRaised -= CheckPlayerPosition;
    }

    private void FixedUpdate()
    {
        playerPos = MovePlayer.Instance.gameObject.transform.position;
    }

    public void AddStressPoints(int stressAmount)
    {
        currentStressPoints++;
    }

    public void RemoveStressPoint()
    {
        currentStressPoints--;
    }

    public int GetCurrentStressPoints()
    {
        return maxStressPoints;
    }

    private void GetCurrentlyMarkedTiles()
    {
        foreach (GameObject obj in EnemyVision.Instance.markableTiles)
        {
            StressBehaviour stressBehaviour = obj.GetComponent<StressBehaviour>();
            if (stressBehaviour.isMarked)
            {
                stressTiles.Add(stressBehaviour);
            }
        }
    }
    
    public void CheckPlayerPosition()
    {
        GetCurrentlyMarkedTiles();
    }
}

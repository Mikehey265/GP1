using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public static EnemyVision Instance { get; private set; }
    public List<GameObject> markableTiles;
    [SerializeField] private Material visionScore1;
    [SerializeField] private Material visionScore2;
    [SerializeField] private Material outOfVisionRange;
    public GameEventVoid gameEventVoid;
    public EnemyMovement enemyMovement;
    public Transform enemyPos;

    private void Start()
    {
        enemyMovement = enemyMovement.GetComponent<EnemyMovement>();
        GetMarkableTiles();
    }

    private void LateUpdate()
    {
        if (enemyMovement.moved)
        {
            GetMarkableTiles();
            gameEventVoid.EventRaised();
            enemyMovement.moved = false;
        }
        
    }

    public void GetMarkableTiles()
    {
        foreach (GameObject obj in markableTiles)
        {
            UpdateVisionOnStep(obj);
            GetVisionScoreTwoTiles(obj);
            GetVisionScoreOneTiles(obj);
            GetVisionScoreExtendedTiles(obj);
        }
    }


    #region Getting tiles to mark vision score on
    private bool GetRightTile(GameObject obj)
    {
        if (obj.transform.position.x == transform.position.x + 1 &&
            obj.transform.position.z == transform.position.z)
            return true;
        return false;
    }
    private bool GetAboveTile(GameObject obj)
    {
        if (obj.transform.position.z == transform.position.z + 1 &&
            obj.transform.position.x == transform.position.x)
            return true;
        return false;
    }
    private bool GetLeftTile(GameObject obj)
    {
        if (obj.transform.position.x == transform.position.x - 1 &&
            obj.transform.position.z == transform.position.z)
            return true;
        return false;
    }
    private bool GetBelowTile(GameObject obj)
    {
        if (obj.transform.position.z == transform.position.z - 1 &&
            obj.transform.position.x == transform.position.x)
            return true;
        return false;
    }
    private bool GetTopLeftTile(GameObject obj)
    {
        if (obj.transform.position.x == transform.position.x - 1 && 
            obj.transform.position.z == transform.position.z + 1)
            return true;
        return false;
    }
    private bool GetTopRightTile(GameObject obj)
    {
        if (obj.transform.position.x == transform.position.x + 1 && 
            obj.transform.position.z == transform.position.z + 1)
            return true;
        return false;
    }
    private bool GetBottomLeftTile(GameObject obj)
    {
        if (obj.transform.position.x == transform.position.x - 1 &&
            obj.transform.position.z == transform.position.z - 1)
            return true;
        return false;
    }
    private bool GetBottomRightTile(GameObject obj)
    {
        if (obj.transform.position.x == transform.position.x + 1 &&
            obj.transform.position.z == transform.position.z - 1)
            return true;
        return false;
    }

    private bool GetFacingUpTiles(GameObject obj)
    {
        if (enemyMovement.facingDirection == 1)
        {
            if (obj.transform.position.z == transform.position.z + 2 &&
                obj.transform.position.x == transform.position.x)
            {
                return true;
            }
            if (obj.transform.position.z == transform.position.z + 3 &&
                obj.transform.position.x == transform.position.x)
            {
                return true;
            }
        }
        return false;
    }
    private bool GetFacingRightTiles(GameObject obj)
    {
        if (enemyMovement.facingDirection == 2)
        {
            if (obj.transform.position.x == transform.position.x - 2 &&
                obj.transform.position.z == transform.position.z)
            {
                return true;
            }
            if (obj.transform.position.x == transform.position.x - 3 &&
                obj.transform.position.z == transform.position.z)
            {
                return true;
            }
        }
        return false;
    }
    private bool GetFacingDownTiles(GameObject obj)
    {
        if (enemyMovement.facingDirection == 3)
        {
            if (obj.transform.position.z == transform.position.z - 2 &&
                obj.transform.position.x == transform.position.x)
            {
                return true;
            }

            if (obj.transform.position.z == transform.position.z - 3 &&
                obj.transform.position.x == transform.position.x)
            {
                return true;
            }
        }
        return false;
    }
    private bool GetFacingLeftTiles(GameObject obj)
    {
        if (enemyMovement.facingDirection == 4)
        {
            if (obj.transform.position.x == transform.position.x + 2 &&
                obj.transform.position.z == transform.position.z)
            {
                return true;
            }

            if (obj.transform.position.x == transform.position.x + 3 &&
                obj.transform.position.z == transform.position.z)
            {
                return true;
            }
        }
        return false;
    }
    private void GetVisionScoreOneTiles(GameObject obj)
    {
        if (GetTopLeftTile(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore1;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 1;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
        if (GetTopRightTile(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore1;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 1;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
        if (GetBottomLeftTile(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore1;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 1;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
        if (GetBottomRightTile(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore1;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 1;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
    }
    private void GetVisionScoreTwoTiles(GameObject obj)
    {
        if (GetRightTile(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore2;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 2;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
        if (GetLeftTile(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore2;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 2;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;

        }
        if (GetAboveTile(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore2;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 2;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;

        }
        if (GetBelowTile(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore2;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 2;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
    }
    private void GetVisionScoreExtendedTiles(GameObject obj)
    {
        if (GetFacingUpTiles(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore1;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 1;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
        if (GetFacingLeftTiles(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore1;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 1;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
        if (GetFacingDownTiles(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore1;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 1;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
        if (GetFacingRightTiles(obj))
        {
            obj.GetComponentInChildren<MeshRenderer>().material = visionScore1;
            obj.GetComponentInChildren<StressBehaviour>().stressAmount = 1;
            obj.GetComponentInChildren<StressBehaviour>().isMarked = true;
        }
    }
    private void UpdateVisionOnStep(GameObject obj)
    {
        obj.GetComponentInChildren<MeshRenderer>().material = outOfVisionRange;
        obj.GetComponentInChildren<StressBehaviour>().stressAmount = 0;
        obj.GetComponentInChildren<StressBehaviour>().isMarked = false;
    }
    #endregion
    
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerTileDetector"))
        {
            return;
        }
        markableTiles.Add(other.gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("PlayerTileDetector"))
        {
            return;
        }
        markableTiles.Remove(other.gameObject);
    }
}

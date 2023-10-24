using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    public GameObject ground;

    public int columb;
    public int row;

    public float x;
    public float z;

    void Start()
    {
        for(int i=0;  i<columb*row; i++)
        {
            Instantiate(ground, new Vector3(x +(x *(i %columb)),0, z + (z *(i / columb))), Quaternion.identity);
        }
    }

    void Update()
    {
        
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public ObtainableItem item;
    private GameObject player;

    private void Start()
    {
        player = MovePlayer.Instance.gameObject;
        item.obj = this.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            item.PickedUp();
        }
    }
}

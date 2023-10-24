using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Items/Obtainable Item")]
public class ObtainableItem : ScriptableObject
{
    public string name;
    public GameObject obj;
    public Sprite sprite;
    public Mesh mesh;
    public bool isObtained = false;

    public void PickedUp()
    {
        Destroy(obj);
        isObtained = true;
    }
}

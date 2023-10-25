using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileHighlightManager : MonoBehaviour
{
    [Header("[Highlight Materials]")]
    public Material highlightMaterial;
    public Material originalMaterial;
    public Material selectionMaterial;



    private Transform currentlyHighlighted = null;
    private Transform currentlySelected = null;

    //then use in MovePlayer class
    public void HighlightTile(Transform tileTransform)
    {

        // Reset previous highlight if any
        if (currentlyHighlighted)
        {
            currentlyHighlighted.GetComponentInChildren<MeshRenderer>().material = originalMaterial;
        }

        if (tileTransform.CompareTag("Tile"))
        {
            //get out cube from the game object
            Transform cubeComponent = tileTransform.Find("Cube");
            if (cubeComponent)
            {
                currentlyHighlighted = cubeComponent;
                currentlyHighlighted.GetComponent<MeshRenderer>().material = highlightMaterial;
            }
        }
        else
        {
            currentlyHighlighted = null;
        }
    }
    //then use in MovePlayer class when we move (on click event from MovePlayer class)
    public void HighlightSelectedTile(Transform tileTransform)
    {
        if (currentlySelected)
        {
            currentlySelected.GetComponentInChildren<MeshRenderer>().material = originalMaterial;
        }
        if (tileTransform.CompareTag("Tile"))
        {
            //get cube from our game object
            Transform cubeComponent = tileTransform.Find("Cube");
            if (cubeComponent)
            {
                currentlySelected = cubeComponent;
                currentlySelected.GetComponent<MeshRenderer>().material = selectionMaterial;
            }
        }
        else
        {
            currentlySelected = null;
        }
    }

    public void ResetSelectionHighlight()
    {
        if (currentlySelected)
        {
            currentlyHighlighted.GetComponentInChildren<MeshRenderer>().material = originalMaterial;
        }
    }
    public void ResetHighlight()
    {
        if (currentlyHighlighted)
        {
            currentlyHighlighted.GetComponent<MeshRenderer>().material = originalMaterial;
        }
    }
}

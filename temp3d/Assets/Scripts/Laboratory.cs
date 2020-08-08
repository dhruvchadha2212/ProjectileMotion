using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laboratory : MonoBehaviour
{
    [SerializeField] private GameObject labSnaps;

    public void ToggleLabVisibility()
    {
        foreach (Transform snapsCategory in transform) //complete laboratory structure
        {
            foreach (Transform snapSet in snapsCategory) //floor or wall or ceiling
            {
                if (snapSet.transform.childCount > 0) //set of snaps and not collider gameobject
                {
                    foreach (Transform snap in snapSet) //each individual snap unit
                    {
                        MeshRenderer meshRenderer = snap.gameObject.GetComponent<MeshRenderer>();
                        meshRenderer.enabled = !meshRenderer.enabled;
                    }
                }
            }
        }
    }
}

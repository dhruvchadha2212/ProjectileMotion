using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laboratory : MonoBehaviour
{
    [SerializeField] private GameObject labSnaps;

    public void ToggleLabVisibility()
    {
        for (int i = 0; i < labSnaps.transform.childCount; i++)
        {
            GameObject snapSet = labSnaps.transform.GetChild(i).gameObject;
            for (int j = 0; j < snapSet.transform.childCount; j++)
            {
                GameObject snap = snapSet.transform.GetChild(j).gameObject;
                MeshRenderer meshRenderer = snap.GetComponent<MeshRenderer>();
                meshRenderer.enabled = !meshRenderer.enabled;
            }
        }
    }
}

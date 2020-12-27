using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    [SerializeField] private GameObject labSnaps;

    public void ToggleLabVisibility(bool isVisible)
    {
        foreach (Transform snapsCategory in labSnaps.transform) //complete laboratory structure
        {
            foreach (Transform snapSet in snapsCategory) //floor or wall or ceiling
            {
                if (snapSet.transform.childCount > 0) //set of snaps and not collider gameobject
                {
                    foreach (Transform snap in snapSet) //each individual snap unit
                    {
                        MeshRenderer meshRenderer = snap.gameObject.GetComponent<MeshRenderer>();
                        meshRenderer.enabled = isVisible;
                    }
                }
            }
        }
    }
}

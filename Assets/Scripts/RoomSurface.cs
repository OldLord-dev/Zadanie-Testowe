using UnityEngine;

public class RoomSurface : MonoBehaviour
{
    private bool isHit = false;
    public void SurfaceHit()
    {
        if (isHit) return; 

        isHit = true;
        var roomCheckComponent =  GetComponentInParent<RoomCheck>();
        if (roomCheckComponent == null)
        {
            Debug.LogError("RoomDidn'tSet");
            return;
        }

        roomCheckComponent.SurfaceHit();
        var renderers = GetComponentsInChildren<MeshRenderer>();
        foreach (var r in renderers) 
        { 
            r.material.color = Color.green; 
        }
    } 
}

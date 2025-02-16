using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class RoomCheck : MonoBehaviour
{
    int roomSurfacesNumber;
    private void Start()
    {
        roomSurfacesNumber = GetComponentsInChildren<RoomSurface>().Length;
    }

    public void SurfaceHit()
    {
        roomSurfacesNumber--;
        Debug.Log(roomSurfacesNumber + " roomSurfacesNumber");
        if (roomSurfacesNumber == 0) 
        {
            GameManager.RoomScanned();
        }
    }
}

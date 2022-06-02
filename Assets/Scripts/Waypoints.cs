using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Waypoints : MonoBehaviour
{
    public float WaypointSize = 0.5f;
    public bool MayContinueMovement;
    public bool FinishLevel;
    private void OnDrawGizmos()
    {
        foreach(Transform trans in transform)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawWireSphere(trans.position, WaypointSize);
        }
        Gizmos.color = Color.red;
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.DrawLine(transform.GetChild(i).position, transform.GetChild(i + 1).position);
        }
    }
    public Transform GoToTheNextWaypoint(Transform CurrentWaypoint)
    {
        if (CurrentWaypoint == null)
        {
            return transform.GetChild(0);
        }
        if (CurrentWaypoint.GetSiblingIndex() < transform.childCount - 1)
        {
            if (CurrentWaypoint.GetSiblingIndex() == 2)
            {
                MayContinueMovement = true;
            }
            return transform.GetChild(CurrentWaypoint.GetSiblingIndex() + 1);
        }
        else
        {
            return null;
        }
    }
    private void FixedUpdate()
    {
    }
}

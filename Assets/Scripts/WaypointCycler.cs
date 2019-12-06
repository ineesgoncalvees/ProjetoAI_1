using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WaypointCycler : MonoBehaviour
{
    // Array of waypoints
    [SerializeField]
    private Vector3[] waypoints = null;

    // Current waypoint index
    private int currentWaypoint;

    // Property that returns the current waypoint
    protected Vector3 CurrentWaypoint => waypoints[currentWaypoint];

    // Position agent at first goal
    protected virtual void Start()
    {
        currentWaypoint = 0;
        transform.position = waypoints[0];
    }

    // Update waypoint
    protected void NextWaypoint()
    {
        currentWaypoint++;
        if (currentWaypoint >= waypoints.Length)
        {
            currentWaypoint = 0;
        }
    }
}

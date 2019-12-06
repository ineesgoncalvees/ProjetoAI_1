using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Agents with this component move between random waypoints
public class WaypointBehavior : WaypointCycler
{
    // Maximum speed
    [SerializeField] private float maxSpeed = 8f;

    // Current waypoint
    private Vector3 waypoint;

    // Reference to the agent's rigid body
    [SerializeField]
    private Rigidbody rb;

    // Minimum distance to waypoint to trigger a new waypoint
    [SerializeField]
    private float minWaypointDist = 0.5f;

    // Speed of obstacle movement between waypoints
    [SerializeField]
    [Range(0f, 10f)]
    private float speed = 1f;

    // Start is called before the first frame update
    private void Start()
    {
        waypoint = transform.position;
    }

    // Move between waypoints
    private void FixedUpdate()
    {
        Vector3 vel;

        // Are we close enough to the current waypoint?
        if ((CurrentWaypoint - transform.position).magnitude < minWaypointDist)
        {
            // If so, get a new waypoint
            NextWaypoint();
        }

        // Determine velocity to the current waypoint
        vel = (CurrentWaypoint - transform.position).normalized * speed;

        // Move towards the next waypoint at the calculated velocity
        rb.MovePosition(transform.position + vel);
    }

    // Draw waypoint
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(waypoint, 0.2f);
    }
}
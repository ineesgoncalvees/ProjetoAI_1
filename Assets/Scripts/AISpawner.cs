using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that spawns the prefabs of agents
/// </summary>
public class AISpawner : MonoBehaviour
{
    [SerializeField]
    private int agentNumber;
    [SerializeField]
    private GameObject agent;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        for (int i = 0; i < agentNumber; i++)
        {
            // Instantiates the prefab of the agent
            Instantiate(agent, new Vector3(5, 0, -160), Quaternion.identity).AddComponent<AIBehavior>();
        }
    }
}

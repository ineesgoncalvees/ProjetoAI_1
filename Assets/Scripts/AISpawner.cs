using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawner : MonoBehaviour
{
    [SerializeField]
    private int agentNumber;
    [SerializeField]
    private GameObject agent;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < agentNumber; i++)
        {
            Instantiate(agent, new Vector3(5, 0, -160), Quaternion.identity).AddComponent<AIBehavior>();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;
using LibGameAI.ProjetoAI_1;

public class AIBehavior : MonoBehaviour
{

    // Minimum distance to other agents
    [SerializeField]
    private float minDistanceToAgents = 1f;

    // Maximum speed
    [SerializeField]
    private float maxSpeed = 3f;

    // Reference to agents
    private GameObject agents;

    // Reference to the state machine
    private StateMachine stateMachine;

    private void Awake()
    {
        agents = GameObject.Find("Agents");
    }

    // Start is called before the first frame update
    void Start()
    {
       State goToConcert = new State("Go to concert",
           () => Debug.Log("Enter concert state"),
            WatchConcert,
           () => Debug.Log("Leave concert state"));

        State goRest = new State("Go rest",
           () => Debug.Log("Enter rest state"),
            GoRest,
           () => Debug.Log("Leave rest state"));

        State goEat = new State("Go eat",
           () => Debug.Log("Enter eat state"),
            GoEat,
           () => Debug.Log("Leave eat state"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

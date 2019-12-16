using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using URandom = UnityEngine.Random;
using LibGameAI.ProjetoAI_1;

public class AIBehavior : MonoBehaviour
{
    // Array of agents
    [SerializeField]
    public GameObject[] agents;

    // Minimum distance to other agents
    [SerializeField]
    private float minDistanceToAgents = 1f;

    // Maximum speed
    [SerializeField]
    private float maxSpeed = 2f;

    //Reference to AI's stats
    [SerializeField]
    private float hunger = 10f;
    [SerializeField]
    private float energy = 10f;

    // Reference to agents
    private GameObject greenSpaces;
    private GameObject stages;
    private GameObject foodCourt;

    // Reference to the state machine
    private StateMachine stateMachine; 

    private void Awake()
    {
        for(int i = 0; i < agents.Length; i++)
        {
            Instantiate(agents[i], new Vector3(0, 0, -120), Quaternion.identity);
        }
        greenSpaces = GameObject.FindGameObjectWithTag("GreenSpaces");
        stages = GameObject.FindGameObjectWithTag("Stages");
        foodCourt = GameObject.FindGameObjectWithTag("FoodCourt");
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

        goToConcert.AddTransition(
            new Transition(
                () =>
                    hunger > 3,
                () => Debug.Log("Agent is hungry"),
                goEat));

        goEat.AddTransition(
            new Transition(
                () =>
                    energy > 3,
                () => Debug.Log("Agent is tired"),
                goRest));

        goEat.AddTransition(
            new Transition(
                () =>
                    hunger == 10,
                () => Debug.Log("Agent will return to concert"),
                goToConcert));

        goRest.AddTransition(
            new Transition(
                () =>
                    energy == 10,
                () => Debug.Log("Agent will return to concert"),
                goToConcert));

        stateMachine = new StateMachine(goToConcert);
    }

    // Update is called once per frame
    void Update()
    {
        Action actions = stateMachine.Update();
        actions?.Invoke();
    }

    private void WatchConcert()
    {
        Vector3 toStage = transform.position - stages.transform.position;
        transform.Translate(toStage.normalized * maxSpeed * Time.deltaTime);
        hunger--;
        energy--;
    }

    private void GoRest()
    {
        Vector3 toRest = transform.position - greenSpaces.transform.position;
        transform.Translate(toRest.normalized * maxSpeed * Time.deltaTime);
        energy = 10;
    }

    private void GoEat()
    {
        Vector3 toEat = transform.position - foodCourt.transform.position;
        transform.Translate(toEat.normalized * maxSpeed * Time.deltaTime);
        hunger = 10;
    }
}

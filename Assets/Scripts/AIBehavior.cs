using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private float maxSpeed = 0.5f;

    //Reference to AI's stats
    [SerializeField]
    private float hunger = 100f;
    [SerializeField]
    private float energy = 100f;

    // Reference to spaces
    private GameObject greenSpaces;
    private GameObject stages;
    private GameObject foodCourt;

    private GameObject ai;

    private bool isKilled;
    private bool isStunned;
    private bool willPanic;
    public GameObject center;
    public GameObject secondary;
    public GameObject terciary;

    // Reference to the state machine
    private StateMachine stateMachine;

    private void Awake()
    {
        for (int i = 0; i < agents.Length; i++)
        {
            Instantiate(agents[i], new Vector3(5, 0, -160), Quaternion.identity);
        }

        greenSpaces = GameObject.FindGameObjectsWithTag("GreenSpaces")[0];
        stages = GameObject.FindGameObjectsWithTag("Stages")[0];
        foodCourt = GameObject.FindGameObjectsWithTag("FoodCourt")[0];
        ai = GameObject.FindGameObjectWithTag("Agent");

        Vector3 toStage = transform.position - stages.transform.position;
        transform.Translate(toStage.normalized * maxSpeed * Time.deltaTime);
        transform.Translate(toStage);
    }

    // Start is called before the first frame update
    void Start()
    {
        States goToConcert = new States("Go to concert",
           () => Debug.Log("Enter concert state"),
            WatchConcert,
           () => Debug.Log("Leave concert state"));

        States goRest = new States("Go rest",
           () => Debug.Log("Enter rest state"),
            GoRest,
           () => Debug.Log("Leave rest state"));

        States goEat = new States("Go eat",
           () => Debug.Log("Enter eat state"),
            GoEat,
           () => Debug.Log("Leave eat state"));

        goToConcert.AddTransition(
            new Transition(
                () =>
                    hunger < 3,
                () => Debug.Log("Agent is hungry"),
                goEat));

        goToConcert.AddTransition(
             new Transition(
                 () =>
                     energy < 3,
                 () => Debug.Log("Agent is tired"),
                 goRest));

        goEat.AddTransition(
            new Transition(
                () =>
                    hunger == 100,
                () => Debug.Log("Agent will return to concert"),
                goToConcert));

        goRest.AddTransition(
            new Transition(
                () =>
                    energy == 100,
                () => Debug.Log("Agent will return to concert"),
                goToConcert));

        stateMachine = new StateMachine(goToConcert);
    }

    // Update is called once per frame
    void Update()
    {
        Action actions = stateMachine.Update();
        actions?.Invoke();

        CheckRadius();
    }

    private void CheckRadius()
    {
        // Will check where the player clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {

                Vector3 mousePos = hit.point;

                Instantiate(center, mousePos, new Quaternion());
                Instantiate(secondary, mousePos, new Quaternion());
                Instantiate(terciary, mousePos, new Quaternion());

                center.transform.position = mousePos;
                secondary.transform.position = mousePos;
                terciary.transform.position = mousePos;
            }
        }

        if (ai.transform.position == center.transform.position)
        {
            isKilled = true;
            Damage();
        }
        else if (ai.transform.position == secondary.transform.position)
        {
            isStunned = true;
            Damage();
        }
        else if (ai.transform.position == terciary.transform.position)
        {
            willPanic = true;
            Damage();
        }
    }

    private void Damage()
    {
        if (isKilled)
        {
            Destroy(ai.gameObject);
        }
        else if (isStunned)
        {
            maxSpeed /= 2;
            ai.transform.position = new Vector3(0, 0, -170);
        }
        else if (willPanic)
        {
            maxSpeed *= 2;
            ai.transform.position = new Vector3(0, 0, -170);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (ai && other.gameObject.GetComponent<AIBehavior>() != null)
        {
            maxSpeed *= 2;
            willPanic = true;
        }
    }

    private void WatchConcert()
    {
        Vector3 toStage = ai.transform.position - stages.transform.position;
        hunger--;
        energy--;
    }

    private void GoRest()
    {
        Vector3 toRest = ai.transform.position - greenSpaces.transform.position;
        transform.Translate(toRest.normalized * maxSpeed * Time.deltaTime);
        energy = 100;
    }

    private void GoEat()
    {
        Vector3 toEat = ai.transform.position - foodCourt.transform.position;
        transform.Translate(toEat.normalized * maxSpeed * Time.deltaTime);
        hunger = 100;
    }
}

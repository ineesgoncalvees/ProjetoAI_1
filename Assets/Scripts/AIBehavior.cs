using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LibGameAI.ProjetoAI_1;

/// <summary>
/// Class that controls the AI behavior
/// </summary>
public class AIBehavior : MonoBehaviour
{
    // Minimum distance to other agents
    [SerializeField]
    private float minDistanceToAgents = 1f;

    // Maximum speed
    [SerializeField]
    private float maxSpeed = 3f;
    
    // Reference to AI's stats
    [SerializeField]
    private float hunger = 100f;
    [SerializeField]
    private float energy = 100f;

    // Reference to spaces
    private GameObject greenSpaces;
    private GameObject stages;
    private GameObject foodCourt;

    private bool isKilled;
    private bool isStunned;
    private bool willPanic;

    // Radius of the explosions
    public GameObject center;
    public GameObject secondary;
    public GameObject terciary;

    private float lossSpeed = 10f;

    // Reference to the state machine
    private StateMachine stateMachine;

    /// <summary>
    /// Awake method that is called in the beginning of the program
    /// </summary>
    private void Awake()
    {
        greenSpaces = GameObject.FindGameObjectsWithTag("GreenSpaces")[0];
        stages = GameObject.FindGameObjectsWithTag("Stages")[0];
        foodCourt = GameObject.FindGameObjectsWithTag("FoodCourt")[0];

        center = GameObject.FindGameObjectWithTag("Center");
        secondary = GameObject.FindGameObjectWithTag("Secondary");
        terciary = GameObject.FindGameObjectWithTag("Terciary");
    }

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>    
    void Start()
    {
        // State concert
        States goToConcert = new States("Go to concert",
           () => Debug.Log("Enter concert state"),
            WatchConcert,
           () => Debug.Log("Leave concert state"));

        // State rest
        States goRest = new States("Go rest",
           () => Debug.Log("Enter rest state"),
            GoRest,
           () => Debug.Log("Leave rest state"));

        // State eat
        States goEat = new States("Go eat",
           () => Debug.Log("Enter eat state"),
            GoEat,
           () => Debug.Log("Leave eat state"));

        // Transition to go from concert to eat
        goToConcert.AddTransition(
            new Transition(
                () =>
                    hunger < 30,
                () => Debug.Log("Agent is hungry"),
                goEat));

        // Transition to from concert to rest
        goToConcert.AddTransition(
             new Transition(
                 () =>
                     energy < 40,
                 () => Debug.Log("Agent is tired"),
                 goRest));

        // Transition to go from eat to concert
        goEat.AddTransition(
            new Transition(
                () =>
                    hunger == 100,
                () => Debug.Log("Agent will return to concert"),
                goToConcert));

        // Transition to go from rest to concert
        goRest.AddTransition(
            new Transition(
                () =>
                    energy == 100,
                () => Debug.Log("Agent will return to concert"),
                goToConcert));

        stateMachine = new StateMachine(goToConcert);
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        Action actions = stateMachine.Update();
        actions?.Invoke();

        CheckRadius();
    }

    /// <summary>
    /// Method that checks radius
    /// </summary>
    private void CheckRadius()
    {
        // Will check where the player clicked
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            // Gets position from mouse
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {

                Vector3 mousePos = hit.point;

                // Instantiates the prefabs of each radius
                Instantiate(center, mousePos, new Quaternion());
                Instantiate(secondary, mousePos, new Quaternion());
                Instantiate(terciary, mousePos, new Quaternion());

                center.transform.position = mousePos;
                secondary.transform.position = mousePos;
                terciary.transform.position = mousePos;
            }
        }

        // ifs to determine the efect the explosions have on the agents
        if (transform.position == center?.transform.position)
        {
            isKilled = true;
            Damage();
        }
        else if (transform.position == secondary?.transform.position)
        {
            isStunned = true;
            Damage();
        }
        else if (transform.position == terciary?.transform.position)
        {
            willPanic = true;
            Damage();
        }
    }

    /// <summary>
    /// Method that changes agent status upon explosion
    /// </summary>
    private void Damage()
    {
        if (isKilled)
        {
            Destroy(gameObject);
        }
        else if (isStunned)
        {
            maxSpeed /= 2;
            transform.position = new Vector3(0, 0, -170);
        }
        else if (willPanic)
        {
            maxSpeed *= 2;
            transform.position = new Vector3(0, 0, -170);
        }
    }

    /// <summary>
    /// Method that will move the agent to the stages
    /// </summary>
    private void WatchConcert()
    {
        Vector3 toStage = stages.transform.position - transform.position;
        transform.Translate(toStage.normalized * maxSpeed * Time.deltaTime);
        hunger -= Time.deltaTime * lossSpeed;
        energy -= Time.deltaTime * lossSpeed;
    }

    /// <summary>
    /// Method that will move the agent to green spaces
    /// </summary>
    private void GoRest()
    {
        Vector3 toRest = greenSpaces.transform.position - transform.position;
        transform.Translate(toRest.normalized * maxSpeed * Time.deltaTime);
        energy += Time.deltaTime * lossSpeed;
    }

    /// <summary>
    /// Method that will move the agent to the tables
    /// </summary>
    private void GoEat()
    {
        Vector3 toEat = foodCourt.transform.position - transform.position;
        transform.Translate(toEat.normalized * maxSpeed * Time.deltaTime);
        hunger += Time.deltaTime * lossSpeed;
    }
}

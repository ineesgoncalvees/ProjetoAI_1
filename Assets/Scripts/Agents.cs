using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Agents : MonoBehaviour
{
    [SerializeField]
    private InputField userInput;
    int nAgents = Convert.ToInt32(userInput.text);

    //List<Agents> agents = new List<Agents>();

    //private static void InsertAgent(List<Agents> agents)
    //{
    //    Agents agent;
    //}

    public void GetInput(string userInput)
    {
        Debug.Log(nAgents);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Agents : MonoBehaviour
{
    [SerializeField]
    private InputField userInput;

    public void GetInput(string userInput)
    {
        int nAgents = Convert.ToInt32(userInput);
        Debug.Log(nAgents);
    }
}

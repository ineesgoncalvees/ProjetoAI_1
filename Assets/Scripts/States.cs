using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LibGameAI.ProjetoAI_1
{
    public class States
    {
        // Name of the FSM state
        public string Name { get; }

        // Actions to perform when entering this state
        public Action EntryActions { get; }
        // Actions to perform while in this state
        public Action StateActions { get; }
        // Actions to perform when exiting this state
        public Action ExitActions { get; }

        // Public property exposing the transactions associated with this state
        public IEnumerable<Transition> Transitions => transitions;

        // Internal list of the transactions associated with this state
        private IList<Transition> transitions;

        // Create a new state
        public States(string name,
            Action entryActions, Action stateActions, Action exitActions)
        {
            Name = name;
            EntryActions = entryActions;
            StateActions = stateActions;
            ExitActions = exitActions;
            transitions = new List<Transition>();
        }

        // Add a transition from this state to another state
        public void AddTransition(Transition transition)
        {
            transitions.Add(transition);
        }
    }
}

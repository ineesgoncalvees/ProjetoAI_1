using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LibGameAI.ProjetoAI_1
{
    /// <summary>
    /// Class that has the states
    /// </summary>
    public class States
    {
        /// <summary>
        ///  Property that gets the name of the FSM state
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Property of actions to perform when entering this state
        /// </summary>
        public Action EntryActions { get; }
        /// <summary>
        /// Property of actions to perform while in this state
        /// </summary>
        public Action StateActions { get; }
        /// <summary>
        /// Property of actions to perform when exiting this state
        /// </summary>
        public Action ExitActions { get; }

        /// <summary>
        /// Public property exposing the transitions associated with this state
        /// </summary>
        public IEnumerable<Transition> Transitions => transitions;

        // Internal list of the transitions associated with this state
        private IList<Transition> transitions;

        /// <summary>
        /// Constructor of class states
        /// </summary>
        /// <param name="name"></param>
        /// <param name="entryActions"></param>
        /// <param name="stateActions"></param>
        /// <param name="exitActions"></param>
        public States(string name,
            Action entryActions, Action stateActions, Action exitActions)
        {
            Name = name;
            EntryActions = entryActions;
            StateActions = stateActions;
            ExitActions = exitActions;
            transitions = new List<Transition>();
        }

        /// <summary>
        /// Add a transition from this state to another state
        /// </summary>
        /// <param name="transition"></param>
        public void AddTransition(Transition transition)
        {
            transitions.Add(transition);
        }
    }
}

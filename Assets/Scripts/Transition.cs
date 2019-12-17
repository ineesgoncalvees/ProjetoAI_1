using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LibGameAI.ProjetoAI_1
{
    /// <summary>
    /// Class Transition that will make the transitions work in MonoBehaviour
    /// </summary>
    public class Transition
    {
        /// <summary>
        /// Property to get actions associated with this transition
        /// </summary>
        public Action Actions { get; }
        /// <summary>
        /// Property to get target state for this transition
        /// </summary>
        public States TargetState { get; }

        // The condition for triggering this transition
        private Func<bool> condition;

        /// <summary>
        /// Is this transition triggered?
        /// </summary>
        /// <returns></returns>
        public bool IsTriggered()
        {
            return condition();
        }

        /// <summary>
        /// Constructor of the class Transitions
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="actions"></param>
        /// <param name="targetState"></param>
        public Transition(
            Func<bool> condition, Action actions, States targetState)
        {
            this.condition = condition;
            Actions = actions;
            TargetState = targetState;
        }
    }
}
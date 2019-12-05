using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LibGameAI.ProjetoAI_1
{
    public class Transition
    {

        // Actions associated with this transition
        public Action Actions { get; }
        // Target state for this transition
        public State TargetState { get; }

        // The condition for triggering this transition
        private Func<bool> condition;

        // Is this transition triggered?
        public bool IsTriggered()
        {
            return condition();
        }

        // Create a new transition
        public Transition(
            Func<bool> condition, Action actions, State targetState)
        {
            this.condition = condition;
            Actions = actions;
            TargetState = targetState;
        }
    }
}
﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LibGameAI.ProjetoAI_1
{
    /// <summary>
    /// Class that defines the states
    /// </summary>
    public class StateMachine
    {
        // Current state
        private States currentState;

        /// <summary>
        /// Constructor of class StateMachine
        /// </summary>
        /// <param name="initialState"></param>
        public StateMachine(States initialState)
        {
            currentState = initialState;
        }

        /// <summary>
        /// Updates the FSM and return the actions to perform
        /// </summary>
        /// <returns></returns>
        public Action Update()
        {
            // Assume no transition is triggered
            Transition triggeredTransition = null;

            // Check through each transition and store the first one that
            // triggers
            foreach (Transition transition in currentState.Transitions)
            {
                if (transition.IsTriggered())
                {
                    triggeredTransition = transition;
                    break;
                }
            }

            // Check if we have a transition to fire
            if (triggeredTransition != null)
            {
                // Actions to perform when transitioning between states
                Action actions = null;

                // Find the target state
                States targetState = triggeredTransition.TargetState;

                // Add the exit action of the old state, the transition action
                // and the entry for the new state
                actions += currentState.ExitActions;
                actions += triggeredTransition.Actions;
                actions += targetState.EntryActions;

                // Complete the transition and return the action list
                currentState = targetState;
                return actions;
            }

            // If no transition was triggered, return the actions for the
            // current state
            return currentState.StateActions;
        }
    }
}
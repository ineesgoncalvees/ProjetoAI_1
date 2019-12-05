using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LibGameAI.ProjetoAI_1
{
    public class DecisionNode : IDecisionTreeNode
    {
        // Nodes verdadeiro e falso
        private IDecisionTreeNode trueNode, falseNode;

        // Delegate da função que decide se node é verdadeiro ou falso
        private Func<bool> decisionFunc;

        public DecisionNode(Func<bool> test, IDecisionTreeNode trueNode, IDecisionTreeNode falseNode)
        {
            this.decisionFunc = test;
            this.trueNode = trueNode;
            this.falseNode = falseNode;
        }

        public IDecisionTreeNode MakeDecision()
        {
            // Determina que ramo vai tomar, dependendo da decisão da função
            IDecisionTreeNode branch = decisionFunc() ? trueNode : falseNode;

            return branch.MakeDecision();
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LibGameAI.ProjetoAI_1
{
    public interface IDecisionTreeNode
    {
        IDecisionTreeNode MakeDecision();
    }
}
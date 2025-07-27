using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingKeyOnTable : Action
{
    void Start()
    {
        actionName = "Finding Key On Table";
        effects = new List<Effect> { new Effect { name = "Key" } };
        prerequisits = new List<Prerequisite> { new Prerequisite { name = "Clean" } };
    }
}

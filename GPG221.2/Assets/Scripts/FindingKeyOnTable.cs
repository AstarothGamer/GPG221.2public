using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingKeyOnTable : Action
{
    // public FindingKeyOnTable(string name, WorldState worldState) : base(name, worldState)
    // {
    // }

    // Start is called before the first frame update
    void Start()
    {
        actionName = "Finding Key On Table";
        effects = new List<Effect> { new Effect { name = "Key" } };
        prerequisits = new List<Prerequisite> { new Prerequisite { name = "Clean" } };
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingKeyInPocket : Action
{
    private void Start()
    {
        actionName = "Finding Key In Pocket";
        effects = new List<Effect> { new Effect { name = "Key" } };
        prerequisits = new List<Prerequisite> { new Prerequisite { name = "Clean" } };
    }
}

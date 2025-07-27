using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HavingShower : Action
{
    void Start()
    {
        actionName = "Having Shower";
        effects = new List<Effect> { new Effect { name = "Clean" } };
        prerequisits = new List<Prerequisite> { new Prerequisite { name = "Awaked" } };
    }
}

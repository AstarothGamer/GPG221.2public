using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class WakingUp : Action
{
    void Start()
    {
        actionName = "Waking Up";
        effects = new List<Effect> { new Effect { name = "Awaked" } };
        prerequisits = new List<Prerequisite> { new Prerequisite { name = "Sleeping" } };
    }
}

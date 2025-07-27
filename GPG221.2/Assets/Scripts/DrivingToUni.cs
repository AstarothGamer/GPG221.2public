using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingToUni : Action
{
    // public DrivingToUni(string name, WorldState worldState) : base(name, worldState)
    // {
    // }

    // Start is called before the first frame update
    void Start()
    {
        actionName = "Driving To Uni";
        effects = new List<Effect> { new Effect { name = "In Uni" } };
        prerequisits = new List<Prerequisite> { new Prerequisite { name = "Key" } };
    }
}

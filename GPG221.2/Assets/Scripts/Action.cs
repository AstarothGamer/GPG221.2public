using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action : MonoBehaviour
{
    public string name;

    public WorldState worldState;
    public List<Prerequisite> prerequisits;
    public List<Effect> effects;

    public Action(string name, WorldState worldState)
    {
        this.name = name;
        this.worldState = worldState;
    }

    public virtual void DoAction()
    {
        
    }
}

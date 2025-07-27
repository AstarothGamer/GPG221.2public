using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindingKeyInShelf : Action
{
    // public FindingKeyInShelf(string name, WorldState worldState) : base(name, worldState)
    // {
    // }

    // Start is called before the first frame update
    void Start()
    {
        actionName = "Finding Key In Shelf";
        effects = new List<Effect> { new Effect { name = "Key" } };
        prerequisits = new List<Prerequisite> { new Prerequisite { name = "Clean" } };
    }


}

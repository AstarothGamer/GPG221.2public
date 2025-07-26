using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    GOAP goap;
    WorldState worldState;

    void Init()
    {
        worldState.receivedEffects.Add(new Effect("Job"));
        
    }
}

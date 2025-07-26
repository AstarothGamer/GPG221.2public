using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GOAP : MonoBehaviour
{
    public WorldState worldState;
    public List<Action> actions;

    public List<Action> finalPlan;
    public List<Action> possibleActions;
    public List<Action> plan;

    string Goal;

    public void CheckingActions()
    {
        possibleActions.Clear();
        for (int i = 0; i < actions.Count; i++)
        {
            if (actions[i].effects[i].name == Goal)
            {
                possibleActions.Add(actions[i]);
            }
        }
    }

    public void FinalPlan()
    {
        finalPlan.Clear();
        int bestLength = int.MaxValue;
        List<Action> bestPath;

        for (int i = 0; i < possibleActions.Count; i++)
        {
            List<string> visited = new();
            List<Action> currentPath = new();

            if (PlanPath(possibleActions[i], currentPath, visited))
            {
                if (currentPath.Count < bestLength)
                {
                    bestLength = currentPath.Count;
                    bestPath = currentPath;
                }
            }
        }
    }

    public bool PlanPath(Action action, List<Action> path, List<string> visited)
    {
        for (int i = 0; i < action.prerequisits.Count; i++)
        {
            for (int j = 0; j < visited.Count; j++)
            {
                if (visited[j] == action.prerequisits[i].name)
                {
                    return false;
                }
            }

            for (int j = 0; j < worldState.receivedEffects.Count; j++)
            {
                if (action.prerequisits[i].name != worldState.receivedEffects[j].name)
                {
                    Action subAction;
                    for (int a = 0; a < actions.Count; a++)
                    {
                        for (int e = 0; e < actions[a].effects.Count; e++)
                        {
                            if (actions[a].effects[e].name == action.prerequisits[i].name)
                            {
                                subAction = actions[a];
                            }
                        }
                    }

                    // if (subAction == null)
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }
}


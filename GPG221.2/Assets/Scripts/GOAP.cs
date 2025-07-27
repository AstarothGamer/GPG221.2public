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
    public List<Action> failedActions;

    [SerializeField] public string Goal;

    void Start()
    {
        CheckingActions();   
    }

    public void CheckingActions()
    {
        possibleActions.Clear();
        for (int i = 0; i < actions.Count; i++)
        {
            for (int e = 0; e < actions[i].effects.Count; e++)
            {
                if (actions[i].effects[e].name == Goal)
                {
                    if (!possibleActions.Contains(actions[i]))
                    {
                        possibleActions.Add(actions[i]);
                        break;
                    }
                }
            }
        }
        FinalPlan();
    }

    public void FinalPlan()
    {
        finalPlan.Clear();
        int bestLength = int.MaxValue;
        List<Action> bestPath = new();

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

        if (bestPath != null)
        {
            finalPlan = bestPath;
            Debug.Log("final plan:");

            for (int i = 0; i < finalPlan.Count; i++)
            {
                Debug.Log(finalPlan[i].name);
            }
        }
        else
        {
            Debug.LogError("Target can not be achieved");
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

            bool hasEffect = false;
            for (int j = 0; j < worldState.receivedEffects.Count; j++)
            {
                if (action.prerequisits[i].name == worldState.receivedEffects[j].name)
                {
                    hasEffect = true;
                    break;
                }
            }

            if (!hasEffect)
            {
                Action subAction = null;
                for (int a = 0; a < actions.Count; a++)
                {
                    for (int e = 0; e < actions[a].effects.Count; e++)
                    {
                        if (actions[a].effects[e].name == action.prerequisits[i].name)
                        {
                            subAction = actions[a];
                            break;
                        }
                    }

                    if (subAction != null)
                    {
                        break;
                    }
                }

                if (subAction == null)
                {
                    return false;
                }

                visited.Add(action.prerequisits[i].name);

                if (!PlanPath(subAction, path, visited))
                {
                    return false;
                }
            }

        }

        path.Add(action);
        return true;
    }
}


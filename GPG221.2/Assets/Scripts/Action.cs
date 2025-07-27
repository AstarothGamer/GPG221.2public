using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Action : MonoBehaviour
{
    [SerializeField] public TMP_Text currentActionText;
    public string actionName;

    public WorldState worldState;
    public List<Prerequisite> prerequisits;
    public List<Effect> effects;

    public GameObject targetPosition;
    public bool isGuaranteed = false;
    public bool isMoving = false;

    // public Action(string name, WorldState worldState)
    // {
    //     this.actionName = name;
    //     this.worldState = worldState;
    // }

    public virtual void DoAction()
    {
        StartCoroutine(SmoothMoving(targetPosition.transform.position));
    }

    private IEnumerator SmoothMoving(Vector2 direction)
    {
        isMoving = true;

        Vector2 startPos = transform.position;
        Vector2 endPos = direction;
        float duration = 4f;
        float time = 0f;

        currentActionText.text = "Going to " + targetPosition.name + ".";
        while (time < duration)
        {
            float speed = Vector2.Distance(startPos, endPos) / duration;
            transform.position = Vector2.MoveTowards(transform.position, endPos, speed * Time.deltaTime);

            time += Time.deltaTime;
            yield return null;
        }
        currentActionText.text = "Came to " + targetPosition.name + ".";

        yield return new WaitForSeconds(1f); ;

        transform.position = endPos;
        isMoving = false;

        currentActionText.text = "Starting do " + actionName + ".";
        yield return new WaitForSeconds(1f); 

        if (TryDoAction())
        {
            ApplyEffects();
        }
        yield return new WaitForSeconds(1f); 


    }

    public virtual bool TryDoAction()
    {
        if (isGuaranteed)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public virtual void ApplyEffects()
    {
        for (int i = 0; i < effects.Count; i++)
        {
            bool alreadyHas = false;

            for (int j = 0; j < worldState.receivedEffects.Count; j++)
            {
                if (effects[i].name == worldState.receivedEffects[j].name)
                {
                    alreadyHas = true;
                    break;
                }
            }

            if (!alreadyHas)
            {
                worldState.receivedEffects.Add(effects[i]);
            }
        }
    }
}

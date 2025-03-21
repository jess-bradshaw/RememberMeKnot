using UnityEngine;
using System.Collections.Generic;

public class EnemyCombat : MonoBehaviour
{
    public enum State
    {
        active, inactive
    }
    public State currentState => _currentState;
    private State _currentState = State.inactive;

    [SerializeField]
    private Transform actionIndicatorsHolder;

    [SerializeField]
    private GameObject actionIndicatorPrefab;

    [SerializeField]
    private CombatActionData[] possibleCombatActions;

    [SerializeField]
    private TMPro.TMP_Text healthText, defenseText;

    [SerializeField]
    private int numberOfActions = 2;

    [SerializeField]
    private PlayerCombat playerCombat;

    [SerializeField]
    private float actionResolveDuration;

    private float timeOnResolvingAction = 0f;

    private int currentHealth = 25;
    private int maxHealth = 25;
    private int currentDefense = 0;

    private List<EnemyCombatData> actionQueue = new List<EnemyCombatData>();

    private EnemyCombatData lastResolvedAction;

    public void Initialize()
    {
        //Generate actions
        for (int i = 0; i < numberOfActions; i++)
        {
            //Choose a random combat action for each node
            CombatActionData randomizedAction = possibleCombatActions[Random.Range(0, possibleCombatActions.Length)];
            GameObject actionIndicatorObject = Instantiate(actionIndicatorPrefab, actionIndicatorsHolder);
            ActionIndicator actionIndicator = actionIndicatorObject.GetComponent<ActionIndicator>();
            actionIndicator.Initialize(CombatController.Instance.GetActionColour(randomizedAction.actionType));
            actionQueue.Add(new EnemyCombatData(randomizedAction, actionIndicator));
        }

        //Reset defense
        currentDefense = 0;
        UpdateStats();

        _currentState = State.active;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentState == State.active)
        {
            timeOnResolvingAction += Time.deltaTime;
            if (timeOnResolvingAction > actionResolveDuration)
            {
                //Unhighlight the previous node if there was one
                if (lastResolvedAction != null)
                {
                    Destroy(lastResolvedAction.actionIndicator.gameObject);
                }

                //If the queue is empty, switch to the inactive phase
                if (actionQueue.Count == 0)
                {
                    lastResolvedAction = null;
                    _currentState = State.inactive;
                }
                else
                {
                    //Save the current node as the previous node
                    lastResolvedAction = actionQueue[0];

                    //Highlight the current node
                    lastResolvedAction.actionIndicator.Highlight();

                    //Trigger the action's effect
                    CombatActionData combatAction = lastResolvedAction.actionData;
                    switch (combatAction.actionType)
                    {
                        case CombatActionData.ActionType.attack:
                            playerCombat.ApplyDamage(combatAction.actionValue);
                            break;
                        case CombatActionData.ActionType.defend:
                            ApplyDefense(combatAction.actionValue);
                            break;
                        case CombatActionData.ActionType.heal:
                            ApplyHeal(combatAction.actionValue);
                            break;
                    }

                    //Remove the current node from the queue
                    actionQueue.RemoveAt(0);
                }


                timeOnResolvingAction = 0f;
            }
        }

        
    }

    public void ApplyDefense(int defense)
    {
        currentDefense += defense;
        UpdateStats();
    }

    public void ApplyDamage(int damage)
    {
        if (currentDefense > 0)
        {
            int temp = currentDefense;
            currentDefense -= damage;
            damage -= temp;
            
            if (damage < 0)
            {
                UpdateStats();
                return;
            }
        }
        currentHealth -= damage;
        UpdateStats();
    }

    public void ApplyHeal(int heal)
    {
        currentHealth += heal;
        currentHealth = Mathf.Min(maxHealth, currentHealth);
        UpdateStats();
    }

    private void UpdateStats()
    {
        healthText.text = currentHealth.ToString() + " Health";
        if (currentDefense <= 0)
        {
            defenseText.gameObject.SetActive(false);
        }
        else
        {
            defenseText.text = currentDefense.ToString() + " Defense";
            defenseText.gameObject.SetActive(true);
        }
    }
}

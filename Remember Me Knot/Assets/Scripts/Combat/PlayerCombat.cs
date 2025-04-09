using UnityEngine;
using System.Collections.Generic;
//Code by Keely Brown
public class PlayerCombat : MonoBehaviour
{
    public enum State
    {
        inactive, active, resolving
    }
    public State currentState => _currentState;
    private State _currentState = State.active;

    [SerializeField]
    private int maxHealth;
    private int currentHealth = 50;

    private int currentDefense;

    [SerializeField]
    private PlayerCombatNode[] combatNodes;

    [SerializeField]
    private Transform actionIndicatorsHolder;

    [SerializeField]
    private GameObject actionIndicatorPrefab;

    [SerializeField]
    private Transform nodeConnectionsHolder;

    [SerializeField]
    private GameObject nodeConnectionPrefab;

    [SerializeField]
    private float connectionXVariance;

    [SerializeField]
    private CombatActionData[] possibleCombatActions;

    [SerializeField]
    private EnemyCombat enemyCombat;

    [SerializeField]
    private TMPro.TMP_Text healthText, defenseText;

    [SerializeField]
    private int maxNumberOfActions;
    private int currentNumberOfActions;

    [SerializeField]
    private GameObject[] objectsToEnableOnActive, objectsToDisableOnResolve, objectsToDisableOnInactive;

    [SerializeField]
    private GameObject availableActionIndicatorPrefab;

    [SerializeField]
    private Transform availableActionsHolder;

    [SerializeField]
    private List<GameObject> availableActionIndicators;

    [SerializeField]
    private float actionResolveDuration;

    private float timeOnResolvingAction = 0f;

    private List<PlayerCombatConnectionData> actionQueue = new List<PlayerCombatConnectionData>();

    private PlayerCombatConnectionData lastResolvedConnection = null;
     //Jess Added these:
     [SerializeField] private Animator animator; 
     [SerializeField] private ParticleSystem HealEffect;
     [SerializeField] private ParticleSystem DefenseEffect;

    public void Initialize()
    {
        foreach (PlayerCombatNode combatNode in combatNodes)
        {
            //Choose a random combat action for each node
            CombatActionData randomizedAction = possibleCombatActions[Random.Range(0, possibleCombatActions.Length)];
            combatNode.Initialize(randomizedAction);
            combatNode.onNodeClick += TryAddConnection;
        }
        foreach (GameObject objectToEnable in objectsToEnableOnActive)
        {
            objectToEnable.SetActive(true);
        }
        foreach (PlayerCombatNode combatNode in combatNodes)
        {
            combatNode.SetAsActive();
        }

        //Refresh the number of actions available
        currentNumberOfActions = maxNumberOfActions;
        for (int i = 0; i < currentNumberOfActions; i++)
		{
            GameObject availableActionIndicatorObject = Instantiate(availableActionIndicatorPrefab, availableActionsHolder);
            availableActionIndicatorObject.SetActive(true);
            availableActionIndicators.Add(availableActionIndicatorObject);
		}

        currentDefense = 0;
        UpdateStats();
        _currentState = State.active;
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case State.active:
                ActiveUpdate();
                break;
            case State.resolving:
                ResolvingUpdate();
                break;
        }
    }

    private void ActiveUpdate()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (actionQueue.Count > 0)
            {
                PlayerCombatConnectionData lastConnection = actionQueue[actionQueue.Count - 1];
                Destroy(lastConnection.connectionObject);
                Destroy(lastConnection.actionIndicator.gameObject);
                actionQueue.RemoveAt(actionQueue.Count - 1);
                currentNumberOfActions++;
                UpdateAvailableActionsIndicator();
            }
        }
    }

    private void ResolvingUpdate()
    {
        timeOnResolvingAction += Time.deltaTime;
        if (timeOnResolvingAction > actionResolveDuration)
        {
            //Unhighlight the previous node if there was one
            if (lastResolvedConnection != null)
            {
                lastResolvedConnection.connectedToNode.Unhighlight();
                Destroy(lastResolvedConnection.actionIndicator.gameObject);
                Destroy(lastResolvedConnection.connectionObject);
            }

            //If the queue is empty, switch to the inactive phase
            if (actionQueue.Count == 0)
            {
                foreach (GameObject objectToDisable in objectsToDisableOnInactive)
                {
                    objectToDisable.SetActive(false);
                }
                lastResolvedConnection = null;
                _currentState = State.inactive;
            }
            else
            {
                //Save the current node as the previous node
                lastResolvedConnection = actionQueue[0];

                //Highlight the current node
                lastResolvedConnection.connectedToNode.Highlight();
                lastResolvedConnection.actionIndicator.Highlight();

                //Trigger the action's effect
                CombatActionData combatAction = lastResolvedConnection.connectedToNode.combatActionData;
                switch (combatAction.actionType)
                {
                    case CombatActionData.ActionType.attack:
                        animator.SetTrigger("Attack"); // Jess Added this.
                        enemyCombat.ApplyDamage(combatAction.actionValue); 
                        HealEffect.gameObject.SetActive(false); 
                        DefenseEffect.gameObject.SetActive(false); 
                        break;
                    case CombatActionData.ActionType.defend:
                        DefenseEffect.gameObject.SetActive(true); // Jess Added this.
                        ApplyDefense(combatAction.actionValue);
                        HealEffect.gameObject.SetActive(false);// Jess Added this.
                        DefenseEffect.Play();
                        break;
                    case CombatActionData.ActionType.heal:
                        HealEffect.gameObject.SetActive(true); // Jess Added this.
                        ApplyHeal(combatAction.actionValue);
                        DefenseEffect.gameObject.SetActive(false);// Jess Added this.
                        HealEffect.Play();
                        break;
                }
                     
                //Remove the current node from the queue
                actionQueue.RemoveAt(0);
            }
            timeOnResolvingAction = 0f;
            //DefenseEffect.SetActive(false);
        }
    }

    public void TryAddConnection(PlayerCombatNode node)
    {
        if (currentNumberOfActions <= 0)
        {
            return;
        }
        Vector3 startingPosition, endingPosition;

        //No need to check if the connection is possible, just do it
        if (actionQueue.Count == 0)
        {
            startingPosition = transform.position;
            endingPosition = node.transform.position + Random.Range(-connectionXVariance, connectionXVariance) * Vector3.right;

            GameObject connectionObject = Instantiate(nodeConnectionPrefab, nodeConnectionsHolder);
            LineRenderer connectionRenderer = connectionObject.GetComponent<LineRenderer>();
            connectionRenderer.positionCount = 2;
            connectionRenderer.SetPositions(new Vector3[] { startingPosition, endingPosition });
            connectionRenderer.material = CombatController.Instance.GetActionMaterial(node.combatActionData.actionType);

            GameObject actionIndicatorObject = Instantiate(actionIndicatorPrefab, actionIndicatorsHolder);
            ActionIndicator actionIndicator = actionIndicatorObject.GetComponent<ActionIndicator>();
            actionIndicator.Initialize(CombatController.Instance.GetActionColour(node.combatActionData.actionType));

            actionQueue.Add(new PlayerCombatConnectionData(node, connectionObject, actionIndicator));
            currentNumberOfActions--;
            UpdateAvailableActionsIndicator();
        }
        else
        {
            //Check to see if the node can connect to the last entry in the actionQueue
            PlayerCombatNode lastNode = actionQueue[actionQueue.Count - 1].connectedToNode;
            if (lastNode.validConnections.Contains(node))
            {
                startingPosition = lastNode.transform.position + Random.Range(-connectionXVariance, connectionXVariance) * Vector3.right;
                endingPosition = node.transform.position + Random.Range(-connectionXVariance, connectionXVariance) * Vector3.right; 

                GameObject connectionObject = Instantiate(nodeConnectionPrefab, nodeConnectionsHolder);
                LineRenderer connectionRenderer = connectionObject.GetComponent<LineRenderer>();
                connectionRenderer.positionCount = 2;
                connectionRenderer.SetPositions(new Vector3[] { startingPosition, endingPosition });
                connectionRenderer.material = CombatController.Instance.GetActionMaterial(node.combatActionData.actionType);

                GameObject actionIndicatorObject = Instantiate(actionIndicatorPrefab, actionIndicatorsHolder);
                ActionIndicator actionIndicator = actionIndicatorObject.GetComponent<ActionIndicator>();
                actionIndicator.Initialize(CombatController.Instance.GetActionColour(node.combatActionData.actionType));

                actionQueue.Add(new PlayerCombatConnectionData(node, connectionObject, actionIndicator));
                currentNumberOfActions--;
                UpdateAvailableActionsIndicator();
            }
        }
    }

    public void OnReadyPressed()
    {
        if (actionQueue.Count == 0)
        {
            return;
        }
        _currentState = State.resolving;
        foreach (GameObject objectToDisable in objectsToDisableOnResolve)
        {
            objectToDisable.SetActive(false);
        }
        foreach (PlayerCombatNode combatNode in combatNodes)
        {
            combatNode.SetAsResolving();
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

    private void UpdateAvailableActionsIndicator()
    {
        foreach (GameObject availableActionIndicator in availableActionIndicators)
        {
            availableActionIndicator.SetActive(false);
        }
        for (int i = 0; i < currentNumberOfActions && i < availableActionIndicators.Count; i++)
        {
            availableActionIndicators[i].SetActive(true);
        }

    }
  public void Finish()
    {
        _currentState = State.inactive;
    }
}

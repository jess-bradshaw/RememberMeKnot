using System.Collections.Generic;
using UnityEngine;
//Code by Keely Brown
public class CombatController : Singleton<CombatController>
{
    public enum CombatState
    {
        player_turn, enemy_turn, finished
    }
    public CombatState currentState => _currentState;
    private CombatState _currentState = CombatState.player_turn;

    [SerializeField]
    private CombatActionTemplateData[] combatActionTemplates;

    private Dictionary<CombatActionData.ActionType, CombatActionTemplateData> actionTemplateMap = new Dictionary<CombatActionData.ActionType, CombatActionTemplateData>();


    [SerializeField]
    private PlayerCombat playerCombat;

    [SerializeField]
    private EnemyCombat enemyCombat;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        actionTemplateMap = new Dictionary<CombatActionData.ActionType, CombatActionTemplateData>();
        foreach (CombatActionTemplateData template in combatActionTemplates)
        {
            actionTemplateMap.Add(template.actionType, template);
        }
        playerCombat.Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case CombatState.player_turn:
                if (playerCombat.currentState == PlayerCombat.State.inactive)
                {
                    enemyCombat.Initialize();
                    _currentState = CombatState.enemy_turn;

                }
                break;
            case CombatState.enemy_turn:
                if (enemyCombat.currentState == EnemyCombat.State.inactive)
                {
                    playerCombat.Initialize();
                    _currentState = CombatState.player_turn;
                }
                break;
        }
    }

    public Color GetActionColour(CombatActionData.ActionType actionType)
    {
        if (actionTemplateMap.ContainsKey(actionType))
        {
            return actionTemplateMap[actionType].actionColour;
        }
        return Color.white;
    }

    public Material GetActionMaterial(CombatActionData.ActionType actionType)
    {
        if (actionTemplateMap.ContainsKey(actionType))
        {
            return actionTemplateMap[actionType].actionMaterial;
        }
        return null;
    }

    public string GetActionName(CombatActionData.ActionType actionType)
    {
        if (actionTemplateMap.ContainsKey(actionType))
        {
            return actionTemplateMap[actionType].actionName;
        }
        return "";
    }
     public void TriggerEnemyDefeat()
    {
        _currentState = CombatState.finished;
        playerCombat.Finish();
        enemyCombat.Finish();
    }
}

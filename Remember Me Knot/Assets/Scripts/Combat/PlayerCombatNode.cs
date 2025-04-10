using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;
//Code by Keely Brown
public class PlayerCombatNode : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public enum NodeType
    {
        top, middle, bottom
    }
    public NodeType nodeType => _nodeType;
    [SerializeField]
    private NodeType _nodeType;

    public List<PlayerCombatNode> validConnections => _validConnections;
    [SerializeField]
    private List<PlayerCombatNode> _validConnections;

    [SerializeField]
    private Image nodeImage;

    [SerializeField]
    private GameObject highlightObject;

    [SerializeField]
    private TMPro.TMP_Text actionText;

    [SerializeField]
    private TMPro.TMP_Text actionNameText;

    [SerializeField]
    private Button actionButton;

    public delegate void OnNodeUpdate(PlayerCombatNode sender);
    public event OnNodeUpdate onNodeHover, onNodeUnhover, onNodeClick;



    public CombatActionData combatActionData => _combatActionData;
    private CombatActionData _combatActionData = null;
    public void Initialize(CombatActionData inData)
    {
        onNodeClick = null;
        _combatActionData = inData;
        Color actionColour = CombatController.Instance.GetActionColour(_combatActionData.actionType);
        nodeImage.color = actionColour;
        actionText.text = "+" + _combatActionData.actionValue.ToString() + " " +CombatController.Instance.GetActionName(_combatActionData.actionType);
        actionNameText.text = _combatActionData.actionName;
    }

	public void OnPointerEnter(PointerEventData eventData)
	{
        onNodeHover?.Invoke(this);

    }

	public void OnPointerExit(PointerEventData eventData)
	{
        onNodeUnhover?.Invoke(this);
	}

    public void OnClick()
    {
        onNodeClick?.Invoke(this);
    }

    public void SetAsActive()
    {
        actionButton.interactable = true;
    }

    public void SetAsResolving()
    {
        actionButton.interactable = false;
    }

    public void Highlight()
    {
        highlightObject.SetActive(true);
    }

    public void Unhighlight()
    {
        highlightObject.SetActive(false);
    }
}

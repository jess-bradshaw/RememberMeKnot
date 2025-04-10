using System;
using UnityEngine;

//Code by Keely Brown
[Serializable]
public class CombatActionTemplateData
{
	public CombatActionData.ActionType actionType => _actionType;
	[SerializeField]
	private CombatActionData.ActionType _actionType;

	public Color actionColour => _actionColour;
	[SerializeField]
	private Color _actionColour;

	public Material actionMaterial => _actionMaterial;
	[SerializeField]
	private Material _actionMaterial;

	public string actionName => _actionName;
	[SerializeField]
	private string _actionName;
}


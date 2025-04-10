using UnityEngine;
using System;
//Code by Keely Brown
[Serializable]
public class CombatActionData
{
	public enum ActionType
	{
		attack, defend, heal
	}
	public ActionType actionType => _actionType;
	[SerializeField]
	private ActionType _actionType;

	public int actionValue => _actionValue;
	[SerializeField]
	private int _actionValue;

	public string actionName => _actionName;
	[SerializeField]
	private string _actionName = "";
}


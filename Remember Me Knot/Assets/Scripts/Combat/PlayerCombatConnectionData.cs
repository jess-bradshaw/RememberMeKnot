using System;
using UnityEngine;



class PlayerCombatConnectionData
{
	public PlayerCombatNode connectedToNode;
	public GameObject connectionObject;
	public ActionIndicator actionIndicator;

	public PlayerCombatConnectionData(PlayerCombatNode inNode, GameObject inConnectionObject, ActionIndicator inActionIndicator)
	{
		connectedToNode = inNode;
		connectionObject = inConnectionObject;
		actionIndicator = inActionIndicator;
	}
}


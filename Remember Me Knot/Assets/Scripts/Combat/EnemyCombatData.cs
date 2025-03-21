using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class EnemyCombatData
{
	public CombatActionData actionData;
	public ActionIndicator actionIndicator;

	public EnemyCombatData(CombatActionData inActionData, ActionIndicator inActionIndicator)
	{
		actionData = inActionData;
		actionIndicator = inActionIndicator;
	}
}


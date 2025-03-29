using UnityEngine;

public class SpawnerSet : MonoBehaviour
{
    public void MandatoryFight()
    {
        PlayerData.mandatoryFightComplete = true; 
    }
     public void OptionalFight()
    {
        PlayerData.optionalFightComplete = true; 
    }
}

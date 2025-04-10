using UnityEngine;
//Jess made this from stratch 
public class SpawnerSet : MonoBehaviour
{
    public void MandatoryFight()
    {
        PlayerData.mandatoryFightComplete = true; 
    }
     public void OptionalFight()
    {
        PlayerData.optionalFightComplete = true; 
        PlayerData.RedHeartCheck = true; 
    }
}

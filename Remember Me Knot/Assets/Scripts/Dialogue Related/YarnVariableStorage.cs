using UnityEngine;
using Yarn.Unity; 

public class YarnVariableStorage : MonoBehaviour
{
   // public WispEmotion wispEmotions; // Reference to the WispEmotions script
  //  public GameObject objectToDisable; // GameObject to disable
  //  public GameObject objectToEnable;  // GameObject to enable
    public string playerName; 
    public string guideName; 
    public string playerPronoun1; 
    public string playerPronoun2; 
    [Header("Bool checks for Yarn Script")]
    public bool NameSet; 
    public bool nameChecked; 
    public bool PronounSet; 

   // public CutGrassMiniGame BramblesAreCut;
    public InMemoryVariableStorage variableStorage;

    void Update()
    {
        variableStorage.SetValue("$playerName", playerName);
        variableStorage.SetValue("$pronoun1", playerPronoun1);
        variableStorage.SetValue("$pronoun2", playerPronoun2);
        variableStorage.SetValue("$guide", guideName);
        variableStorage.SetValue("$nameChecked", nameChecked);
    }

    [YarnCommand("PlayerNameSet")]
    public void SettingPlayerName()
    {
        playerName = PlayerData.playerName; 
        NameSet = true;
        guideName = "???"; 
        Debug.Log("WeSet"); 
    }
    [YarnCommand("PlayerPronounSet")]
    public void SettingPlayerPronouns()
    {
        if (PlayerData.playerPronoun == "She/Her") 
        {
            playerPronoun1 = "she"; 
            playerPronoun2 = "her"; 
            PronounSet = true;
        }
        else if (PlayerData.playerPronoun == "He/Him")
        {
            playerPronoun1 = "he"; 
            playerPronoun2 = "him"; 
            PronounSet = true;

        }
        else if (PlayerData.playerPronoun == "They/Them")
        {
            playerPronoun1 = "they"; 
            playerPronoun2 = "them"; 
            PronounSet = true;
        }
        else
        {
            Debug.Log("No Pronouns Set!"); 
        }
        
  
    }
[YarnCommand("GuideNameSet")]
    public void SettingGuideName()
    {
        guideName = "Knott"; 
        nameChecked = true;
    }
}

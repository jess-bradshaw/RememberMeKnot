using UnityEngine;
using Yarn.Unity; 

public class YarnVariableStorage : MonoBehaviour
{
    public string playerName; 
    public string playerPronoun1; 
    public string playerPronoun2; 
    [Header("Bool checks for Yarn Script")]
    public bool NameSet; 
    public bool nameChecked; 
    public bool PronounSet; 
    public bool combatDemoCheck; 
//Objects in quests 
    public GameObject tutorialSticky;
//Level Checkpoints 
    public GameObject checkpoint1; 
    public GameObject checkpoint2; 
    public GameObject checkpoint3;

//Quests
    public GameObject quest1;
    public GameObject quest2;
    public GameObject quest3;

    public InMemoryVariableStorage variableStorage;

    void Update()
    {
        variableStorage.SetValue("$playerName", playerName);
        variableStorage.SetValue("$pronoun1", playerPronoun1);
        variableStorage.SetValue("$pronoun2", playerPronoun2);
        variableStorage.SetValue("$nameChecked", nameChecked);
        variableStorage.SetValue("$combatDemoCleared", combatDemoCheck);
    }
  // ------------------ Player Customizations 
[YarnCommand("PlayerNameSet")] public void SettingPlayerName()
    {
        playerName = PlayerData.playerName; 
        NameSet = true;
    }
[YarnCommand("PlayerPronounSet")] public void SettingPlayerPronouns()
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
 // ------------------ Guide/Terry
[YarnCommand("GuideNameSet")] public void SettingGuideName()
    {
        nameChecked = true;
    }
[YarnCommand("TutorialOptions")] public void EnableOptions()
    {
        tutorialSticky.SetActive(true); 
    }
    // ------------------ Scene Triggers
[YarnCommand("EndDemo")] public void EndTheDemo()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene("Pattern"); 
    }
[YarnCommand("CombatDemo")] public void StartCombat()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene("Combat"); 
         combatDemoCheck = true; 
         PlayerData.CombatDemoCheck = true; 
    }
    [YarnCommand("CombatCheck")] public void CheckCombat()
    {
         if(PlayerData.CombatDemoCheck)
         {combatDemoCheck = true;} 
         else
         {
            Debug.Log("No combat yet"); 
         }
          
    }
[YarnCommand("Combat1")] public void StartCombat2()
    {
         UnityEngine.SceneManagement.SceneManager.LoadScene("Combat1"); 
    }
    // ------------------ Checkpoints 
[YarnCommand("Checkpoint1Cleared")] public void ClearCheck1()
    {
        checkpoint1.SetActive(false); 
    }
[YarnCommand("Checkpoint2Cleared")] public void ClearCheck2()
    {
        checkpoint2.SetActive(false); 
    }
[YarnCommand("Checkpoint3Cleared")] public void ClearCheck3()
    {
        checkpoint3.SetActive(false); 
    }
    // ------------------ Quests 
[YarnCommand("Quest1Complete")] public void Quest1()
    {
        quest1.SetActive(true);
    }
[YarnCommand("Quest2Complete")] public void Quest2()
    {
        quest2.SetActive(true);
    }
}

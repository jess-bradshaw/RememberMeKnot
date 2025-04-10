using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
//Jess created this script. 
public class GetValue : MonoBehaviour
{
    [SerializeField] TMP_Text pronounInput; 
    
    
    public void LoadSceneAndKeepValue()
    {
        string playerPronoun = pronounInput.text; 
        PlayerData.playerPronoun = playerPronoun; 
        Debug.Log("Pronoun set"); 
    }
}

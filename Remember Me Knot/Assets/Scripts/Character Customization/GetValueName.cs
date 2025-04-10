using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
//Jess Created. 
public class GetValueName : MonoBehaviour
{
    [SerializeField] TMP_Text nameInput; 

    void Awake()
    {
        PlayerData.playerName = "d3fault"; 
        Debug.Log( PlayerData.playerName); 
        PlayerData.playerPronoun = "d3fault"; 
       // Debug.Log( "Awake pronoun:"+ PlayerData.playerPronoun); 
    }
    
    
    public void KeepValue()
    {
        string playerName = nameInput.text; 
        PlayerData.playerName = playerName; 

        //Debug.Log("Name is: "+ PlayerData.playerName); 
        //Debug.Log("Pronouns are: " + PlayerData.playerPronoun); 
    }
}

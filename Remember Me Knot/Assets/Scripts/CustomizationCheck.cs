using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class CustomizationCheck : MonoBehaviour
{
    [SerializeField] private GameObject pWarning;  
    [SerializeField] private GameObject nWarning;  
    [SerializeField] private LoadScene loadSceneScript; 
    [SerializeField] TMP_Text nameInput; 
   
   public void CustCheck()
   {
        //if (PlayerData.playerName == "d3fault" || PlayerData.playerName == "" || PlayerData.playerName == " ")
         if (nameInput.text =="")
        {
           nWarning.SetActive(true);
           Debug.Log( PlayerData.playerName);
        }
        else if (PlayerData.playerName != "d3fault" && PlayerData.playerPronoun == "d3fault")
        {
            pWarning.SetActive(true); 
            Debug.Log( "Name:" + PlayerData.playerName);
            Debug.Log("No pronoun:"+ PlayerData.playerPronoun);
        }
        else
        {
            pWarning.SetActive(false); 
            nWarning.SetActive(false); 
            Debug.Log( "Name:" + PlayerData.playerName);
            Debug.Log("pronoun:"+ PlayerData.playerPronoun);
            Debug.Log("Loading"); 
            loadSceneScript.LoadLevel1(); 
        }
   }
}

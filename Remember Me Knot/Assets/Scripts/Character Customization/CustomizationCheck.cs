using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class CustomizationCheck : MonoBehaviour
{
    [SerializeField] private GameObject pWarning;  
    [SerializeField] private GameObject nWarning;  
    [SerializeField] private LoadScene loadSceneScript; 
    [SerializeField] private TMP_InputField nameInput; 
   
   public void CustCheck()
   {
        bool isEqual = nameInput.text == "";
        Debug.Log("text length["+ nameInput.text.Trim().Length + "] nameInput["+nameInput.text+"]");
        //if (PlayerData.playerName == "d3fault" || PlayerData.playerName == "" || PlayerData.playerName == " ")
         if (isEqual)
        {
           nWarning.SetActive(true);
           //Debug.Log( PlayerData.playerName);
           AudioManager.instance.PlayOneShot(FMODEvents.instance.BackButton, this.transform.position);
        }
        else if (PlayerData.playerName != "d3fault" && PlayerData.playerPronoun == "d3fault")
        {
            nWarning.SetActive(false);
            pWarning.SetActive(true); 
            AudioManager.instance.PlayOneShot(FMODEvents.instance.BackButton, this.transform.position);
            //Debug.Log( "Name:" + PlayerData.playerName);
            //Debug.Log("No pronoun:"+ PlayerData.playerPronoun);
        }
        else
        {
            pWarning.SetActive(false); 
            nWarning.SetActive(false); 
            //Debug.Log( "Name: " + PlayerData.playerName);
            //Debug.Log("pronoun: "+ PlayerData.playerPronoun);
            //Debug.Log("Loading"); 
            AudioManager.instance.PlayOneShot(FMODEvents.instance.ContinueButton, this.transform.position); 
            loadSceneScript.LoadLevel1(); 
        }
   }
}

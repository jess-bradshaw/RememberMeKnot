using UnityEngine;
using UnityEngine.UI; 
using TMPro; 
//Jess created this. Keely helped troubleshoot tMP issues. 
public class GiveValue : MonoBehaviour
{
   [SerializeField] TMP_Text pronounText; 
   [SerializeField] TMP_Text nameText; 
   public void Start()
   {
        string nText = PlayerData.playerName; 
        nameText.text = nText; 
   }
   public void testPronoun()
   {
        string newText = PlayerData.playerPronoun; 
        pronounText.text = newText; 
   }
}

using UnityEngine;
using UnityEngine.UI; 

public class GiveValue : MonoBehaviour
{
   [SerializeField] Text myText; 
   public void Start()
   {
        string newText = PlayerData.playerName; 
        myText.text = newText; 
   }
}

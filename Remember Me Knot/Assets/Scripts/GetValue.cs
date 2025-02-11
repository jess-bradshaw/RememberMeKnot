using UnityEngine;
using UnityEngine.UI; 

public class GetValue : MonoBehaviour
{
    [SerializeField] Text nameInput; 
    [SerializeField] Text pronounInput; 


    // Update is called once per frame
    public void LoadSceneAndKeepValue()
    {
        string playerName = nameInput.text; 
        PlayerData.playerName = playerName; 

        string playerPronoun = pronounInput.text; 
        PlayerData.playerPronoun = playerPronoun; 
        SceneManager.LoadScene("Level1"); 
    }
}

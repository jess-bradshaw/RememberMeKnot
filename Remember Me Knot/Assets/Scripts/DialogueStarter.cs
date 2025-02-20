using UnityEngine;
using Yarn.Unity; 

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] private string conversationStartNode; 
    public DialogueRunner dialogueRunner; 
    public GameObject inputPopup; 
    
     private void OnTriggerEnter (Collider other)
    {
        //check if the other collider is the player character 
        if (other.CompareTag("Player") && dialogueRunner != null) 
        { 
            inputPopup.SetActive(true);
        }
    }
    private void OnTriggerStay (Collider other)
    {
        //check if the other collider is the player character 
        if (other.CompareTag("Player") && dialogueRunner != null) 
        { 
            if(Input.GetKeyDown(KeyCode.F))
            {
            Debug.Log("F was pressed"); 
            dialogueRunner.StartDialogue(conversationStartNode);
            inputPopup.SetActive(false); 
            }
        }
    }
     private void OnTriggerExit (Collider other)
    {
        //check if the other collider is the player character 
        if (other.CompareTag("Player") && dialogueRunner != null) 
        { 
            inputPopup.SetActive(false);
        }
    }

}

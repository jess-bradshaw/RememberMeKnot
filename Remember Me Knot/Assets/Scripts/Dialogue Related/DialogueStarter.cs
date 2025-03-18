using UnityEngine;
using Yarn.Unity; 

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] private string conversationStartNode; 
    public DialogueRunner dialogueRunner; 
    //public GameObject inputPopup; 
    public bool inside; 
    
     private void OnTriggerEnter (Collider other)
    {
       if (other.CompareTag("Player"))
       {
        inside = true; 
       }
    }
    void OnTriggerStay(Collider other)
    {
        //check if the other collider is the player character 
        if (dialogueRunner != null) 
        { 
            if(Input.GetKeyDown(KeyCode.F))
            {
            Debug.Log("F was pressed"); 
            dialogueRunner.StartDialogue(conversationStartNode); 
            }
        }
    }
     private void OnTriggerExit (Collider other)
    {
        //check if the other collider is the player character 
        if (other.CompareTag("Player")) 
        { 
            inside = false; 
        }
    }

}

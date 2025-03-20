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
    private void Update()
    {
        //check if the other collider is the player character 
        if (inside && dialogueRunner != null && !dialogueRunner.IsDialogueRunning) 
        { 
            if(Input.GetKeyDown(KeyCode.Space))
            {
            Debug.Log("F was pressed "+ gameObject.name + " with conversationStartNode " + conversationStartNode); 
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

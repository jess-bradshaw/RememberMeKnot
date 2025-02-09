using UnityEngine;
using Yarn.Unity; 

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] private string conversationStartNode; 
    public DialogueRunner dialogueRunner; 
    
    private void OnTriggerEnter (Collider other)
    {
        //check if the other collider is the player character 
        if (other.CompareTag("Player") && dialogueRunner != null)
        {
            dialogueRunner.StartDialogue(conversationStartNode); 
        }
    }
}

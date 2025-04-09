using UnityEngine;
using Yarn.Unity; 

public class DialogueStarter : MonoBehaviour
{
    [SerializeField] private string conversationStartNode; 
    public DialogueRunner dialogueRunner;


    //public GameObject inputPopup; 
    public bool inside;



    [SerializeField]
    private float readyDelay = 1f;
    private bool readyToInteract = true;
    private bool preparingToReady = false;

     private void OnTriggerEnter (Collider other)
    {
       if (other.CompareTag("Player"))
       {
        inside = true; 
       }
    }
    private void Update()
    {
        if (!readyToInteract && !dialogueRunner.IsDialogueRunning && !preparingToReady)
        {
            preparingToReady = true;
            Invoke("SetReady", readyDelay);
        }

        //check if the other collider is the player character 
        if (inside && dialogueRunner != null && readyToInteract) 
        { 
            if(Input.GetKeyDown(KeyCode.Space))
            {
                //Debug.Log("F was pressed "+ gameObject.name + " with conversationStartNode " + conversationStartNode); 
                dialogueRunner.StartDialogue(conversationStartNode);
                readyToInteract = false;
            }
        }
    }

    public void SetReady()
    {
        readyToInteract = true;
        preparingToReady = false;
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

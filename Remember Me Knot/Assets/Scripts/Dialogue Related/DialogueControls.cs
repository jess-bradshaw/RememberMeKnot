using UnityEngine;
using Yarn.Unity; 
using UnityEngine.UI; 

//Inspired by: https://www.youtube.com/watch?v=gJrf6ON5UPE 

public class DialogueControls : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text dialogue = null;

 //   private DialogueUI dialogueUI = null;
    private TMPro.TMP_Text[] options; //collects all options. 

    private int optionSize;  //controls size of the options on screen. 
    private int currentOption;  //saves current selected option. 

    private bool isOptionDisplayed;
    
    void Start()
    {
        // Check to see if options are needed to enable controls. 
        isOptionDisplayed = false;
    
 //       dialogueUI = FindObjectOfType<DialogueUI>();  // Dialogue UI.
  //      optionSize = dialogueUI.optionButtons.Count; // Save # of options. 
        currentOption = 0; // Initialize the current index
        options = new TMPro.TMP_Text[optionSize]; // Initialize number of options avaliable. 
       
        // Get the TextMeshPro Text components from the option buttons in the DialogueUI 
        for (int i = 0; i < optionSize; i++)
        {
   //         options[i] = dialogueUI.optionButtons[i].GetComponentInChildren<TMPro.TMP_Text>();
        }
    }

    // Update is called once per frame
    void Update()
    {
         ControlOptions();
    }
    private void ControlOptions()
    {
        if (isOptionDisplayed)
        {
            ChangeOption();
            SelectOption();
        }
        else
        {
            SkipDialogue();
        }
    }
     private void ChangeOption()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
          // if (currentOption == 0)
          //      currentOption = optionSize + 1;
          //  else
           //     currentOption = (Mathf.Abs(currentOption + 1) % optionSize);
            //currentOption = (currentOption + 1) % optionSize;
          //  dialogue.SetText(options[currentOption].text);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            //Move to the previous option
          //  if (currentOption == 0)
          //      currentOption = optionSize - 1;
          //  else
          //      currentOption = (Mathf.Abs(currentOption - 1) % optionSize);
//
         //   dialogue.SetText(options[currentOption].text);
        }
    }
    private void SkipDialogue()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
//            dialogueUI.MarkLineComplete();
        }
    }

    private void SelectOption()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
 //           dialogueUI.SelectOption(currentOption);
            ResetCurrentOption();
        }
    }

    private void ResetCurrentOption()
    {
        currentOption = 0;
    }

    public void SetStartingOption()
    {
        dialogue.SetText(options[0].text);
    }

    public void SetOptionDisplayed(bool flag)
    {
        isOptionDisplayed = flag;
    }
}

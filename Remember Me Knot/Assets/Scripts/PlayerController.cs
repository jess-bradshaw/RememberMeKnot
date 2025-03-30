using UnityEngine;
using UnityEngine.InputSystem; 
using Yarn.Unity; 
using FMOD.Studio; 
using System.Collections;
using System.Collections.Generic;
// inspired by https://www.youtube.com/watch?v=WNV9l04s8t4 & https://www.youtube.com/watch?v=T9PGE2m6ndo & https://www.youtube.com/watch?v=xHoRkZR61JQ tutorial 

[RequireComponent(typeof(CharacterController))] //This is prevents removing character controller. Learning something new! 


public class PlayerController : MonoBehaviour
{
   public static AudioManager instance {get; private set;}
   private Vector2 movementInput; 
   private CharacterController characterController; 
   private Vector3 movementDirection; 
   public DialogueRunner dialogueRunner; 
   public GameObject playerInputObject;

    [SerializeField] private Animator animator;

   [SerializeField] private float smoothTime = 0.05f; 
   private float _currentVelocity; 
   
   [SerializeField] private float speed; 
   [Header("Action Maps")]
       // [SerializeField]
       // private string dialogueInputActionMap = "Dialogue";
       // [SerializeField]
       // private string movementInputActionMap = "Player";
         [SerializeField] DialogueRunner? primaryDialogueRunner;

    private EventInstance playerFootsteps; 

    private void Awake()
    {
        characterController = GetComponent<CharacterController>(); 
        var dialogueRunner = primaryDialogueRunner;
        var playerInput = GetComponent<PlayerInput>();

            dialogueRunner.onDialogueStart.AddListener(() =>
            {
               playerInputObject.SetActive(false); 
         });
           dialogueRunner.onDialogueComplete.AddListener(() =>
            {
               playerInputObject.SetActive(true); 
            });
            //FindObjectOfType<Instance>
    }
    private void Start()
    {
        playerFootsteps = AudioManager.instance.CreateInstance(FMODEvents.instance.FootSteps); 
    }
   private void Update()
   {
        // setting walk speed, so animations play
        animator.SetFloat("Walk", movementInput.magnitude);
        
        if(movementInput.sqrMagnitude == 0)
        {
            return;
        }
        
        var targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg; //finding degree and converting to degree. 
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime); 
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f); 
        characterController.Move(movementDirection * speed * Time.deltaTime);
   }
   private void FixedUpdate()
   {
    UpdateSound(); 
   }

   public void Move(InputAction.CallbackContext context)
   {
        movementInput = context.ReadValue<Vector2>();
        movementDirection = new Vector3(movementInput.x, 0.0f, movementInput.y); 
   }

   private void UpdateSound ()
    {
        if(movementInput.magnitude !=0 )
        {
            PLAYBACK_STATE playbackState; 
            playerFootsteps.getPlaybackState ( out playbackState); 
            if(playbackState.Equals(PLAYBACK_STATE.STOPPED))
            {
                playerFootsteps.start(); 
            }
        }
        else 
        {
            playerFootsteps.stop(STOP_MODE.ALLOWFADEOUT); 
        }
    }
}

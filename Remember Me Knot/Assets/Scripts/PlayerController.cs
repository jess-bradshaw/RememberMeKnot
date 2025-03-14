using UnityEngine;
using UnityEngine.InputSystem; 
using Yarn.Unity; 

// inspired by https://www.youtube.com/watch?v=WNV9l04s8t4 & https://www.youtube.com/watch?v=T9PGE2m6ndo & https://www.youtube.com/watch?v=xHoRkZR61JQ tutorial 

[RequireComponent(typeof(CharacterController))] //This is prevents removing character controller. Learning something new! 

public class PlayerController : MonoBehaviour
{
   private Vector2 movementInput; 
   private CharacterController characterController; 
   private Vector3 movementDirection; 
   public DialogueRunner dialogueRunner; 
   public GameObject playerInputObject; 

   [SerializeField] private float smoothTime = 0.05f; 
   private float _currentVelocity; 
   
   [SerializeField] private float speed; 
   [Header("Action Maps")]
       // [SerializeField]
       // private string dialogueInputActionMap = "Dialogue";
       // [SerializeField]
       // private string movementInputActionMap = "Player";
         [SerializeField] DialogueRunner? primaryDialogueRunner;

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
    }

   private void Update()
   {
        if(movementInput.sqrMagnitude == 0)
        {
            return;
        }
        
        var targetAngle = Mathf.Atan2(movementDirection.x, movementDirection.z) * Mathf.Rad2Deg; //finding degree and converting to degree. 
        var angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _currentVelocity, smoothTime); 
        transform.rotation = Quaternion.Euler(0.0f, angle, 0.0f); 
        characterController.Move(movementDirection * speed * Time.deltaTime);

   }

   public void Move(InputAction.CallbackContext context)
   {
        movementInput = context.ReadValue<Vector2>();
        movementDirection = new Vector3(movementInput.x, 0.0f, movementInput.y); 
   }
}

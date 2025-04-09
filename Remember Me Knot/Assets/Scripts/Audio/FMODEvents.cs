using UnityEngine;
using FMODUnity; 
// code inspired from: https://www.youtube.com/watch?v=rcBHIOjZDpk 
public class FMODEvents : MonoBehaviour
{
//SFX
[field: Header("UI SFX")]
   [field: SerializeField] public EventReference ContinueButton {get; private set;} 
   [field: SerializeField] public EventReference RightButton {get; private set;} 
   [field: SerializeField] public EventReference LeftButton {get; private set;} 
   [field: SerializeField] public EventReference BackButton {get; private set;} 
    [field: SerializeField] public EventReference Dialogue {get; private set;} 
[field: Header("Player SFX")]
   [field: SerializeField] public EventReference FootSteps {get; private set;} 
//background noises  
   [field: Header("Background Music")]
   [field: SerializeField] public EventReference BackgroundMusic {get; private set;} 
   [field: Header("Background Noises")]
  // [field: SerializeField] public EventReference BackgroundNoises {get; private set;} 
   

    public static FMODEvents instance {get; private set;}
   
   private void Awake()
   {
    if (instance != null)  //Singleton Setup
    {
        Debug.LogError("Found more than one FMOD Events instance in the scene.");
    }
    instance = this; 
   }
}

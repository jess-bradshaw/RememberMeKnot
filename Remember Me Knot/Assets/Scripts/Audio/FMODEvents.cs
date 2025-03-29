using UnityEngine;
using FMODUnity; 
// code inspired from: https://www.youtube.com/watch?v=rcBHIOjZDpk 
public class FMODEvents : MonoBehaviour
{
//SFX
   [field: Header("Continue")]
   [field: SerializeField] public EventReference ContinueButton {get; private set;} 
   [field: Header("Right Option")]
   [field: SerializeField] public EventReference RightButton {get; private set;} 
   [field: Header("Left Option")]
   [field: SerializeField] public EventReference LeftButton {get; private set;} 
    [field: Header("Back Button")]
   [field: SerializeField] public EventReference BackButton {get; private set;} 
//Music 
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

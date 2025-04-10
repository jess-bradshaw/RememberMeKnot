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
   [field: SerializeField] public EventReference Victory {get; private set;} 
[field: Header("Player SFX")]
   [field: SerializeField] public EventReference FootSteps {get; private set;} 
   [field: SerializeField] public EventReference PlayerHeal {get; private set;} 
   [field: SerializeField] public EventReference PlayerDefend {get; private set;} 
   [field: SerializeField] public EventReference PlayerAttack {get; private set;} 
[field: Header("Enemy SFX")]
   [field: SerializeField] public EventReference EnemyHeal {get; private set;} 
   [field: SerializeField] public EventReference EnemyDefend {get; private set;} 
      [field: SerializeField] public EventReference EnemyAttack {get; private set;} 
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

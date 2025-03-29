using UnityEngine;
// code from:  https://www.youtube.com/watch?v=rcBHIOjZDpk
public class ContinueAudio : MonoBehaviour
{
    public void PlayAudioSound(){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.ContinueButton, this.transform.position); 
    }
    public void PlayBackSound(){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.BackButton, this.transform.position); 
    }
    public void PlayRightSound(){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.RightButton, this.transform.position); 
    }
    public void PlayLeftSound(){
        AudioManager.instance.PlayOneShot(FMODEvents.instance.LeftButton, this.transform.position); 
    }
}

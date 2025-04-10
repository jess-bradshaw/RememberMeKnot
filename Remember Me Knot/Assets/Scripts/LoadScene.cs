using UnityEngine;
using UnityEngine.SceneManagement; 
//Jess created 
public class LoadScene : MonoBehaviour
{
    //public Animator transition;
    //public Animator bubble;
    
    
    public void LoadLevel1()
    {
       // StartCoroutine ("Transition");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Level1"); 
    }

    public void LoadLevel2()
    {
       // StartCoroutine ("Transition");
        UnityEngine.SceneManagement.SceneManager.LoadScene("Pattern"); 
    }
    public void LoadMenu()
    {
        //StartCoroutine ("Transition");
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu"); 
    }

    // IEnumerator Transition()
    // {
    //    transition.SetTrigger("Start");
    //    bubble.Play("Plane_Transition");
    //     yield return new WaitForSeconds(1f);
    // }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Quitting(); 
        }
    }
   public void Quitting()
   {
    Application.Quit(); 
   }
}

using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public GameObject player; 
    public GameObject mandatoryFightLocation; 
    public GameObject mandatoryFluffBug; 
     [SerializeField] private Animator caliAnimator;
    void Start()
    {
        if (PlayerData.mandatoryFightComplete == true)
        {
            player.transform.position = mandatoryFightLocation.transform.position; 
            Debug.Log("I moved");
            mandatoryFluffBug.SetActive(false); 
            caliAnimator.SetBool("Cleared", true);
        }

        // if ( == true)
       // {
         //   sbyte position of player to optionalFightLocation 
        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

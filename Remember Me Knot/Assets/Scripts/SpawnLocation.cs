using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public GameObject player; 
    public GameObject mandatoryFightLocation; 
    public GameObject mandatoryFluffBug; 
    public GameObject Cali; 
    public GameObject Cali2; 
    public GameObject barrier; 
     [SerializeField] private Animator caliAnimator;
    void Start()
    {
        if (PlayerData.mandatoryFightComplete == true)
        {
            player.transform.position = mandatoryFightLocation.transform.position; 
            Debug.Log("I moved");
            mandatoryFluffBug.SetActive(false); 
            Cali.SetActive(false); 
            Cali2.SetActive(true); 
            barrier.SetActive(false); 

        }

        // if ( == true)
       // {
         //   sbyte position of player to optionalFightLocation 
        //}
    }
}

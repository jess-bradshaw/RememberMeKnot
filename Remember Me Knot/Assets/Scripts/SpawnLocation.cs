using UnityEngine;

public class SpawnLocation : MonoBehaviour
{
    public GameObject player; 
    public GameObject mandatoryFightLocation; 
    public GameObject mandatoryFluffBug; 
    void Start()
    {
        if (PlayerData.mandatoryFightComplete == true)
        {
            player.transform.position = mandatoryFightLocation.transform.position; 
            Debug.Log("I moved");
            mandatoryFluffBug.SetActive(false); 
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

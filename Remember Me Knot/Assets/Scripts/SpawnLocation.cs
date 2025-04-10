using UnityEngine;
// Jess made this script from Scratch
public class SpawnLocation : MonoBehaviour
{
    public GameObject player; 
    public GameObject mandatoryFightLocation; 
    public GameObject optionalFightLocation; 
    public GameObject mandatoryFluffBug;
    public GameObject optionalFluffBug;  
    public GameObject Cali; 
    public GameObject Cali2; 
     public GameObject Twill; 
    public GameObject Twill2;
    public GameObject barrier; 
    public GameObject stitchLocation; 
    public GameObject stitch; 
     [SerializeField] private Animator caliAnimator;
    void Start()
    {
        if (PlayerData.mandatoryFightComplete == true && PlayerData.optionalFightComplete == false)
        {
            player.transform.position = mandatoryFightLocation.transform.position; 
            mandatoryFluffBug.SetActive(false); 
            Cali.SetActive(false); 
            Cali2.SetActive(true); 
            barrier.SetActive(false); 
            stitch.transform.position = stitchLocation.transform.position;
        }
        if (PlayerData.mandatoryFightComplete == true && PlayerData.optionalFightComplete == true)
        {
            player.transform.position = optionalFightLocation.transform.position; 
            optionalFluffBug.SetActive(false); 
            Twill.SetActive(false); 
            Twill2.SetActive(true); 
            mandatoryFluffBug.SetActive(false); 
            Cali.SetActive(false); 
            Cali2.SetActive(true); 
        }
    }
}

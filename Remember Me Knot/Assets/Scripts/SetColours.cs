using UnityEngine;
using System.Collections.Generic;

public class SetColours : MonoBehaviour
{
   public GameObject characterhead;
    public GameObject charactereyes;
    [SerializeField] public List<Color> listOfColours; 

     void Awake()
     {
        charactereyes.GetComponent<Renderer>().material.color = listOfColours[PlayerData.playerEyes];
        characterhead.GetComponent<Renderer>().material.color = listOfColours[PlayerData.playerWoolColour];
     }
}

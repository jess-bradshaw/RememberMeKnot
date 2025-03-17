using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetColours : MonoBehaviour
{
   public GameObject characterhead;
    public GameObject charactereyes;
    [SerializeField] public List<Color> listOfColours; 

     void Awake()
     {
        charactereyes.GetComponent<Renderer>().material.color = listOfColours[PlayerData.scarfWoolColour];
        characterhead.GetComponent<Renderer>().material.color = listOfColours[PlayerData.bodyWoolColour];
     }
}

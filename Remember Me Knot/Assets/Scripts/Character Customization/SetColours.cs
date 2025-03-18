using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetColours : MonoBehaviour
{
   public GameObject body;
   public GameObject hat;
   public GameObject pom;
   public GameObject scarf;
   public GameObject coat; 
   [SerializeField] public List<Color> listOfColours; 

     void Awake()
     {
        body.GetComponent<Renderer>().material.color = listOfColours[PlayerData.bodyWoolColour];
        hat.GetComponent<Renderer>().material.color = listOfColours[PlayerData.hatWoolColour];
        pom.GetComponent<Renderer>().material.color = listOfColours[PlayerData.pomWoolColour];
        scarf.GetComponent<Renderer>().material.color = listOfColours[PlayerData.scarfWoolColour];
        coat.GetComponent<Renderer>().material.color = listOfColours[PlayerData.coatWoolColour];
     }
}

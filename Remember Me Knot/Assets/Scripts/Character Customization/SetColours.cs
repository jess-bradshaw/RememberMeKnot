using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
//Jess created this. 
public class SetColours : MonoBehaviour
{
   public GameObject face;
   public GameObject hat;
   public GameObject pom;
   public GameObject scarf;
   public GameObject coat; 
   [SerializeField] public List<Color> listOfColours; 

     void Awake()
     {
       face.GetComponent<Renderer>().material.color = listOfColours[PlayerData.bodyWoolColour];
        hat.GetComponent<Renderer>().material.color = listOfColours[PlayerData.hatWoolColour];
        pom.GetComponent<Renderer>().material.color = listOfColours[PlayerData.pomWoolColour];
        scarf.GetComponent<Renderer>().material.color = listOfColours[PlayerData.scarfWoolColour];
        coat.GetComponent<Renderer>().material.color = listOfColours[PlayerData.coatWoolColour];
     }
}

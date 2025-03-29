using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; 

public class GetColourValue : MonoBehaviour
{
    //Gameobjects to grab materials. 
    public GameObject characterhead;
    public GameObject characterscarf;
    public GameObject charactercoat;
    public GameObject characterpom;
    public GameObject characterhat;
    // UI colour swatches 
    public GameObject UIbody; 
    public GameObject UIscarf; 
    public GameObject UIcoat; 
    public GameObject UIpom; 
    public GameObject UIhat; 
    // numbers to keep track of selection in the array 
    public int bodyNumber; 
    public int scarfNumber; 
    public int coatNumber; 
    public int pomNumber; 
    public int hatNumber; 
    [SerializeField] public List<Color> listOfColours; 

     void Awake()
     {
       // listOfColours
         bodyNumber = 0;
         BodyUpdate(); 
         scarfNumber = 0;
         ScarfUpdate(); 
         coatNumber = 0;
         CoatUpdate(); 
         pomNumber = 0;
         PomUpdate(); 
         hatNumber = 0;
         HatUpdate(); 
     }
     public void GetColour()
    {
       PlayerData.bodyWoolColour = bodyNumber; 
       PlayerData.scarfWoolColour = scarfNumber; 
       PlayerData.coatWoolColour = coatNumber; 
       PlayerData.hatWoolColour = hatNumber; 
       PlayerData.pomWoolColour = pomNumber; 
    }
    // Body related
    public void BodyRight()
    {
         bodyNumber ++; 
         if (bodyNumber > 24){bodyNumber = 0;}
         BodyUpdate();
    }
    public void BodyLeft()
    {
         bodyNumber --; 
         if (bodyNumber<0){bodyNumber = 24;}
         BodyUpdate(); 
    }
    public void BodyUpdate()
    {
       characterhead.GetComponent<Renderer>().material.color = listOfColours[bodyNumber]; 
        UIbody.GetComponent<Image>().color = listOfColours[bodyNumber]; 
    }
    //Scarf related 
    public void ScarfRight()
    {
         scarfNumber ++; 
         if (scarfNumber > 24){scarfNumber = 0;}
         ScarfUpdate(); 
    }
    public void ScarfLeft()
    {
         scarfNumber --; 
         if (scarfNumber<0){scarfNumber = 24;}
        ScarfUpdate(); 
    }
    public void ScarfUpdate()
    {
        characterscarf.GetComponent<Renderer>().material.color = listOfColours[scarfNumber];
        UIscarf.GetComponent<Image>().color = listOfColours[scarfNumber]; 
    }
    //Coat Related
        public void CoatRight()
    {
         coatNumber ++; 
         if (coatNumber > 24){coatNumber = 0;}
         CoatUpdate(); 
    }
    public void CoatLeft()
    {
         coatNumber --; 
         if (coatNumber<0){coatNumber = 24;}
         CoatUpdate(); 
    }
    public void CoatUpdate()
    {
        charactercoat.GetComponent<Renderer>().material.color = listOfColours[coatNumber];
        UIcoat.GetComponent<Image>().color = listOfColours[coatNumber]; 
    }
     //Pom Related
        public void PomRight()
    {
         pomNumber ++; 
         if (pomNumber > 24){pomNumber = 0;}
         PomUpdate(); 
    }
    public void PomLeft()
    {
         pomNumber --; 
         if (pomNumber<0){pomNumber = 24;}
         PomUpdate(); 
    }
    public void PomUpdate()
    {
        characterpom.GetComponent<Renderer>().material.color = listOfColours[pomNumber];
        UIpom.GetComponent<Image>().color = listOfColours[pomNumber]; 
    }
     //Hat Related
        public void HatRight()
    {
         hatNumber ++; 
         if (hatNumber > 24){hatNumber = 0;}
         HatUpdate(); 
    }
    public void HatLeft()
    {
         hatNumber --; 
         if (hatNumber<0){hatNumber = 24;}
         HatUpdate(); 
    }
    public void HatUpdate()
    {
        characterhat.GetComponent<Renderer>().material.color = listOfColours[hatNumber];
        UIhat.GetComponent<Image>().color = listOfColours[hatNumber]; 
    }
}

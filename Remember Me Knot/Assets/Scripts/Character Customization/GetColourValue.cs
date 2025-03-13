using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; 

public class GetColourValue : MonoBehaviour
{
    public GameObject characterhead;
    public GameObject charactereyes;
    public GameObject UIitem; 
    public GameObject UIitem2; 
    public int optionNumber; 
    public int optionNumber2; 
    [SerializeField] public List<Color> listOfColours; 

     void Awake()
     {
       // listOfColours
       optionNumber = 0;
       ColourUpdate(); 
        optionNumber2 = 0;
       ColourUpdate2(); 
     }
    public void ChangeColourRight()
    {
       optionNumber ++; 
        if (optionNumber > 25)
       {
        optionNumber = 0; 
       }
       ColourUpdate(); 
    }
    public void ChangeColourLeft()
    {
        optionNumber --; 
       if (optionNumber<0)
       {
        optionNumber = 25; 
       }
       ColourUpdate(); 
    }
    public void GetColour()
    {
       PlayerData.playerWoolColour = optionNumber; 
       PlayerData.playerEyes = optionNumber2; 
    }
    public void ColourUpdate()
    {
       characterhead.GetComponent<Renderer>().material.color = listOfColours[optionNumber]; 
        UIitem.GetComponent<Image>().color = listOfColours[optionNumber]; 
    }
    public void ChangeColourRight2()
    {
       optionNumber2 ++; 
        if (optionNumber2 > 25)
       {
        optionNumber2 = 0; 
       }
       ColourUpdate2(); 
    }
    public void ChangeColourLeft2()
    {
        optionNumber2 --; 
       if (optionNumber2<0)
       {
        optionNumber2 = 25; 
       }
       ColourUpdate2(); 
    }
    public void ColourUpdate2()
    {
        charactereyes.GetComponent<Renderer>().material.color = listOfColours[optionNumber2];
        UIitem2.GetComponent<Image>().color = listOfColours[optionNumber2]; 
    }
}

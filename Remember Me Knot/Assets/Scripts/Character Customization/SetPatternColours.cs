using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetPatternColours : MonoBehaviour
{
    public GameObject UIBody;
    public GameObject UIHat;
    public GameObject UIPom;
    public GameObject UIScarf;
    public GameObject UICoat;
    [SerializeField] public List<Color> listOfColours;

    void Awake()
    {
        UIBody.GetComponent<Image>().color = listOfColours[PlayerData.bodyWoolColour];
        UIHat.GetComponent<Image>().color = listOfColours[PlayerData.hatWoolColour];
        UIPom.GetComponent<Image>().color = listOfColours[PlayerData.pomWoolColour];
        UIScarf.GetComponent<Image>().color = listOfColours[PlayerData.scarfWoolColour];
        UICoat.GetComponent<Image>().color = listOfColours[PlayerData.coatWoolColour];
    }
}

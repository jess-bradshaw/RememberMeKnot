using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class SetPatternColours : MonoBehaviour
{
    public GameObject UIitem;
    public GameObject UIitem2;
    [SerializeField] public List<Color> listOfColours;

    void Awake()
    {
        UIitem.GetComponent<Image>().color = listOfColours[PlayerData.scarfWoolColour];
        UIitem2.GetComponent<Image>().color = listOfColours[PlayerData.bodyWoolColour];
    }
}

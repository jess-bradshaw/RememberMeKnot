using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
//Jess created. Keely helped with direction but Jess coded it. 
public class SetPatternColours : MonoBehaviour
{
    public GameObject UIBody;
    public GameObject UIHat;
    public GameObject UIPom;
    public GameObject UIScarf;
    public GameObject UICoat;
    public GameObject RedHeart;
    public GameObject WhiteHeart;
    [SerializeField] public List<Color> listOfColours;

    void Awake()
    {
        UIBody.GetComponent<Image>().color = listOfColours[PlayerData.bodyWoolColour];
        UIHat.GetComponent<Image>().color = listOfColours[PlayerData.hatWoolColour];
        UIPom.GetComponent<Image>().color = listOfColours[PlayerData.pomWoolColour];
        UIScarf.GetComponent<Image>().color = listOfColours[PlayerData.scarfWoolColour];
        UICoat.GetComponent<Image>().color = listOfColours[PlayerData.coatWoolColour];

        if (PlayerData.WhiteHeartCheck)
        {
            WhiteHeart.SetActive(true); 
        }
        else if (PlayerData.RedHeartCheck)
        {
            RedHeart.SetActive(true);
        }
        else
        {
            Debug.Log("No Optional"); 
            WhiteHeart.SetActive(false);
            RedHeart.SetActive(false); 
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
public class ActionIndicator : MonoBehaviour
{
    [SerializeField]
    private Image actionImage;

    [SerializeField]
    private GameObject highlightObject;

    public void Initialize(Color actionColour)
    {
        actionImage.color = actionColour;
    }

    public void Highlight()
    {
        highlightObject.SetActive(true);
    }

    public void Unhighlight()
    {
        highlightObject.SetActive(false);
    }

}

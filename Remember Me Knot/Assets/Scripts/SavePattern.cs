using UnityEngine;

public class SavePattern : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SavePatternFile()
    {
        string folderPath = "Assets/Screenshots"; 
        if(!System.IO.Directory.Exists(folderPath))
        {
            System.IO.Directory.CreateDirectory(folderPath); 
        }
        var screenshotName = "Screenshot_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png"; 
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName),2); 
        Debug.Log(folderPath + screenshotName); 
    }
}

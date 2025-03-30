using UnityEngine;

public class SavePattern : MonoBehaviour
{
    public void SavePatternFile()
    {
        string folderPath = "Screenshots"; 
        if(!System.IO.Directory.Exists(folderPath))
        {
        System.IO.Directory.CreateDirectory(folderPath); 
        }
        var screenshotName = "Screenshot_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png"; 
        ScreenCapture.CaptureScreenshot(System.IO.Path.Combine(folderPath, screenshotName),4); 
        Debug.Log(folderPath +" "+  screenshotName); 
    }
}

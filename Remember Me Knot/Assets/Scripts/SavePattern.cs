using UnityEngine;

public class SavePattern : MonoBehaviour
{
    public void SavePatternFile()
    {
        string folderPath = Application.dataPath + "/Patterns"; 
        if(!System.IO.Directory.Exists(folderPath))
        {
        System.IO.Directory.CreateDirectory(folderPath); 
        }
        var screenshotName = "Screenshot_" + System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss") + ".png"; 
        string fullFilePath = System.IO.Path.Combine(folderPath, screenshotName);
        ScreenCapture.CaptureScreenshot(fullFilePath, 2); 
       // Debug.Log(folderPath +" "+  screenshotName); 
    }
}

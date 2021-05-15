using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DISPLAY_SETTINGS : MonoBehaviour
{
    public Dropdown ResolutionDropdown;
    public Dropdown QualityDropdown;
    private void Start()
    {
        if(Screen.currentResolution.width==1920)
        {
            ResolutionDropdown.value = 0;
        }
        else if(Screen.currentResolution.width == 1600)
        {
            ResolutionDropdown.value = 1;
        }
        else if (Screen.currentResolution.width == 1280)
        {
            ResolutionDropdown.value = 2;
        }
        ResolutionDropdown.RefreshShownValue();
        QualityDropdown.value = QualitySettings.GetQualityLevel();
        QualityDropdown.RefreshShownValue();

    }
    public void OnResolutionChange(Dropdown dropDown)
    {
        if(dropDown.value==0)
        {
            Screen.SetResolution(1920, 1080, Screen.fullScreen);
        }
        if (dropDown.value == 1)
        {
            Screen.SetResolution(1600, 900, Screen.fullScreen);
        }
        if (dropDown.value == 2)
        {
            Screen.SetResolution(1280, 720, Screen.fullScreen);
        }
    }

    public void FullScreenChange(bool toggle)
    {
        Screen.fullScreen = toggle;
    }
    public void SetQuality(Dropdown dropdown)
    {
        QualitySettings.SetQualityLevel(dropdown.value);
        Debug.Log(QualitySettings.GetQualityLevel());
    }
}

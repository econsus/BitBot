using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsScript : MonoBehaviour
{
    public AudioMixer audiomixer;

    public TMPro.TMP_Dropdown resolutionDropdown;

    Resolution[] resolutions;

    public void SetVolume(float volume)
    {
        audiomixer.SetFloat("MasterVolume", volume);
    }

    public void SetFullScreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
    
    void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //+ " " + resolutions[i].refreshRate.ToString() + " Hz";
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }


        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
            
        //RescaleCamera();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

        private int ScreenSizeX = 0;
        private int ScreenSizeY = 0;
        private void RescaleCamera()
        {

            if (Screen.width == ScreenSizeX && Screen.height == ScreenSizeY) return;

            float targetaspect = 16.0f / 9.0f;
            float windowaspect = (float)Screen.width / (float)Screen.height;
            float scaleheight = windowaspect / targetaspect;
            Camera camera = GetComponent<Camera>();

            if (scaleheight < 1.0f)
            {
                Rect rect = camera.rect;

                rect.width = 1.0f;
                rect.height = scaleheight;
                rect.x = 0;
                rect.y = (1.0f - scaleheight) / 2.0f;

                camera.rect = rect;
            }
            else
            {
                float scalewidth = 1.0f / scaleheight;

                Rect rect = camera.rect;

                rect.width = scalewidth;
                rect.height = 1.0f;
                rect.x = (1.0f - scalewidth) / 2.0f;
                rect.y = 0;

                camera.rect = rect;
            }

            ScreenSizeX = Screen.width;
            ScreenSizeY = Screen.height;
        }
        void OnPreCull()
        {
            if (Application.isEditor) return;
            Rect wp = Camera.main.rect;
            Rect nr = new Rect(0, 0, 1, 1);

            Camera.main.rect = nr;
            GL.Clear(true, true, Color.black);

            Camera.main.rect = wp;

        }
 
}
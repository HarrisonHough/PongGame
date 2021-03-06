﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
* AUTHOR: Harrison Hough   
* COPYRIGHT: Harrison Hough 2018
* VERSION: 1.0
* SCRIPT: Screen Orientation Class 
*/

public class ScreenOrientation : MonoBehaviour {

    public enum Orientation { Portrait, LandscapeLeft, LandscapeRight, Landscape }
    public Orientation screenOrientation;

    private PlaySpace playSpace;

	// Use this for initialization
	void Start () {
        playSpace = FindObjectOfType<PlaySpace>();

        SetOrientation();
	}

    void SetOrientation()
    {

        switch (screenOrientation)
        {
            case Orientation.Portrait:
                Screen.orientation = UnityEngine.ScreenOrientation.Portrait;
                //if(UIDebugControl.instance != null)
                   // UIDebugControl.instance.AddDebugText("Setting to portrait mode");
                if (Screen.width > Screen.height)
                {
                    //if (UIDebugControl.instance != null)
                       // UIDebugControl.instance.AddDebugText("Setting portrait resolution");
                    SetResolution();
                }
                break;
            case Orientation.LandscapeLeft:
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeLeft;
                if (Screen.width < Screen.height)
                {
                    SetResolution();   
                }
                break;
            case Orientation.LandscapeRight:
                Screen.orientation = UnityEngine.ScreenOrientation.LandscapeRight;
                if (Screen.width < Screen.height)
                {
                    SetResolution();
                }
                break;

            default:
                Debug.Log("Something wen wrong in switch");
                break;

        }

        if (playSpace != null)
            playSpace.SetupPlaySpace();
    }

    void SetResolution()
    {
        int width = Screen.width;
        int height = Screen.height;
        Screen.SetResolution(height, width, false);
        Debug.Log("Setting resolution");
    }
	

}

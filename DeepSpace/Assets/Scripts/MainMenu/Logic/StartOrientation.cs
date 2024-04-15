using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StartOrientation : MonoBehaviour
{
    [SerializeField] private bool _Is_Game;
    [SerializeField] private bool _Is_Menu;

    [SerializeField] private float _Time;

    private void Awake()
    {
        Orientation();
    }
    

    private void Orientation()
    {
        if (_Is_Game)
        {
            Screen.autorotateToLandscapeLeft = true;
            Screen.autorotateToLandscapeRight = true;
            
            Screen.autorotateToPortrait = false;
            Screen.autorotateToPortraitUpsideDown = false;

            Screen.orientation = ScreenOrientation.LandscapeRight;
        }

        if (_Is_Menu)
        {
            Screen.autorotateToLandscapeLeft = false;
            Screen.autorotateToLandscapeRight = false;
            
            Screen.autorotateToPortrait = true;
            Screen.autorotateToPortraitUpsideDown = true;

            Screen.orientation = ScreenOrientation.Portrait;
        }
    }
    
}

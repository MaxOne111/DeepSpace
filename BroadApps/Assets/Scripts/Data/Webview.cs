using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webview : MonoBehaviour
{
    private UniWebView _Uni_Web_View;
    
    [SerializeField] private GameObject _Webview_Object;
    [SerializeField] private GameObject _Back;
    
    [SerializeField] private string _URL;
    
    [SerializeField] private bool _Is_Open;

    private void Start()
    {
        CreateWebview();
        
        if (_Is_Open)
            Open();
    }
    
    private void SaveLastPage(UniWebView _uniWebView, int _status_Code, string _url)
    {
        _URL = _url;
        PlayerPrefs.SetString("url", _URL);
    }

    public void LoadURL(string _url)
    {
        _URL = _url;
        _Uni_Web_View.Load(_URL);
        PlayerPrefs.SetString("url", _URL);
    }

    public void LoadURL()
    {
        _URL = PlayerPrefs.GetString("url", "https://www.google.com/");
        _Uni_Web_View.Load(_URL);
    }

    private void CreateWebview()
    {
        _Uni_Web_View = _Webview_Object.AddComponent<UniWebView>();
        
        _Uni_Web_View.OnPageFinished += SaveLastPage;
        
        _Uni_Web_View.OnShouldClose += (view) => false;
        
        _Uni_Web_View.OnOrientationChanged += (view, orientation) =>
            _Uni_Web_View.Frame = new Rect(0, 0, Screen.width, Screen.height);
        
        _Uni_Web_View.Frame = new Rect(0, 0, Screen.width, Screen.height);
        
        UniWebView.SetJavaScriptEnabled(true);
        _Uni_Web_View.SetBackButtonEnabled(false);
        
    }

    public void Open() => StartCoroutine(OpenView());
    

    private IEnumerator OpenView()
    {
        float _delay = 1;
        
        _Back.SetActive(true);
        
        ChangeScreenOrientation();

        yield return new WaitForSeconds(_delay);
        
        _Uni_Web_View.Show();
        
        Debug.Log("Open webview");
    }

    private void ToolBar()
    {
        _Uni_Web_View.EmbeddedToolbar.Show();
        _Uni_Web_View.EmbeddedToolbar.SetDoneButtonText(" ");
        _Uni_Web_View.SetToolbarDoneButtonText(" ");   
    }
    
    private void ChangeScreenOrientation()
    {
        Screen.autorotateToPortrait = true;
        Screen.autorotateToPortraitUpsideDown = true;
        Screen.autorotateToLandscapeLeft = true;
        Screen.autorotateToLandscapeRight = true;

        Screen.orientation = ScreenOrientation.AutoRotation;
    }

    private void OnDestroy()
    {
        _Uni_Web_View.OnPageFinished -= SaveLastPage;
        
        Destroy(_Uni_Web_View);
        _Uni_Web_View = null;
    }
}

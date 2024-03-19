using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Firebase;
using Firebase.Extensions;
using Firebase.RemoteConfig;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FirebaseConfig : MonoBehaviour
{
    private Dictionary<string, string> _Config_Values = new Dictionary<string, string>();
    public Dictionary<string, string> ConfigValues => _Config_Values;

    public event Action _On_Loaded;

    [SerializeField] private bool _Withiout_Loading;
    [SerializeField] private TextMeshProUGUI _Internet_Connection;

    private void Awake()
    {
        if (_Withiout_Loading)
        {
            SceneManager.LoadScene(1);
            return;
        }

        StartCoroutine(StartFetch());
    }

    private void Start() => FirebaseRemoteConfig.DefaultInstance.OnConfigUpdateListener += ConfigUpdateListenerEventHandler;

    private IEnumerator StartFetch()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable)
            _Internet_Connection.gameObject.SetActive(true);

        while (Application.internetReachability == NetworkReachability.NotReachable)
            yield return null;

        _Internet_Connection.gameObject.SetActive(false);

        FetchDataAsync();
    }
    
    private void FetchDataAsync()
    {

        Debug.Log("Fetching data...");
        Task _fetch = FirebaseRemoteConfig.DefaultInstance.FetchAsync(TimeSpan.Zero);

        _fetch.ContinueWithOnMainThread(FetchComplete);
    }
    
    private void FetchComplete(Task fetchTask)
    {

        if (!fetchTask.IsCompleted)
        {
            Debug.LogError("Retrieval hasn't finished.");
            return;
        }

        var _remote_Config = FirebaseRemoteConfig.DefaultInstance;
        var info = _remote_Config.Info;
        if (info.LastFetchStatus != LastFetchStatus.Success)
        { 
            Debug.LogError(
                $"{nameof(FetchComplete)} was unsuccessful\n{nameof(info.LastFetchStatus)}: {info.LastFetchStatus}");
            return;
        }
        
        _remote_Config.ActivateAsync()
            .ContinueWithOnMainThread(
                task =>
                {
                    Debug.Log($"Remote data loaded and ready for use. Last fetch time {info.FetchTime}.");
                });
 
        foreach (var _value in _remote_Config.AllValues)
        {
            _Config_Values.Add(_value.Key, _value.Value.StringValue);
            Debug.Log($"Key: {_value.Key}/Value: {_value.Value.StringValue}");
        }
        
        _On_Loaded?.Invoke();
    }
    
    void ConfigUpdateListenerEventHandler(object sender, ConfigUpdateEventArgs args) 
    {
        if (args.Error != RemoteConfigError.None) {
            Debug.Log(String.Format("Error occurred while listening: {0}", args.Error));
            return;
        }

        var _remote_Config = FirebaseRemoteConfig.DefaultInstance;
        Debug.Log("Updated keys: " + string.Join(", ", args.UpdatedKeys));

        _remote_Config.ActivateAsync().ContinueWithOnMainThread(
            task => {
                Debug.Log("Keys have been updated");
            });
        
    }
    
    void OnDestroy() => FirebaseRemoteConfig.DefaultInstance.OnConfigUpdateListener -= ConfigUpdateListenerEventHandler;
}

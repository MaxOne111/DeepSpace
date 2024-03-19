using OneSignalSDK;
using UnityEngine;
using UnityEngine.UI;

public class OneSignalInitialize : MonoBehaviour
{
    [SerializeField] private string _App_ID;
    [SerializeField] private Button _Push_Button;
    
    private void Init() => OneSignal.Initialize(_App_ID);

    private void OnEnable() => _Push_Button.onClick.AddListener(PermissionRequestsPush);

    private void Start()
    {
        Init();
        PermissionRequestsInit();
    }

    private void PermissionRequestsInit()
    {
        OneSignal.InAppMessages.Paused = false;
        
        OneSignal.Notifications.RequestPermissionAsync(true);
    }

    private void PermissionRequestsPush()
    {
        OneSignal.User.PushSubscription.OptIn();
        Debug.Log("Show push notification");
    }

    private void OnDisable() => _Push_Button.onClick.RemoveListener(PermissionRequestsPush);
}

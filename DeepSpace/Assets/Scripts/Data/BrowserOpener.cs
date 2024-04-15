using System;
using UnityEngine;
using System.Collections;

public class BrowserOpener : MonoBehaviour
{
	[SerializeField] private InAppBrowserBridge _Bridge;
	
	[SerializeField] private string _URL;
	[SerializeField] private bool _Is_Open;

	[SerializeField] private GameObject _Back;
	[SerializeField] private GameObject _Audio;

	private InAppBrowser.EdgeInsets _Insets;
	
#if UNITY_IOS

	private void Margin() => _Insets = new InAppBrowser.EdgeInsets(50, 0, 0, 0);

#endif

	private void OnEnable() => _Bridge.onBrowserFinishedLoading.AddListener(LoadURL);

	private void Start()
	{
		if (_Is_Open)
			Open();
	}

	public void LoadURL(string _url)
	{
		_URL = _url;
		PlayerPrefs.SetString("url", _URL);
	}
	

	public void Open() => StartCoroutine(OpenView());

	private IEnumerator OpenView() {
		
		float _delay = 1;
		
		_Back.SetActive(true);
		_Audio.SetActive(false);
		
		ChangeScreenOrientation();
		
		yield return new WaitForSeconds(_delay);

		InAppBrowser.DisplayOptions _options = new InAppBrowser.DisplayOptions();
		
		//Margin();

		_options.insets = new InAppBrowser.EdgeInsets(50, 0, 0, 0);
		_options.hidesTopBar = false;
		_options.androidBackButtonCustomBehaviour = true;
		_options.hidesDefaultSpinner = true;

		_options.backButtonFontSize = "0";

		InAppBrowser.OpenURL(_URL, _options);
		
		Debug.Log("Open webview");
	}

	private void ChangeScreenOrientation()
	{
		Screen.autorotateToPortrait = true;
		Screen.autorotateToPortraitUpsideDown = true;
		Screen.autorotateToLandscapeLeft = true;
		Screen.autorotateToLandscapeRight = true;

		Screen.orientation = ScreenOrientation.AutoRotation;
	}
	
	public void OnClearCacheClicked() {
		Debug.Log("Clear Cache!");
		InAppBrowser.ClearCache();
	}

	private void OnDisable() => _Bridge.onBrowserFinishedLoading.RemoveListener(LoadURL);
}

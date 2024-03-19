using UnityEngine;

public class GeneralSettings : MonoBehaviour
{
    [SerializeField] private string _Game_Address;
    public string _Policy;

    
    public void OpenStore()
    {
        if (_Game_Address.Length <= 0)
            return;
        
        Application.OpenURL(_Game_Address);
    }
    
    public void OpenPolicy()
    {
        if (_Policy.Length <= 0)
            return;
        
        Application.OpenURL(_Policy);
    }
}
using UnityEngine;

public static class ScreenParams
{
    private static Vector3 _Screen;
    private static float _Offset_X = 2;
    private static float _Offset_Y = 4;

    public static Vector3 Border()
    {
        _Screen = new Vector3(Screen.width, Screen.height);

        _Screen = Camera.main.ScreenToWorldPoint(_Screen);

        return new Vector3(_Screen.x + _Offset_X, _Screen.y + _Offset_Y);
    }
    
    public static Vector3 ScreenLocal()
    {
        _Screen = new Vector3(Screen.width, Screen.height);

        _Screen = Camera.main.ScreenToWorldPoint(_Screen);

        return new Vector3(_Screen.x, _Screen.y);
    }
    
    public static Vector3 ScreenLocal(float _x_Ofsset, float _y_Offset)
    {
        _Screen = new Vector3(Screen.width, Screen.height);

        _Screen = Camera.main.ScreenToWorldPoint(_Screen);

        return new Vector3(_Screen.x - _x_Ofsset, _Screen.y - _y_Offset);
    }
}
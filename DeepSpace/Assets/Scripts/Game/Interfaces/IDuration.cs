using UnityEngine.UI;

public interface IDuration
{
     float Duration { get; }
     float CurrentTime { get; }

    void DisplayDuration(Image _bar);
}
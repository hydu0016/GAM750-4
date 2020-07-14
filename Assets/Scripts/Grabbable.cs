using Normal.Realtime;
using UnityEngine;

public class Grabbable : MonoBehaviour
{
    private RealtimeView _realtimeView;
    private RealtimeTransform _realtimeTransform;

    public bool Grabbed { get; set; } = false;

    private void Awake()
    {
        _realtimeView = GetComponent<RealtimeView>();
        _realtimeTransform = GetComponent<RealtimeTransform>();
    }

    private void Update()
    {
        if (Grabbed)
        {
            _realtimeTransform.RequestOwnership();
        }
    }
}

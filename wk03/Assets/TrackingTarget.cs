using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackingTarget : MonoBehaviour
{
    private ObserverBehaviour track;
    
    
    
    [SerializeField]
    private RotatePlanet[] scripts;

    // Start is called before the first frame update
    void Start()
    {
        scripts = GameObject.FindObjectsOfType<RotatePlanet>();
        
        track = this.GetComponent<ObserverBehaviour>();
        if (track)
        {
            track.OnTargetStatusChanged += OnObserverStatusChanged;
            OnObserverStatusChanged(track, track.TargetStatus);
        }
    }

    void OnObserverStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        if (targetStatus.Status == Status.TRACKED ) {
            
            EnableScript(true);
            
        }
        else
            EnableScript(false);
            
        
     
    }

    void EnableScript(bool enabled)
    {
        foreach (var script in scripts)
            script.enabled = enabled;
    }


}

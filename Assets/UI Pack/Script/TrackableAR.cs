using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TrackableAR : MonoBehaviour
{
    protected ObserverBehaviour mObserverBehaviour;
    private bool marker = false;

    protected virtual void Start()
    {
        mObserverBehaviour = GetComponent<ObserverBehaviour>();
        
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged += OnObserverStatusChanged;
            mObserverBehaviour.OnBehaviourDestroyed += OnObserverDestroyed;

            OnObserverStatusChanged(mObserverBehaviour, mObserverBehaviour.TargetStatus);
        }
    }

    protected virtual void OnDestroy()
    {
        if (mObserverBehaviour)
        {
            mObserverBehaviour.OnTargetStatusChanged -= OnObserverStatusChanged;
            mObserverBehaviour.OnBehaviourDestroyed -= OnObserverDestroyed;
        }
    }

    void OnObserverDestroyed(ObserverBehaviour observer)
    {
        mObserverBehaviour.OnTargetStatusChanged -= OnObserverStatusChanged;
        mObserverBehaviour.OnBehaviourDestroyed -= OnObserverDestroyed;
        mObserverBehaviour = null;
    }

    void OnObserverStatusChanged(ObserverBehaviour behaviour, TargetStatus targetStatus)
    {
        HandleTargetStatusChanged(targetStatus.Status);
    }

    protected virtual void HandleTargetStatusChanged(Status newStatus)
    {
        if (newStatus == Status.TRACKED || newStatus == Status.EXTENDED_TRACKED)
        {
            OnTrackingFound();
        }
        else
        {
            OnTrackingLost();
        }
    }

    protected virtual void OnTrackingFound()
    {
        marker = true;
        // Anda bisa menambahkan kode lain di sini jika diperlukan
    }

    protected virtual void OnTrackingLost()
    {
        marker = false;
        // Anda bisa menambahkan kode lain di sini jika diperlukan
    }

    public bool GetMarker()
    {
        return marker;
    }
}

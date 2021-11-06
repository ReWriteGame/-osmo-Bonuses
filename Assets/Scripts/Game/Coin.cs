using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    [SerializeField] private VoidEventChannelSO channel = default;

    public UnityEvent openEvent = default;

    private Bag bag;

    private void Start()
    {
        bag = gameObject.GetComponentInParent<Bag>();
    }

    private void OnEnable()
    {
        if (channel != null)
            channel.OnEventRaised += Activate;
    }

    private void OnDisable()
    {
        if (channel != null)
            channel.OnEventRaised -= Activate;
    }
  
    private void OnDestroy()
    {
        bag.openEvent.RemoveListener(Activate);
    }


    private void Activate()
    {
        if (bag.IsOpen) openEvent?.Invoke();
    }
}

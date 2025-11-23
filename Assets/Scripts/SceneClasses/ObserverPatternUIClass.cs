using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObserverPatternUIClass : MonoBehaviour
{
    public Button EventRaiserButton;
    public EventBusSO EventBus;

    private void OnEnable()
    {
        EventRaiserButton.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        EventBus.Raise(1, 2);
    }

    private void OnDisable()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LightRemoteController : MonoBehaviour
{
    [SerializeField] private  Light linkedLight;
    private XRGrabInteractable grabInteractable;

    public void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener((_) => StartPress());
    }

    public void StartPress()
    {
        linkedLight.enabled = !linkedLight.enabled;
    }
}

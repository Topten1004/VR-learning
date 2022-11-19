using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ToggleGrabTemporally : MonoBehaviour
{
    private XRRayInteractor _xrRayInteractor;
    private IXRSelectInteractable _xrGrabLayer;
    private int _notGrabbable = 6;
    private int _grabbable = 7;
    private bool _isGrabbable = true;

    // Start is called before the first frame update
    void Start()
    {
        _xrRayInteractor = GetComponent<XRRayInteractor>();
    }

    public void ChangeToNotGrabbable()
    {
        _xrGrabLayer = _xrRayInteractor.interactablesSelected[0];
        if (_xrGrabLayer.transform.gameObject.layer == _grabbable)
        {
            _xrGrabLayer.transform.gameObject.layer = _notGrabbable;
            _isGrabbable = true;
            var componentsInChildren = _xrGrabLayer.transform.gameObject.GetComponentsInChildren<Transform>(includeInactive : true);

            if (componentsInChildren.Length == 1)
            {
                return;
            }
            else
            {
                foreach (Transform child in componentsInChildren)
                {
                    if(child.gameObject.layer == _grabbable)
                        child.gameObject.layer = _notGrabbable;
                }
            }
        }
    }

    public void ChangeToGrabbable()
    {
        if (_xrGrabLayer.transform.gameObject.layer == _notGrabbable)
        {
            _xrGrabLayer.transform.gameObject.layer = _grabbable;
            _isGrabbable = true;
            var componentsInChildren = _xrGrabLayer.transform.gameObject.GetComponentsInChildren<Transform>(includeInactive: true);

            if (componentsInChildren.Length == 1)
            {
                return;
            }
            else
            {
                foreach (Transform child in componentsInChildren)
                {
                    if(child.gameObject.layer == _notGrabbable)
                        child.gameObject.layer = _grabbable;
                }
            }
        }
    }

    public void ToggleGrabbableLayer()
    {
        if(!_isGrabbable)
            ChangeToGrabbable();
        else
            ChangeToNotGrabbable();

    }
}

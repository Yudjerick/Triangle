using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    //Add or remove an InteractionEvent component to this gameobject.
    public bool useEvents;

    //message displayed to player when looking at an interactable.
    [SerializeField]
    public string promtMessage;
    
    public virtual string OnLook()
    {
        return promtMessage;
    }

    public void BaseInteract(){
        if (useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        Interact();
    }
    protected virtual void Interact(){
        //this is a template function to be overrideen by our subclasses
    }
}

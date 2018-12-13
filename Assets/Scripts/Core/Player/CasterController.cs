using ChainedRam.Core.Collection;
using ChainedRam.Core.Enums;
using ChainedRam.Core.Generation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

/// <summary>
///TODO: lots of shit
/// </summary>
public abstract class CasterController<A> : MonoBehaviour
{

    //TODO
    public abstract Caster<A> Caster { get; }
    
    public abstract Dictionary<KeyCode, A> KeyDownMap { get; protected set; }


    public HashSet<A> ActiveActions = new HashSet<A>(); 

    /// <summary>s
    /// protecteded
    /// </summary>
    protected void OnGUI()
    {
        Event current = Event.current; 
        switch (current.type)
        {
            case EventType.KeyDown:

                if (KeyDownMap.ContainsKey(current.keyCode))
                {
                    ActiveActions.Add(KeyDownMap[current.keyCode]); 
                }
                break;
            case EventType.KeyUp:
                if (KeyDownMap.ContainsKey(current.keyCode))
                {
                    ActiveActions.Remove(KeyDownMap[current.keyCode]);
                }
                break;
        }
    }

    private void RequestCasters(A action)
    {
        Caster.RequestCast(action); 
    }



    private void FixedUpdate()
    {
        foreach(var action in ActiveActions)
        {
            RequestCasters(action); 
        }
    }



}
public class CasterController : CasterController<string>
{
    public KeyCodeString[] KeyCodeString;
    private Caster<string> Target; 

    private void Start()
    {
        Target = this.gameObject.GetComponent<Caster<string>>();
        KeyDownMap = KeyCodeString.ToDictionary(p => (KeyCode) p.Key.Value, p => p.Value);
    }


    public override Caster<string> Caster => Target;


    public override Dictionary<KeyCode, string> KeyDownMap
    {
        get;
        protected set;
    }
}


[Serializable]
public class KeyCodeString : EnumString<KeyCode>
{
}


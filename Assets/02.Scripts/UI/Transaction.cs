using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transaction : MonoBehaviour
{
    protected void ProcessTransaction()
    {
        if(Authorization())
        {
            PerformTransaction();
        }
    }

    protected bool Authorization()
    {
        AuthorizationResult();
        return true;
    }

    protected void AuthorizationResult()
    {

    }

    protected abstract void PerformTransaction();

    protected void PritReciept()
    {

    }
}

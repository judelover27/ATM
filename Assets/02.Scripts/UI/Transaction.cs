using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class TransactionBtnInfo
{
    public Button button;
    public int value;

    public TransactionBtnInfo(Button button, int value)
    {
        this.button = button;
        this.value = value;
    }
}

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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lock_Unlock : MonoBehaviour
{
    // Set locked door status
    [SerializeField] private Key.KeyType keyType;

    public Key.KeyType GetKeyType()
    {
        return keyType;
    }

    public void OpenDoor()
    {
        gameObject.SetActive(false);
    }
}

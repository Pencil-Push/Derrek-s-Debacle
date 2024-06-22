using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyHolder : MonoBehaviour
{
    private List<Key.KeyType> keyList;
    public event EventHandler OnKeysChanged;
    [SerializeField] private AudioClip getAClip;
    [SerializeField] private AudioClip unlockAClip;

    private void Awake()
    {
        keyList = new List<Key.KeyType>();
    }

    public List<Key.KeyType> GetKeyList()
    {
        return keyList;
    }

    public void AddKey(Key.KeyType keyType)
    {
        //Debug.Log("Added Key: " + keyType);
        keyList.Add(keyType);
        SoundFXManager.instance.PlaySoundFXClip(getAClip, transform, 0.3f);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public void RemoveKey(Key.KeyType keyType)
    {
        //Debug.Log("Removed Key: " + keyType);
        keyList.Remove(keyType);
        OnKeysChanged?.Invoke(this, EventArgs.Empty);
    }

    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        Key key = col.GetComponent<Key>();
        if (key != null)
        {
            AddKey(key.GetKeyType());
            Destroy(key.gameObject);
        }

        Lock_Unlock lockUnlock = col.GetComponent<Lock_Unlock>();
        if(lockUnlock != null)
        {
            if(ContainsKey(lockUnlock.GetKeyType()))
            {
                //Currently holding Key to open door
                RemoveKey(lockUnlock.GetKeyType());
                lockUnlock.OpenDoor();
                SoundFXManager.instance.PlaySoundFXClip(unlockAClip, transform, 0.6f);
            }
        }
    }
}

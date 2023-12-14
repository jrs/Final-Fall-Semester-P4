using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinSound;
    private AudioSource _coinAudio;

    void Start()
    {
        _coinAudio = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            _coinAudio.PlayOneShot(coinSound, 1f);
            Debug.Log("Player collected the coin.");
            GameObject.Find("Canvas").GetComponent<UIManager>().UpdateCoinCount();
            
            Destroy(this.gameObject);
        }
    }
}

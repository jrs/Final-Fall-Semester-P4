using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;
    public AudioClip coinSound;
    public AudioClip zombieSound;

    private float _horizontalInput;
    private float _forwardInput;
    private Rigidbody _playerRb;
    private AudioSource _playerAudio;

    // Start is called before the first frame update
    void Start()
    {
        _playerRb = GetComponent<Rigidbody>();
        _playerAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontalInput = Input.GetAxis("Horizontal");
        _forwardInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(_horizontalInput, 0f, _forwardInput);
        _playerRb.AddForce(moveDirection * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            _playerAudio.PlayOneShot(coinSound, 1f);
            GameObject.Find("Spawn Manager").GetComponent<SpawnManager>().SpawnCollectibleObject();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Zombie"))
        {
            _playerAudio.PlayOneShot(zombieSound, 1f);
        }
    }
}

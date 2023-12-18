using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 10f;

    private Rigidbody _zombieRb;
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _zombieRb = GetComponent<Rigidbody>();
        _player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 lookDirection = (_player.transform.position - transform.position).normalized;
        _zombieRb.AddForce(lookDirection * speed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("The Zombie hit the player!");
            GameObject.Find("Game Manager").GetComponent<GameManager>().GameOver();
        }
    }
}

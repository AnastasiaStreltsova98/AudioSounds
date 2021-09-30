using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float angle;
    private AudioSource dogSound;

    void Start()
    {
        dogSound = GetComponent<AudioSource>();
    }

    void DogSoundPlay ()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) 
        {
            dogSound.Play();
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            dogSound.Stop();
        }
    }

    void Update()
    {
        Vector3 posOffset = gameObject.transform.position;
        Vector3 rotOffset = Vector3.zero;
        DogSoundPlay();

        if (Input.GetKey(KeyCode.W))
        {
            posOffset += Time.deltaTime * speed * gameObject.transform.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            posOffset -= Time.deltaTime * speed * gameObject.transform.forward;
        }

        if (Input.GetKey(KeyCode.A))
        {
            rotOffset = new Vector3(0f, -Time.deltaTime * angle, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rotOffset = new Vector3(0f, Time.deltaTime * angle, 0f);
        }

        gameObject.transform.position = posOffset;
        gameObject.transform.Rotate(rotOffset);

    }
}

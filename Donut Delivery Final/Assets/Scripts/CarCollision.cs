using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollision : MonoBehaviour
{
    private AudioSource source;
    private AudioSource engineSource;
    private AudioClip carHorn;
    private AudioClip idle;
    private AudioClip accelerating;
    private AudioClip engine;
    private AudioClip crash;
    private float coolDown = 0f;
    private GameObject player;
    private Rigidbody player_rb;

    // Start is called before the first frame update
    void Start()
    {
        GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
        player = GameObject.FindGameObjectWithTag("Player");
        player_rb = player.GetComponent<Rigidbody>();
        source = player.AddComponent<AudioSource>();
        engineSource = player.AddComponent<AudioSource>();
        carHorn = (AudioClip)Resources.Load("SoundFX/carHorn");
        accelerating = (AudioClip)Resources.Load("SoundFX/truck-accelerating");
        crash = (AudioClip)Resources.Load("SoundFX/crash");
        engine = (AudioClip)Resources.Load("SoundFX/truck-idle");
        engineSource.clip = engine;
        engineSource.loop = true;
        engineSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (coolDown > 0f)
            coolDown -= Time.deltaTime;
        else
            coolDown = 0f;

        engineSource.pitch = (player_rb.velocity.magnitude / 8) + 1f;

    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Collision detected");
        float vol = collision.relativeVelocity.magnitude / 40f;
        if (vol > 0.4f)
            vol = 0.4f;
        
        if (collision.collider.tag != "Donut")
        {
            source.PlayOneShot(crash, vol);
            Debug.Log("Vol: " + vol);
        }
        

        if (collision.collider.tag == "PedestrianCar" && coolDown <= 0f)
        {
            source.PlayOneShot(carHorn);
            coolDown += 2f;
            //Debug.Log(player_rb.velocity.magnitude);
        }
    }
}

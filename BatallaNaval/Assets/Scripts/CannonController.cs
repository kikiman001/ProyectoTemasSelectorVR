using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OVR;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 1;
    public float BlastPower = 5;

    public GameObject Cannonball;
    public Transform ShotPoint;

    public GameObject Explosion;
    private AudioSource cannonAudio;
    private void Start()
    {
        // Obtén una referencia al componente AudioSource
        cannonAudio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        // Obtén la entrada del joystick derecho
        var joystickAxis = OVRInput.Get(OVRInput.RawAxis2D.RThumbstick, OVRInput.Controller.RTouch);

        // Actualiza la rotación basada en la entrada del joystick derecho
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles +
            new Vector3(0, joystickAxis.x * rotationSpeed, joystickAxis.y * rotationSpeed));

        // Usa el gatillo derecho para disparar el cañón
        float leftTrigger = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (Input.GetKeyDown(KeyCode.Space) || leftTrigger>0.8f)
        {
            cannonAudio.Play();
            FireCannon();
        }
    }

    private void FireCannon()
    {
        GameObject createdCannonball = Instantiate(Cannonball, ShotPoint.position, ShotPoint.rotation);
        createdCannonball.GetComponent<Rigidbody>().velocity = ShotPoint.transform.up * BlastPower;

        // Añade una explosión para mayor efecto
        Destroy(Instantiate(Explosion, ShotPoint.position, ShotPoint.rotation), 2);

        // Agita la pantalla para mayor efecto
        // Screenshake.ShakeAmount = 5;
    }
}

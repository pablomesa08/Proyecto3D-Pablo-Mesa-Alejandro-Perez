using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flechas : MonoBehaviour
{
    public Rigidbody rb;
    public float speed = 5.0f;
    private float forceStrength = 10.0f;

    //Los límites de la escena
    private float xMin = -9.0f;
    private float xMax = 10.0f;
    private float zMin = -2.0f;
    private float zMax = 25.0f;


    //Almacenar posición inicial
    private Vector3 initialPosition;

    //Almacenar rotacion inicial
    private Quaternion initialRotation;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    private void Update()
    {
        // Obtener la entrada del teclado
        float moveHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float moveVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        // Actualizar la posición del objeto
        float newX = Mathf.Clamp(transform.position.x + moveHorizontal, xMin, xMax);
        float newZ = Mathf.Clamp(transform.position.z + moveVertical, zMin, zMax);

        // Si el objeto alcanza el límite zMin, detiene su movimiento en el eje Z
        if (newZ <= zMin)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
        }

        transform.position = new Vector3(newX, transform.position.y, newZ);

        // Rotación del objeto
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up);
        }


        // Salto del objeto
        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(Vector3.up * forceStrength, ForceMode.Impulse);
        }
        
    }

    // Restablecer la posición del objeto cuando colisiona con otro 
    void OnCollisionEnter(Collision collision)
    {
    // Verifica si objeto está colisionando con el objeto de nombre "MiObjeto"
    if (collision.gameObject.name == "Poste1" || collision.gameObject.name == "Poste2" || collision.gameObject.name == "Horizontal" || collision.gameObject.name == "Poste3" || collision.gameObject.name == "Poste4" || collision.gameObject.name == "Horizontal2")
    {
        // Restablece la posición del objeto a su posición inicial
        transform.position = initialPosition;
        transform.rotation = initialRotation;
    }
    }
}
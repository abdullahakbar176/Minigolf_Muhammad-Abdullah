using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BallController : MonoBehaviour
{
    private LineRenderer line;
    private Rigidbody ball;
    private float angle;
    public float max;
    public float moveangle;
    public float linelength;
    public Slider PowerSlider;
    private float powerUpTime;
    private float power;
    public TextMeshProUGUI count;
    private int score;
    private float holeTime;
    public float minholetime;
    private Vector3 lastposition;
    public Transform startPosition;
    public Transform startTransform;
    public AudioClip puttSound;
    public AudioClip holeSound;
    private AudioSource audiosource;


    void Awake()
    {
        audiosource = GetComponent<AudioSource>();
        ball = GetComponent<Rigidbody>();
        ball.maxAngularVelocity = 1000;
        line = GetComponent<LineRenderer>();
        startTransform.GetComponent<MeshRenderer>().enabled = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.velocity.magnitude<0.01f)
        {

            if (Input.GetKey(KeyCode.A))
            {
                angle -= moveangle * Time.deltaTime;
            }

            if (Input.GetKey(KeyCode.D))
            {
                angle += moveangle * Time.deltaTime;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {

                shoot();
            }

            if (Input.GetKey(KeyCode.Space))
            {

                PowerUp();
            }

            LinePosition();
        }
        else
        {
            line.enabled = false;
        }
       
    }
    private void LinePosition()
    {
        if(holeTime== 0)
        {
            line.enabled = true;
        }
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + Quaternion.Euler(0, angle, 0) * Vector3.forward * linelength);

    }
    private void shoot()
    {
        audiosource.PlayOneShot(puttSound);
        lastposition = transform.position;
        ball.AddForce(Quaternion.Euler(0, angle, 0) * Vector3.forward * max * power, ForceMode.Impulse);
        power = 0;
        PowerSlider.value = 0;
        powerUpTime = 0;
        score++;
        count.text = score.ToString();
    }
    private void PowerUp()
    {
        powerUpTime += Time.deltaTime;
        power = Mathf.PingPong(powerUpTime, 1);
        PowerSlider.value = power;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Hole")
        {
            checkhole();
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hole")
        {
            audiosource.PlayOneShot(holeSound);
        }
    }
    private void checkhole()
    {
        holeTime += Time.deltaTime;
        if(holeTime >= minholetime)
        {
            holeTime = 0;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hole")
        {
            lefthole();
        }
    }
    private void lefthole()
    {
        holeTime= 0;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "outerlayer")
        {
            transform.position = lastposition;
            ball.velocity = Vector3.zero;
            ball.angularVelocity = Vector3.zero;
        }
    }

    public void setupball(Color color)
    {
        transform.position = startPosition.position;
        angle = startTransform.rotation.eulerAngles.y;
        ball.velocity = Vector3.zero;
        ball.angularVelocity = Vector3.zero;
        GetComponent<MeshRenderer>().material.SetColor("Color", color);
        line.material.SetColor("Color", color);
        line.enabled = true;
        score = 0;
        
    }
}

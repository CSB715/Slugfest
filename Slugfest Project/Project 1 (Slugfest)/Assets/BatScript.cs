using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatScript : MonoBehaviour
{
    Rigidbody2D _rbody;
    Transform _transform;
    int timeHeld;
    bool swinging;
    bool charging;
    float changeX;
    float changeY;
    float changeZ;
    float x;
    float y;
    public float z;
    public float pow;
    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _transform = _rbody.transform;
        timeHeld = 0;
        swinging = false;
        charging = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space) && charging)
        {
            swinging = true;
            if (timeHeld < 50)
            {
                pow = 10;
            }
            else if (timeHeld < 250)
            {
                pow = (float) (1.5 * Mathf.Pow(timeHeld - 50, 1.5f) - 0.883 * Mathf.Pow(timeHeld - 50, 1.6f));
            }
            else
            {
                pow = 10;
            }
            Debug.Log(timeHeld);
            Debug.Log(pow);

            x = _transform.eulerAngles.x;
            y = _transform.eulerAngles.y;
            z = _transform.eulerAngles.z;
            changeX = (180 - x) / Mathf.Floor(300.0f/pow);
            changeY = -y / Mathf.Floor(300.0f / pow);
            changeZ = (270-z)/ Mathf.Floor(900.0f / pow);

            timeHeld = 0;
        }
        else if (Input.GetKey(KeyCode.Space) && !swinging)
        {
            charging = true;
            if (timeHeld < 100)
            {
                _transform.Rotate(0.1f, 0, -0.4f);
            }
            timeHeld++;
        }
        else if(swinging)
        {

            if (timeHeld != Mathf.Floor(300.0f / pow))
            {
                x += changeX;
                y += changeY;
                z += changeZ;
                _transform.eulerAngles = new Vector3(x, y, z);
                timeHeld++;
            }
            else
            {
                z += changeZ;
                _transform.eulerAngles = new Vector3(x, y, z);
            }
            
        }
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        Debug.Log("Collision");
        if (collision.gameObject.CompareTag("ball"))
        {
            
            changeZ *= -0.1f;
        }
    }
}

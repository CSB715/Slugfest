using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D _rbody;
    [SerializeField] BatScript bat;
    // Start is called before the first frame update
    void Start()
    {
        _rbody = GetComponent<Rigidbody2D>();
        _rbody.velocity = new Vector2(-1.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(new Vector2(Mathf.Cos(-225.0f + bat.z), Mathf.Sin(-45.0f + bat.z)) * bat.pow * 1.5f);
        _rbody.velocity = new Vector2(Mathf.Cos(-225.0f+bat.z), Mathf.Sin(-45.0f+bat.z)) * bat.pow/2.5f;
    }
}

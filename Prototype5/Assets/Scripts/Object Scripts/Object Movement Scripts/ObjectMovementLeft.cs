using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementLeft : MonoBehaviour
{

    public Vector2 initialSpeed;
    private Rigidbody2D obj;
    private Vector2 screenBounds;
    float t;
    public Vector2 acceleration;

    // Start is called before the first frame update
    void Start()
    {

        obj = this.GetComponent<Rigidbody2D>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        t += Time.deltaTime;

        obj.velocity = initialSpeed + acceleration * t;

        if (obj.velocity.x > 0)
        {
            obj.velocity = Vector2.zero;
        }


        if (transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}

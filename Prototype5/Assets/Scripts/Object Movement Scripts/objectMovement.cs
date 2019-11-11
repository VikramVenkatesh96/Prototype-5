using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour
{

    public float initialSpeed = 5.0f;
    private Rigidbody2D obj;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        obj = this.GetComponent<Rigidbody2D>();
        obj.velocity = new Vector2(-initialSpeed, 0);

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < screenBounds.x * 2)
        {
            Destroy(this.transform.parent.gameObject);
        }
    }
}

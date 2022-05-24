using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;
    public Vector2 speed = new Vector2(50,50);
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y;
    }

    // Update is called once per frame
    void Update()
    {
        float inputY = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0, speed.y * inputY, 0);

        movement *= Time.deltaTime;

        transform.Translate(movement);
    }
    void LateUpdate() {
        Vector3 viewPos = transform.position;
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y * -1 + objectHeight, screenBounds.y - objectHeight);
        transform.position = viewPos;
    }
}

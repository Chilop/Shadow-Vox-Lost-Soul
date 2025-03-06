using UnityEngine;

public class MovementBasicScript : MonoBehaviour
{
    Rigidbody body;
    private float horizontalAxis, verticalAxis;
    public float speed,jumpforce;
    public Vector3 movement;
    private void Awake()
    {
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        horizontalAxis = Input.GetAxis("Horizontal");
        verticalAxis = Input.GetAxis("Vertical");
        movement = new Vector3 (horizontalAxis*speed,0, verticalAxis*speed);
        transform.position += movement * Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.Space))
            body.AddForce(new Vector3(0,jumpforce,0));
    }
}

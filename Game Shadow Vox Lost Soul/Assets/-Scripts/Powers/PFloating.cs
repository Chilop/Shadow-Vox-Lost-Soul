using UnityEngine;

public class PFloating : MonoBehaviour
{
    public bool coliding = false, onceChecker = false,rigi = false,onceHeight = true;
    public Rigidbody OwnRigidbody;
    public float CurrentHeight;
    

    public float FloatTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        try
        {
            OwnRigidbody = GetComponent<Rigidbody>();
            rigi = true;
        }
        catch
        {
            rigi = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump") && !coliding&& FloatTimer < 2) { 
            FloatTimer+= 1*Time.deltaTime;
            Floating();
            onceChecker = true;
        }
        else
        {
            onceChecker = true;
            if (onceChecker)
            {
                StopFloating();
                onceChecker = false;
            }
        }
        //transform.position += new Vector3(10*Time.deltaTime,0,0);
    }

    void Floating()
    {
        if (rigi)
        {
            OwnRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
        }
        else
        {
            if (onceHeight)
            {
                onceHeight = false;
                CurrentHeight = transform.position.y;
            }
            transform.position = new Vector3(transform.position.x, CurrentHeight, transform.position.z);
        }
    }

    void StopFloating()
    {
        if (rigi)
        {
            OwnRigidbody.constraints = RigidbodyConstraints.None;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        coliding = true;
    }

    void OnCollisionExit(Collision collision)
    {
        coliding = false;
        FloatTimer = 0;
    }
}

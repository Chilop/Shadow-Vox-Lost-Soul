using UnityEngine;

public class CollitionsOverlapingScript : MonoBehaviour
{
    public ExpliotionRadio _expliotionRadio;
    public float _maxDistance;
    public LayerMask _mask = -1;
    public float _radio;
    public Vector3 _position = Vector3.zero;

    public GameObject _gameObjectExplotion;
    public GameObject _myOwnGameObject;
    public Collider _otherGameObjectCollider;


    
    void Start()
    {
     _otherGameObjectCollider = _myOwnGameObject.GetComponent<Collider>();   
    }

    private void FixedUpdate()
    {
        Vector3 direction = transform.TransformDirection(Vector3.forward);

        if(Physics.Raycast(transform.position, direction, _maxDistance, _mask.value,QueryTriggerInteraction.Ignore))
        {
            print("there is something infront of me " + GameObject.Find(gameObject.name));
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            _expliotionRadio.ExplosionDamage(_position,_radio);
            //_otherGameObjectCollider.isTrigger = !_otherGameObjectCollider.isTrigger;
        }
    }
}

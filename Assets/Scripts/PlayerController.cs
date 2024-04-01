using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input Hor/Ver ")]
    [SerializeField] private float inputHorizontal;
    [SerializeField] private float inputVertical;
    [Header("Speed")]
    [SerializeField] private float speed=15;
    [Header("Positions")]
    [SerializeField] private float xRange=12.0f;
    [SerializeField] private float zRangeTop;
    [SerializeField] private float zRangeBottom;
    [Header("Pizza")]
    [SerializeField] private GameObject prefabPizza;
    [SerializeField] private Transform pizzaPosition;
    [SerializeField]private float delayFeeding;
    private bool readyToFeed=true;
    [Header("Chance")]
    private int chance=3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        MovingPlayer();
        RangeToPlayer();
        Feeding();
        Die();

    }
    void MovingPlayer()
    {
        transform.Translate(Vector3.right * Time.deltaTime * inputHorizontal* speed);
        transform.Translate(Vector3.forward*Time.deltaTime * inputVertical* speed);
    }
    void RangeToPlayer()
    {
        if (transform.position.x < -xRange)
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        else if(transform.position.x > xRange)
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        else if(transform.position.z>zRangeTop)
            transform.position=new Vector3(transform.position.x, transform.position.y, zRangeTop);
        else if(transform.position.z<zRangeBottom)
            transform.position=new Vector3(transform.position.x, transform.position.y, zRangeBottom);
    }
    void Feeding()
    {
        if(Input.GetKeyDown(KeyCode.F)&&readyToFeed)
        {
            //lunch the animals
            Instantiate(prefabPizza,pizzaPosition.position,prefabPizza.transform.rotation);
            readyToFeed = false;
            StartCoroutine(DelayFeeding()); 
        }
    }
    void Die()
    {
        if (chance == 0)
        { 
            Debug.Log("Game Over!"); 
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Animal"))
        {
            chance--;
            Debug.Log($"Chance : {chance}");
        }
    }
    IEnumerator DelayFeeding()
    {
        yield return new WaitForSeconds(delayFeeding);
        readyToFeed = true;
    }
}

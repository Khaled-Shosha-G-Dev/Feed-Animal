using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjectDone : MonoBehaviour
{
    [SerializeField] private float zRangeTop;
    [SerializeField] private float zRangeLow;
    [SerializeField] private float xRange;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if the object desappeared from the top screen destroy it
        if (transform.position.z > zRangeTop)
            Destroy(gameObject);

        //if the oject desappeared from the down screen destroy it and the player is lossing
        else if (transform.position.z < zRangeLow)
            Destroy(gameObject);

        else if (transform.position.x > xRange)
            Destroy(gameObject);

        else if (transform.position.x < -xRange)
            Destroy(gameObject);
    }
}

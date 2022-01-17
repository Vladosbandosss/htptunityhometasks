using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Vector3 startPos, endPos;

    [SerializeField] private float timeToReach = 5f;

    private float timer;
    
    
   private void Start()
    {
        transform.position = startPos;
    }

    
    void Update()
    {
        timer += Time.deltaTime / timeToReach;
        transform.position = Vector3.Lerp(startPos, endPos, timer);

        if (transform.position == endPos)
        {
            SwitchPositions();
        }
    }

    void SwitchPositions()
    {
        var temp = startPos;
        startPos = endPos;
        endPos = temp;
        timer = 0;
    }
}

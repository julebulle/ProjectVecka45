using UnityEngine;
using System.Collections.Generic;
public class Note : MonoBehaviour
{
    [SerializeField]List<DirectionEnum> directions;
    [SerializeField]DirectionEnum direction;
    Vector3 directionValue;

    public Transform targetPosition;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*for(int i = 0; i < directions.Count; i++)
        {
            plates[i] = GameObject.Find(directions[i].ToString()).transform;
        }*/
        direction = directions[Random.Range(0,directions.Count)];

        targetPosition = GameObject.Find(direction.ToString()).transform;

        if(direction == DirectionEnum.Up)
        {
            directionValue = Vector3.up;
        }
        else if (direction == DirectionEnum.Down)
        {
            directionValue = Vector3.down;
        }
        else if(direction == DirectionEnum.Left)
        {
            directionValue = Vector3.left;
        }
        else
        {
            directionValue = Vector3.right;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += directionValue * Time.deltaTime;
    }
}

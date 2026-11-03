using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
public class Note : MonoBehaviour
{
    [SerializeField]List<DirectionEnum> directions;
    [SerializeField]DirectionEnum direction;
    Vector3 directionValue;
    public Transform targetPosition;
    public float speed;
    public List<Sprite> sprites;
    public int directionIndex;
    public NoteSpawner spawner;
    [SerializeField] float accuracy;
    ScoreManager scoreManager;

    [InspectorLabel("Accuracy Margins")]
    public float niceMargin;
    public float coolMargin;
    public float PerfectMargin;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        scoreManager = FindAnyObjectByType<ScoreManager>();

        spawner = FindAnyObjectByType<NoteSpawner>();

        direction = directions[directionIndex];

        targetPosition = GameObject.Find(direction.ToString()).transform;

        gameObject.GetComponent<SpriteRenderer>().sprite = sprites[directionIndex];

        //stets the direction the note should move
        #region
        if (direction == DirectionEnum.Up)
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
        #endregion
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += directionValue * speed * Time.deltaTime;

        accuracy = (transform.position.x - targetPosition.position.x) + (transform.position.y - targetPosition.position.y);

        if (transform.position.x < -10.16 || transform.position.x > 10.16)
        {
            CheckTiming();
          Destroy(gameObject);
        }
            

        else if (transform.position.y > 6.3 || transform.position.y < -6.3)
        {
           CheckTiming();
           Destroy(gameObject);
        }
    }

    public AccuracyEnum GetAccuracyEnum()
    {
        if(accuracy > -niceMargin && accuracy < niceMargin)
        {
            if(accuracy > -coolMargin && accuracy < coolMargin)
            {
                if(accuracy > -PerfectMargin && accuracy < PerfectMargin)
                {
                    return AccuracyEnum.Perfect;
                }
                else
                {
                    return AccuracyEnum.Cool;
                }
            }
            else
            {
                return AccuracyEnum.Nice;
            }
        }
        else
        {
            return AccuracyEnum.Miss;
        }
    }

    public void CheckTiming()
    {
        Debug.Log(GetAccuracyEnum().ToString());

        spawner.RemoveNote(direction);


        scoreManager.AddToScore(GetAccuracyEnum());

        directionValue = Vector3.down;


    }
}

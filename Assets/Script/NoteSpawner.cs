using UnityEngine;
using UnityEngine.Timeline;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.InputSystem;
using Unity.VisualScripting;
public class NoteSpawner : MonoBehaviour
{
    public TimelineAsset timeline;
    public SpriteRenderer girlInTheMiddle;
    public GameObject notePrefab;
    [Header("Girl in the middle poses")]
  

    public Sprite upPose;
    public Sprite downPose;
    public Sprite leftPose;
    public Sprite rightPose;

    [Header("Lists")]
    public List<Note> upList;
    public List<Note> downList;
    public List<Note> leftList;
    public List<Note> rightList;

    [Header("Particles")]
    [SerializeField] public ParticleSystem upEmitter;
    [SerializeField] public ParticleSystem leftEmitter;
    [SerializeField] public ParticleSystem rightEmitter;
    [SerializeField] public ParticleSystem downEmitter;


    [Header("Inputs")]
    public InputActionReference upButton;
    public InputActionReference downButton;
    public InputActionReference leftButton;
    public InputActionReference rightButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }
    public  bool CheckInputDirection(DirectionEnum Direction)
    {
        if(Direction == DirectionEnum.Up)
        {
            if (upButton.action.WasPressedThisFrame())
            {
                return true;
            }
        }
        if (Direction == DirectionEnum.Down)
        {
            if (downButton.action.WasPressedThisFrame())
            {
                return true;
            }
        }
        if (Direction == DirectionEnum.Left)
        {
            if (leftButton.action.WasPressedThisFrame())
            {
                return true;
            }
        }
        if (Direction == DirectionEnum.Right)
        {
            if (rightButton.action.WasPressedThisFrame())
            {
                return true;
            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {
        
        //When you 
        #region
        if (CheckInputDirection(DirectionEnum.Up))
        {
            if (upList.Count > 0)
            {
                upList[0].CheckTiming();
            }
        }
        else if (CheckInputDirection(DirectionEnum.Down))
        {
            if(downList.Count > 0)
            {
                downList[0].CheckTiming();
            }
        }
        else if (CheckInputDirection(DirectionEnum.Left))
        {
            if(leftList.Count > 0)
            {
                leftList[0].CheckTiming();
            }
        }
        else if (CheckInputDirection(DirectionEnum.Right))
        {
            if(rightList.Count > 0)
            {
                rightList[0].CheckTiming();
            }
        }
        #endregion
    }

    public void SpawnNote()
    {
        GameObject spawnedNote = Instantiate(notePrefab, Vector3.zero, Quaternion.identity);

        int index = Random.Range(0, 4);
        spawnedNote.GetComponent<Note>().directionIndex = index;

        //Putting the note in the correct list
        #region
        if (index == 0)
        {
            upList.Add(spawnedNote.GetComponent<Note>());
            girlInTheMiddle.sprite = upPose;
        }
        else if (index == 1)
        {
            downList.Add(spawnedNote.GetComponent<Note>());
            girlInTheMiddle.sprite = downPose;
        }
        else if (index == 2)
        {
            leftList.Add(spawnedNote.GetComponent<Note>());
            girlInTheMiddle.sprite =leftPose;
        }
        else if (index == 3)
        {
            rightList.Add(spawnedNote.GetComponent<Note>());
            girlInTheMiddle.sprite = rightPose;
        }
        #endregion
    }



    public void RemoveNote(DirectionEnum direction)
    {
        if(direction == DirectionEnum.Up)
        {
            upEmitter.Play();
            upList.RemoveAt(0);
        }
        else if(direction == DirectionEnum.Down)
        {
            downEmitter.Play();
            downList.RemoveAt(0);
        }
        else if (direction == DirectionEnum.Left)
        {
            leftEmitter.Play();
            leftList.RemoveAt(0);
        }
        else if (direction == DirectionEnum.Right)
        {
            rightEmitter.Play();
            rightList.RemoveAt(0);
        }
    }

}

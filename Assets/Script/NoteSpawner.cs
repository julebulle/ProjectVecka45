using UnityEngine;
using UnityEngine.Timeline;
using System.Collections.Generic;
using JetBrains.Annotations;

public class NoteSpawner : MonoBehaviour
{
    public TimelineAsset timeline;
    public GameObject notePrefab;
    public List<Note> upList;
    public List<Note> downList;
    public List<Note> leftList;
    public List<Note> rightList;

    public KeyCode upButton;
    public KeyCode downButton;
    public KeyCode leftButton;
    public KeyCode rightButton;
    public KeyCode upButton0;
    public KeyCode downButton0;
    public KeyCode leftButton0;
    public KeyCode rightButton0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SpawnNote();
        
    }
    public  bool CheckInputDirection(DirectionEnum aDirection)
    {
        if(aDirection == DirectionEnum.Up)
        {
            if (Input.GetKeyDown(upButton) || Input.GetKeyDown(upButton0) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                return true;
            }
        }
        if (aDirection == DirectionEnum.Down)
        {
            if (Input.GetKeyDown(downButton) || Input.GetKeyDown(downButton0) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                return true;
            }
        }
        if (aDirection == DirectionEnum.Left)
        {
            if (Input.GetKeyDown(leftButton) || Input.GetKeyDown(leftButton0) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                return true;
            }
        }
        if (aDirection == DirectionEnum.Right)
        {
            if (Input.GetKeyDown(rightButton) || Input.GetKeyDown(rightButton0) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                return true;
            }
        }
        return false;
    }
    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNote();
        }

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
        }
        else if (index == 1)
        {
            downList.Add(spawnedNote.GetComponent<Note>());
        }
        else if (index == 2)
        {
            leftList.Add(spawnedNote.GetComponent<Note>());
        }
        else if (index == 3)
        {
            rightList.Add(spawnedNote.GetComponent<Note>());
        }
        #endregion
    }



    public void RemoveNote(DirectionEnum direction)
    {
        if(direction == DirectionEnum.Up)
        {
            upList.RemoveAt(0);
        }
        else if(direction == DirectionEnum.Down)
        {
            downList.RemoveAt(0);
        }
        else if (direction == DirectionEnum.Left)
        {
            leftList.RemoveAt(0);
        }
        else if (direction == DirectionEnum.Right)
        {
            rightList.RemoveAt(0);
        }
    }

}

using UnityEngine;
using UnityEngine.Timeline;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine.InputSystem;

public class NoteSpawner : MonoBehaviour
{
    public TimelineAsset timeline;
    public GameObject notePrefab;
    public List<Note> upList;
    public List<Note> downList;
    public List<Note> leftList;
    public List<Note> rightList;

    public InputActionReference upButton;
    public InputActionReference downButton;
    public InputActionReference leftButton;
    public InputActionReference rightButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        SpawnNote();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnNote();
        }

        //When you press a button it does the thing

        #region
        
        if (upButton.action.WasPressedThisFrame())
        {
            if (upList.Count > 0)
            {
                upList[0].CheckTiming();
            }
        }
        else if (downButton.action.WasPressedThisFrame())
        {
            if(downList.Count > 0)
            {
                downList[0].CheckTiming();
            }
        }
        else if (leftButton.action.WasPressedThisFrame())
        {
            if(leftList.Count > 0)
            {
                leftList[0].CheckTiming();
            }
        }
        else if (rightButton.action.WasPressedThisFrame())
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

using System.Collections;
using UnityEngine;

public class LetterZ : MonoBehaviour
{
    private int dirX;
    private int dirY;
    private int dirDeterm;
    public SpawningArrow spawningArrow;
    [SerializeField] int speed = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawningArrow = FindAnyObjectByType<SpawningArrow>();
        dirDeterm = Random.Range(0, 2);
        if (dirDeterm == 0)
        {
            dirX = Random.Range(-1, 2);
            dirY = 0;
        }
        else if (dirDeterm == 1)
        {
            dirX = 0;
            dirY = Random.Range(-1, 2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dirX == 0 && dirY == 0)
        {
            dirY = 1;
        }
        transform.position += new Vector3(dirX, dirY, 0) * speed * Time.deltaTime;

        if (transform.position.x < -15 || transform.position.x > 15 || transform.position.y < -10 || transform.position.y > 10)
        {
            Destroy(gameObject);
        }
    }
}

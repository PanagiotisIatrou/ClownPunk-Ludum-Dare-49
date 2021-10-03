using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shark : MonoBehaviour
{
    public Direction startDir;
    private Direction currentDir;
    private SpriteRenderer sr;
    private float speed = 1f;
    private Vector2 boundsX = new Vector2(-4.3f, 4.3f);
    private Vector2 boundsY = new Vector2(-4.45f, -3.72f);

	private void Start()
	{
        currentDir = startDir;
        sr = GetComponent<SpriteRenderer>();
    }

	private void Update()
    {
        if (currentDir == Direction.UP)
		{
            transform.position += Vector3.up * speed * Time.deltaTime;
            if (transform.position.y >= boundsY.y)
			{
                currentDir = Direction.LEFT;
                transform.position = new Vector3(boundsX.y, boundsY.y, -2f);
                sr.sprite = GameManager.Instance.SharkRightSprite;
                sr.flipX = true;
            }
        }
        else if (currentDir == Direction.LEFT)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= boundsX.x)
			{
                currentDir = Direction.DOWN;
                transform.position = new Vector3(boundsX.x, boundsY.y, -2f);
                sr.sprite = GameManager.Instance.SharkUpSprite;
                sr.flipX = false;
            }
        }
        else if (currentDir == Direction.DOWN)
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            if (transform.position.y <= boundsY.x)
			{
                currentDir = Direction.RIGHT;
                transform.position = new Vector3(boundsX.x, boundsY.x, -2f);
                sr.sprite = GameManager.Instance.SharkRightSprite;
                sr.flipX = false;
            }
        }
        else if (currentDir == Direction.RIGHT)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= boundsX.y)
			{
                currentDir = Direction.UP;
                transform.position = new Vector3(boundsX.y, boundsY.x, -2f);
                sr.sprite = GameManager.Instance.SharkUpSprite;
                sr.flipX = false;
            }
        }
    }
}

public enum Direction { NONE, UP, DOWN, LEFT, RIGHT };

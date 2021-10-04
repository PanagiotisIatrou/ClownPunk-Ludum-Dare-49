using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class BagMovement : MonoBehaviour
{
    public TextMeshProUGUI LeftBagText;
    public TextMeshProUGUI RightBagText;
    public Transform clownWheel;
    public Transform Bag1;
    public Transform Bag2;
    public Rigidbody2D wheelCenterRB;
    private float speed = 5f;
    private bool isInvertOn = false;
    private float invertTimer = 0f;
    private float invertTimerMax = 2f;

	public void Restart()
    {
        speed = 5f;
    }

	private void Update()
    {
        if (!GameManager.Instance.getIsPlaying())
            return;

        if (isInvertOn)
		{
            invertTimer += Time.deltaTime;
            if (invertTimer >= invertTimerMax)
                isInvertOn = false;
        }

        Vector2 offset = Vector2.zero;
        if (!isInvertOn)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                offset += Vector2.left;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                offset += Vector2.right;
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                offset += Vector2.right;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                offset += Vector2.left;
            }
        }

        // Turn wheel
        if (offset.x > 0)
            clownWheel.transform.Rotate(new Vector3(0f, 0f, -Time.deltaTime * 360f));
        else if (offset.x < 0)
            clownWheel.transform.Rotate(new Vector3(0f, 0f, Time.deltaTime * 360f));

        //

        Vector3 vector = (Vector3)offset * speed * Time.deltaTime;
        if (vector.x + transform.position.x > -3f && vector.x + transform.position.x < 3f)
        {
            //transform.position += vector;
            LeftBagText.transform.position = Bag1.position + new Vector3(0f, 0.1f);
            LeftBagText.transform.position += Vector3.back;
            RightBagText.transform.position = Bag2.position + new Vector3(0f, 0.1f);
            RightBagText.transform.position += Vector3.back;
        }
    }

	private void FixedUpdate()
	{
		if (Input.GetKey(KeyCode.LeftArrow))
		{
            wheelCenterRB.AddForceAtPosition(Vector2.left * 250f * Time.fixedDeltaTime, wheelCenterRB.position);
            wheelCenterRB.AddForceAtPosition(Vector2.left * 250f * Time.fixedDeltaTime, wheelCenterRB.position + Vector2.up);
            wheelCenterRB.AddTorque(150f * Time.fixedDeltaTime);

        }
        else if (Input.GetKey(KeyCode.RightArrow))
		{
            wheelCenterRB.AddForceAtPosition(Vector2.right * 250f * Time.fixedDeltaTime, wheelCenterRB.position);
            wheelCenterRB.AddForceAtPosition(Vector2.right * 250f * Time.fixedDeltaTime, wheelCenterRB.position + Vector2.up);
            wheelCenterRB.AddTorque(-150f * Time.fixedDeltaTime);
        }

        if (wheelCenterRB.velocity.magnitude > 3f)
            wheelCenterRB.velocity = wheelCenterRB.velocity.normalized * 3f;

        float angle = wheelCenterRB.transform.rotation.eulerAngles.z;
        Debug.Log(angle);
        if (angle > 270f && angle < 360f)
            wheelCenterRB.AddTorque(200f * Time.fixedDeltaTime);
        else if (angle > 0f && angle < 90f)
            wheelCenterRB.AddTorque(-200f * Time.fixedDeltaTime);

        float angleFactor = 1f; // Mathf.Clamp(Mathf.Abs(angle), 30f, 60f) / 60f;
        if (Input.GetKey(KeyCode.A))
            wheelCenterRB.AddTorque(500f * angleFactor * Time.fixedDeltaTime);
        else if (Input.GetKey(KeyCode.D))
            wheelCenterRB.AddTorque(-500f * angleFactor * Time.fixedDeltaTime);
    }

	public void ApplyInvertEffect()
	{
        isInvertOn = true;
        invertTimer = 0f;
	}
}

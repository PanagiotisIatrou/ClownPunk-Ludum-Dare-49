using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomHinge : MonoBehaviour
{
    public GameObject bag1;
    public GameObject bag2;
    public GameObject Hinge;
    private float targetBagOffsetY1 = 0f;
    private float targetBagOffsetY2 = 0f;
    private int maxDiff = 3;
    private float offsetLengthY = 0.4f;

    private void Update()
    {
        int leftWeight = GameManager.Instance.getLeftWeight();
        int rightWeight = GameManager.Instance.getRightWeight();

        int diff = Mathf.Clamp(Mathf.Abs(leftWeight - rightWeight), 0, maxDiff);
        if (diff == 0)
		{
            targetBagOffsetY1 = 0f;
            targetBagOffsetY2 = 0f;
        }
        else if (leftWeight >= rightWeight)
		{
            targetBagOffsetY1 = -(float)diff / maxDiff;
            targetBagOffsetY2 = (float)diff / maxDiff;
        }
        else if (leftWeight < rightWeight)
        {
            targetBagOffsetY1 = (float)diff / maxDiff;
            targetBagOffsetY2 = -(float)diff / maxDiff;
        }

        bag1.transform.position = new Vector2(bag1.transform.position.x, Mathf.Lerp(bag1.transform.position.y, transform.position.y + offsetLengthY * targetBagOffsetY1, 0.05f));
        bag2.transform.position = new Vector2(bag2.transform.position.x, Mathf.Lerp(bag2.transform.position.y, transform.position.y + offsetLengthY * targetBagOffsetY2, 0.05f));
        Hinge.transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Atan2((bag2.transform.position.y - transform.position.y) * offsetLengthY, 1.5f) * Mathf.Rad2Deg);
    }
}

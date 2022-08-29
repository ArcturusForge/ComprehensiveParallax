using UnityEngine;

public class CameraMover : MonoBehaviour
{
    private bool isLeftDown = false;
    private bool isRightDown = false;

    public float moveSpeed;

    private void Update()
    {
        if (isLeftDown)
            transform.position = new Vector3(transform.position.x - 1 * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);

        if (isRightDown)
            transform.position = new Vector3(transform.position.x + 1 * moveSpeed * Time.deltaTime, transform.position.y, transform.position.z);
    }

    public void LeftDown()
    {
        isLeftDown = true;
    }

    public void LeftUp()
    {
        isLeftDown = false;
    }

    public void RightDown()
    {
        isRightDown = true;
    }

    public void RightUp()
    {
        isRightDown = false;
    }
}

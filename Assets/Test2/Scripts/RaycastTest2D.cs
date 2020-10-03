using UnityEngine;

public class RaycastTest2D : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.queriesStartInColliders = false;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitInfo;
        hitInfo = Physics2D.Raycast(transform.position,transform.right,100f);
        if (hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position,hitInfo.point,Color.red);
        }
        else {
            Debug.DrawLine(transform.position, transform.position + transform.right * 100, Color.green);
        }
    }
}

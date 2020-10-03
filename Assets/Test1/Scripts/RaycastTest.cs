using UnityEngine;

public class RaycastTest : MonoBehaviour
{
    [SerializeField]
    private LayerMask mask;
    private GameObject hitGameObject;
    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position,transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100, mask,QueryTriggerInteraction.Ignore))
        {
            hitGameObject = hitInfo.collider.gameObject;
            hitGameObject.GetComponent<MeshRenderer>().material.color = Color.red;
            Debug.DrawLine(ray.origin, hitInfo.point, Color.red);
        }
        else {
            if (hitGameObject) {
                hitGameObject.GetComponent<MeshRenderer>().material.color = Color.black;
            }
            Debug.DrawLine(ray.origin, ray.direction * 100, Color.green);
        }
    }
}

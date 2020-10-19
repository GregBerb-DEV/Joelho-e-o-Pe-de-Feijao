using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    [SerializeField]
    private GameObject player = default;
    [SerializeField]
    private float xMax = default;
    [SerializeField]
    private float xMin = default;
    [SerializeField]
    private float yMax = default;
    [SerializeField]
    private float yMin = default;

    void LateUpdate()
    {
        if (player != null)
        {
            float x = Mathf.Clamp(player.transform.position.x, xMin, xMax);
            float y = Mathf.Clamp(player.transform.position.y, yMin, yMax);
            transform.position = new Vector3(x, y, gameObject.transform.position.z);
        }
    }
}

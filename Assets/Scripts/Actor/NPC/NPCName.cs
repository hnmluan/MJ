using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCName : MonoBehaviour
{
    public class FollowObject : MonoBehaviour
{
    public Transform targetObject; // Kéo và thả đối tượng bạn muốn canvas theo sau vào đây

    private void Update()
    {
        if (targetObject != null)
        {
            // Lấy vị trí của đối tượng và gán cho vị trí của Canvas
            transform.position = targetObject.position;
        }
    }
}
}

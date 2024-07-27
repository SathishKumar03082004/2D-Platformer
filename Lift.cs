using UnityEngine;

public class Lift : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    public float speed = 1.0f;

    private float t = 0.0f;

    void Update()
    {
        t += Time.deltaTime * speed;
        t = Mathf.Clamp01(t);
        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, t);
        if (t >= 1.0f)
        {
            t = 0.0f;
            Transform temp = startPoint;
            startPoint = endPoint;
            endPoint = temp;
        }
    }
}

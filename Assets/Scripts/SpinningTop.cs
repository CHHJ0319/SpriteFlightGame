using UnityEngine;

public class SpinningTop : MonoBehaviour
{
    public  float rotationDir = 1;
    public  float rotationSpeed = 360.0f;

    void Start()
    {
        
    }

    void Update()
    {
        RotateSpinningTop();
    }

    void RotateSpinningTop()
    {
        transform.Rotate(0, 0, rotationDir * rotationSpeed * Time.deltaTime);
    }
}

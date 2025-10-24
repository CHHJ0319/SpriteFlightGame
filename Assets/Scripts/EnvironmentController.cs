using UnityEngine;

public class EnvironmentController : MonoBehaviour
{
    public GameObject borderParent;
    private static GameObject _borderParent;

    void Awake()
    {
        _borderParent = borderParent;
    }

    public static void HideBorder()
    {
        _borderParent.SetActive(false);
    }
}

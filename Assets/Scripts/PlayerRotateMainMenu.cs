using UnityEngine;

public class PlayerRotateMainMenu : MonoBehaviour
{
    [Header("Rotation Settings")]
    [SerializeField] float _anglePerSecond = 1f;

    private void Update()
    {
        transform.Rotate(Vector3.up, _anglePerSecond * Time.deltaTime);
    }
}

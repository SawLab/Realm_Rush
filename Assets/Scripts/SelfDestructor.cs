using UnityEngine;

public class SelfDestructor : MonoBehaviour
{
    [Tooltip("In seconds")] [SerializeField] float timeTillDeletion = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeTillDeletion);
    }
}
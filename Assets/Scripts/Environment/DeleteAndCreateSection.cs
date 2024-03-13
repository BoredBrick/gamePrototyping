using UnityEngine;

public class DeleteAndCreateSection : MonoBehaviour
{
    private GenerateSection generator;
    private void Start()
    {
        generator = ScriptableObject.CreateInstance<GenerateSection>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Vector3 parentPosition = transform.parent.position;
            parentPosition.z += 4 * 50f;
            generator.CreateSection(parentPosition);
            Destroy(transform.parent.gameObject);
        }
    }
}

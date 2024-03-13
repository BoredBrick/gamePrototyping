using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    void Start()
    {
        GenerateSection generator = ScriptableObject.CreateInstance<GenerateSection>();
        Vector3 position = Vector3.zero;
        for (int i = 0; i < 4; i++)
        {
            generator.CreateSection(position);
            position.z += 50f;
        }
    }
}

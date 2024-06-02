using UnityEngine;

public class FieldOfView : MonoBehaviour
{

    //create mesh 
    [SerializeField] EnemyController enemyController;
    [SerializeField] Color meshColor = Color.red;
   [SerializeField] Material redFov;
[SerializeField] float fOVattackRange;
    Mesh mesh;
    MeshFilter meshFilter;
    MeshRenderer meshRenderer;
    void Awake()
    {
        meshFilter = gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = redFov;
        meshRenderer.material.color = meshColor;
    }

    void Start()
    {
        if (enemyController != null)
        {
            mesh = CreateMesh();
            meshFilter.mesh = mesh;
        }
      
    }

    void Update()
    {
        if (enemyController != null)
        {
            mesh = CreateMesh();
            meshFilter.mesh = mesh;
        }
    }

    Mesh CreateMesh()
    {
        Mesh mesh = new Mesh();

        int segments = 10;
        int numVertices = segments + 2;

        Vector3[] vertices = new Vector3[numVertices];
        int[] triangles = new int[segments * 3];

        vertices[0] = Vector3.zero; 

        float currentAngle = -enemyController._currentAngle;
        float deltaAngle = (enemyController._currentAngle * 2) / segments;

        for (int i = 0; i <= segments; i++)
        {
            Vector3 vertex = Quaternion.Euler(0, currentAngle, 0) * Vector3.forward * fOVattackRange;
            vertices[i + 1] = vertex;
            currentAngle += deltaAngle;
        }

        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = i + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();

        return mesh;
    }

    private void OnValidate()
    {
        if (meshFilter != null && enemyController != null)
        {
            mesh = CreateMesh();
            meshFilter.mesh = mesh;
        }
    }

   
   
}

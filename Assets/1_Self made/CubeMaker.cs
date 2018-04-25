using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class CubeMaker : MonoBehaviour
{
    public float y;
    public float dis = 1f;
    public Vector3 size = Vector3.one;
    MeshCreator mc = new MeshCreator();
    float pi = 3.1415926f;
    public GameObject particle;
    private Material m;
    MeshFilter meshFilter;

    private void Start()
    {
        meshFilter = this.GetComponent<MeshFilter>();
        m = this.GetComponent<Renderer>().material;
    }


    // Update is called once per frame
    void Update()
    {

        // one submesh for each face
        Vector3 center = new Vector3(0, 0, 0);

        mc.Clear(); // Clear internal lists and mesh

        for (int row = 0; row < 20; row++)
        {
            for (int col = 0; col < 20; col++)
            {
                center.Set(col * size.x * dis - 10 * size.x * dis , Mathf.Abs(Perlin.Noise(col * size.x * 1.2f, y, row * size.z * 1.2f))*y, row * size.z * dis - 10 * size.x * dis);
                if(center.y > 4f)
                {
                    Instantiate(particle, center, Quaternion.identity);
                }

                CreateCube(center);
            }
        }

        m.SetColor("Rim Color", new Color(y, y, y,1));

        //for (float r = 20; r > 0; r -= 2f)
        //{
        //    for (float i = 0; i < r; i+=0.5f)
        //    {
        //        center.Set(Mathf.Sin(2 * pi * i / r)*r, Mathf.Abs(Perlin.Noise(Mathf.Sin(2 * pi * i / r) * r, y, Mathf.Cos(2 * pi * i / r) * r) * y), Mathf.Cos(2 * pi * i / r)*r);
        //        CreateCube(center);
        //    }

        //}

        meshFilter.mesh = mc.CreateMesh();

    }

    void CreateCube(Vector3 center)
    {
        Vector3 cubeSize = size * 0.5f;

        // top of the cube
        // t0 is top left point
        Vector3 t0 = new Vector3(center.x + cubeSize.x, center.y + cubeSize.y, center.z - cubeSize.z);
        Vector3 t1 = new Vector3(center.x - cubeSize.x, center.y + cubeSize.y, center.z - cubeSize.z);
        Vector3 t2 = new Vector3(center.x - cubeSize.x, center.y + cubeSize.y, center.z + cubeSize.z);
        Vector3 t3 = new Vector3(center.x + cubeSize.x, center.y + cubeSize.y, center.z + cubeSize.z);

        // bottom of the cube
        Vector3 b0 = new Vector3(center.x + cubeSize.x, center.y - cubeSize.y, center.z - cubeSize.z);
        Vector3 b1 = new Vector3(center.x - cubeSize.x, center.y - cubeSize.y, center.z - cubeSize.z);
        Vector3 b2 = new Vector3(center.x - cubeSize.x, center.y - cubeSize.y, center.z + cubeSize.z);
        Vector3 b3 = new Vector3(center.x + cubeSize.x, center.y - cubeSize.y, center.z + cubeSize.z);

        // Top square
        mc.BuildTriangle(t0, t1, t2);
        mc.BuildTriangle(t0, t2, t3);

        // Bottom square
        mc.BuildTriangle(b2, b1, b0);
        mc.BuildTriangle(b3, b2, b0);

        // Back square
        mc.BuildTriangle(b0, t1, t0);
        mc.BuildTriangle(b0, b1, t1);

        mc.BuildTriangle(b1, t2, t1);
        mc.BuildTriangle(b1, b2, t2);

        mc.BuildTriangle(b2, t3, t2);
        mc.BuildTriangle(b2, b3, t3);

        mc.BuildTriangle(b3, t0, t3);
        mc.BuildTriangle(b3, b0, t0);
    }
}
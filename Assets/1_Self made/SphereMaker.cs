using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(MeshFilter))]
public class SphereMaker : MonoBehaviour
{
    public float y;
    public Vector3 size = Vector3.one;

    MeshCreator mc = new MeshCreator();

    private float PI = 3.14159265358979323846264338327950288f;

    // Update is called once per frame
    void Update()
    {

        y = Time.time;

        MeshFilter meshFilter = this.GetComponent<MeshFilter>();
        // one submesh for each face
        Vector3 center = new Vector3(0, 0, 0);

        mc.Clear(); // Clear internal lists and mesh

        for (int row = 0; row < 40; row++)
        {
            for (int col = 0; col < 40; col++)
            {
                center.Set(col * size.x * 1.2f - 20 * size.x * 1.2f, Perlin.Noise(col * size.x * 1.2f, y, row * size.z * 1.2f), row * size.z * 1.2f - 20 * size.x * 1.2f);
                //CreateSphere(center);
            }
        }

        meshFilter.mesh = mc.CreateMesh();

    }

    //void CreateStandardSphere(Vector3 center)
    //{
    //    Vector3 radius = size * 0.5f;

    //    // top of the cube
    //    // t0 is top left point
    //    Vector3 t0 = new Vector3(center.x + cubeSize.x, center.y + cubeSize.y, center.z - cubeSize.z);
    //    Vector3 t1 = new Vector3(center.x - cubeSize.x, center.y + cubeSize.y, center.z - cubeSize.z);
    //    Vector3 t2 = new Vector3(center.x - cubeSize.x, center.y + cubeSize.y, center.z + cubeSize.z);
    //    Vector3 t3 = new Vector3(center.x + cubeSize.x, center.y + cubeSize.y, center.z + cubeSize.z);

    //    // bottom of the cube
    //    Vector3 b0 = new Vector3(center.x + cubeSize.x, center.y - cubeSize.y, center.z - cubeSize.z);
    //    Vector3 b1 = new Vector3(center.x - cubeSize.x, center.y - cubeSize.y, center.z - cubeSize.z);
    //    Vector3 b2 = new Vector3(center.x - cubeSize.x, center.y - cubeSize.y, center.z + cubeSize.z);
    //    Vector3 b3 = new Vector3(center.x + cubeSize.x, center.y - cubeSize.y, center.z + cubeSize.z);

    //    for(int f=0; f<100; f++)
    //    {

    //    }
    //for j in div_count:
    //for i in div_count:
    //  p = origin + 2.0 * (right * i + up * j) / div_count
    //  p2 = p * p
    //  rx = sqrt(1.0 - 0.5 * (p2.y + p2.z) + p2.y * p2.z / 3.0)
    //  ry = sqrt(1.0 - 0.5 * (p2.z + p2.x) + p2.z * p2.x / 3.0)
    //  rz = sqrt(1.0 - 0.5 * (p2.x + p2.y) + p2.x * p2.y / 3.0)
    //  return (rx, ry, rz)

    //    // Top square
    //    mc.BuildTriangle(t0, t1, t2);
    //    mc.BuildTriangle(t0, t2, t3);

    //    // Bottom square
    //    mc.BuildTriangle(b2, b1, b0);
    //    mc.BuildTriangle(b3, b2, b0);

    //    // Back square
    //    mc.BuildTriangle(b0, t1, t0);
    //    mc.BuildTriangle(b0, b1, t1);

    //    mc.BuildTriangle(b1, t2, t1);
    //    mc.BuildTriangle(b1, b2, t2);

    //    mc.BuildTriangle(b2, t3, t2);
    //    mc.BuildTriangle(b2, b3, t3);

    //    mc.BuildTriangle(b3, t0, t3);
    //    mc.BuildTriangle(b3, b0, t0);
    //}
}

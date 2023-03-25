using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(EdgeCollider2D))]
public class Tail : MonoBehaviour
{
    public Transform snake;
    public float pointSpacing = .1f;
    List<Vector2> points;
    LineRenderer line;
    EdgeCollider2D colEdge;

    void Start()
    {
        line = GetComponent<LineRenderer>();
        colEdge = GetComponent<EdgeCollider2D>();
        points = new List<Vector2>();
        SetPoint();
    }

   
    void Update()
    {
        if(Vector3.Distance(points.Last(), snake.position) > pointSpacing)
        SetPoint();
    }

    void SetPoint() {

        if (points.Count > 1)
            colEdge.points = points.ToArray<Vector2>();

        points.Add(snake.position);
        line.positionCount = points.Count;  //line.numPositions
        line.SetPosition(points.Count - 1, snake.position);

        
    }
}

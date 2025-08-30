using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace Tarea3Grafica;

public class Cara
{
    public List<Vertice> Vertices { set; get; }
    public Color4 Color { set; get; }
    public Vertice Centro { set; get; } = new Vertice(0,0,0);
    public Cara()
    {
        this.Vertices = [];
        this.Color = Color4.White;
    }

    public Cara(List<Vertice> vertices, Color4 color)
    {
        this.Vertices = vertices;
        this.Color = color;
        this.Centro = CalcularCentro();
    }

    public void AddVertice(Vertice v)
    {
        this.Vertices.Add(v);
    }

    public void SetColor(Color4 color)
    {
        this.Color = color;
    }

    public void SetCentro(Vertice centro)
    {
        this.Centro = centro;
    }

    public void Dibujar()
    { 
        GL.Begin(PrimitiveType.Polygon);
        GL.Color4(Color);
        GL.Translate(Centro.X,Centro.Y, Centro.Z);
        foreach (var vertice in this.Vertices)
        {
            GL.Vertex3(vertice.X, vertice.Y, vertice.Z);
        }
        GL.End();
    }

    public Vertice CalcularCentro()
    {
        if (Vertices.Count == 0)
            return new Vertice(0,0,0);
        else
        {
            return new Vertice(
                Vertices.Average(v => v.X),
                Vertices.Average(v => v.Y),
                Vertices.Average(v => v.Z)
            );
        }
    }

}

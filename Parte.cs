using OpenTK;
using OpenTK.Graphics;

namespace Tarea3Grafica;

public class Parte
{
    public List<Cara> Caras { set; get; }
    public Color4 Color { set; get; } = Color4.White;
    public Vertice Centro { set; get; } = new Vertice(0, 0, 0);

    public Parte()
    {
        this.Caras = [];
    }

    public Parte(List<Cara> caras, Color4 color)
    {
        this.Caras = caras;
        this.Color = color;
        this.Centro = CalcularCentro();
    }

    public void AddCara(Cara cara)
    {
        this.Caras.Add(cara);
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
        foreach (var cara in Caras)
        {
            cara.SetCentro(Centro);
            cara.Dibujar();
        }
    }

    public Vertice CalcularCentro()
    {
        var vertices = Caras.SelectMany(c => c.Vertices).ToList();
        return new Vertice(
            vertices.Average(v => v.X),
            vertices.Average(v => v.Y),
            vertices.Average(v => v.Z)
        );
    }

}

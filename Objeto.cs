using OpenTK;
using OpenTK.Graphics;

namespace Tarea3Grafica;

public class Objeto
{
    public List<Parte> Partes { set; get; }
    public Color4 Color { set; get; } = Color4.White;
    public Vertice Centro { set; get; }

    public Objeto()
    {
        this.Partes = [];
        this.Centro = new Vertice(0,0,0);
    }

    public Objeto(List<Parte> partes)
    {
        this.Partes = partes;
        this.Centro = CalcularCentro();
    }

    public void AddParte(Parte parte)
    {
        this.Partes.Add(parte);
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
        foreach (var parte in Partes)
        {
            parte.SetCentro(Centro);
            parte.Dibujar();
        }
    }

    public Vertice CalcularCentro()
    {
        var vertices = Partes.SelectMany(p => p.Caras).SelectMany(c => c.Vertices).ToList();
        return new Vertice(
            vertices.Average(v => v.X),
            vertices.Average(v => v.Y),
            vertices.Average(v => v.Z)
        );
        
    }

    public void Dibujar(Color4 color)
    {
        foreach (var parte in Partes)
        {
            parte.SetColor(color);
            parte.Centro = Centro;
            parte.Dibujar();
        }
    }

}

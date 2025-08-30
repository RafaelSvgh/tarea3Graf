using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tarea3Grafica.Controles;

namespace Tarea3Grafica;

public class Game : GameWindow
{
    private Camara? camara = null;
    private MouseState _lastMouseState;
    Objeto computadora = new Objeto();
    public Game() : base(1000, 900, GraphicsMode.Default, "Tarea 3")
    {

    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        camara = new Camara(Width, Height);
        GL.Enable(EnableCap.DepthTest);
        GL.ClearColor(Color4.Black);

        List<Vertice> verticesMonitor = new List<Vertice>()
        {
            new Vertice(-0.45f, 0.25f, 0.0f),
            new Vertice(0.35f, 0.25f, 0.0f),
            new Vertice(0.35f, -0.45f, 0.0f),
            new Vertice(-0.45f, -0.45f, 0.0f),
            new Vertice(-0.45f, 0.25f, -0.1f),
            new Vertice(0.35f, 0.25f, -0.1f),
            new Vertice(0.35f, -0.45f, -0.1f),
            new Vertice(-0.45f, -0.45f, -0.1f),
        };

        List<Vertice> verticesBaseMonitor = new List<Vertice>()
        {
            new Vertice(-0.1f, -0.45f, 0.0f),
            new Vertice(0.0f, -0.45f, 0.0f),
            new Vertice(0.0f, -0.55f, 0.0f),
            new Vertice(-0.1f, -0.55f, 0.0f),
            new Vertice(-0.1f, -0.45f, -0.1f),
            new Vertice(0.0f, -0.45f, -0.1f),
            new Vertice(0.0f, -0.55f, -0.1f),
            new Vertice(-0.1f, -0.55f, -0.1f),
        };

        List<Vertice> verticesBaseMonitor2 = new List<Vertice>()
        {
            new Vertice(-0.2f, -0.55f, 0.05f),
            new Vertice(0.1f, -0.55f, 0.05f),
            new Vertice(0.1f, -0.6f, 0.05f),
            new Vertice(-0.2f, -0.6f, 0.05f),
            new Vertice(-0.2f, -0.55f, -0.15f),
            new Vertice(0.1f, -0.55f, -0.15f),
            new Vertice(0.1f, -0.6f, -0.15f),
            new Vertice(-0.2f, -0.6f, -0.15f),
        };

        List<Vertice> verticesTeclado = new List<Vertice>()
        {
            new Vertice(-0.45f, -0.55f, 0.4f),
            new Vertice(0.35f, -0.55f, 0.4f),
            new Vertice(0.35f, -0.6f, 0.4f),
            new Vertice(-0.45f, -0.6f, 0.4f),
            new Vertice(-0.45f, -0.55f, 0.15f),
            new Vertice(0.35f, -0.55f, 0.15f),
            new Vertice(0.35f, -0.6f, 0.15f),
            new Vertice(-0.45f, -0.6f, 0.15f),
        };

        List<Vertice> verticesCPU = new List<Vertice>()
        {
            new Vertice(-0.9f, 0.6f, 0.5f),
            new Vertice(-0.6f, 0.6f, 0.5f),
            new Vertice(-0.6f, -0.6f, 0.5f),
            new Vertice(-0.9f, -0.6f, 0.5f),
            new Vertice(-0.9f, 0.6f, -0.4f),
            new Vertice(-0.6f, 0.6f, -0.4f),
            new Vertice(-0.6f, -0.6f, -0.4f),
            new Vertice(-0.9f, -0.6f, -0.4f),
        };


        List<Cara> carasMonitor = new List<Cara>()
        {
            new Cara([verticesMonitor[0], verticesMonitor[1], verticesMonitor[2], verticesMonitor[3]], Color4.DarkGray),
            new Cara([verticesMonitor[4], verticesMonitor[5], verticesMonitor[6], verticesMonitor[7]], Color4.Gray),
            new Cara([verticesMonitor[0], verticesMonitor[1], verticesMonitor[5], verticesMonitor[4]], Color4.LightGray),
            new Cara([verticesMonitor[2], verticesMonitor[3], verticesMonitor[7], verticesMonitor[6]], Color4.LightGray),
            new Cara([verticesMonitor[1], verticesMonitor[2], verticesMonitor[6], verticesMonitor[5]], Color4.LightGray),
            new Cara([verticesMonitor[0], verticesMonitor[3], verticesMonitor[7], verticesMonitor[4]], Color4.LightGray),
        };

        List<Cara> carasBaseMonitor = new List<Cara>()
        {
            new Cara(new List<Vertice>() { verticesBaseMonitor[0], verticesBaseMonitor[1], verticesBaseMonitor[2], verticesBaseMonitor[3] }, Color4.DarkGray),
            new Cara(new List<Vertice>() { verticesBaseMonitor[4], verticesBaseMonitor[5], verticesBaseMonitor[6], verticesBaseMonitor[7] }, Color4.Gray),
            new Cara(new List<Vertice>() { verticesBaseMonitor[0], verticesBaseMonitor[1], verticesBaseMonitor[5], verticesBaseMonitor[4] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesBaseMonitor[2], verticesBaseMonitor[3], verticesBaseMonitor[7], verticesBaseMonitor[6] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesBaseMonitor[1], verticesBaseMonitor[2], verticesBaseMonitor[6], verticesBaseMonitor[5] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesBaseMonitor[0], verticesBaseMonitor[3], verticesBaseMonitor[7], verticesBaseMonitor[4] }, Color4.LightGray),
        };

        List<Cara> carasBaseMonitor2 = new List<Cara>()
        {
            new Cara(new List<Vertice>() { verticesBaseMonitor2[0], verticesBaseMonitor2[1], verticesBaseMonitor2[2], verticesBaseMonitor2[3] }, Color4.DarkGray),
            new Cara(new List<Vertice>() { verticesBaseMonitor2[4], verticesBaseMonitor2[5], verticesBaseMonitor2[6], verticesBaseMonitor2[7] }, Color4.Gray),
            new Cara(new List<Vertice>() { verticesBaseMonitor2[0], verticesBaseMonitor2[1], verticesBaseMonitor2[5], verticesBaseMonitor2[4] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesBaseMonitor2[2], verticesBaseMonitor2[3], verticesBaseMonitor2[7], verticesBaseMonitor2[6] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesBaseMonitor2[1], verticesBaseMonitor2[2], verticesBaseMonitor2[6], verticesBaseMonitor2[5] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesBaseMonitor2[0], verticesBaseMonitor2[3], verticesBaseMonitor2[7], verticesBaseMonitor2[4] }, Color4.LightGray),
        };

        List<Cara> carasTeclado = new List<Cara>()
        {
            new Cara(new List<Vertice>() { verticesTeclado[0], verticesTeclado[1], verticesTeclado[2], verticesTeclado[3] }, Color4.DarkGray),
            new Cara(new List<Vertice>() { verticesTeclado[4], verticesTeclado[5], verticesTeclado[6], verticesTeclado[7] }, Color4.Gray),
            new Cara(new List<Vertice>() { verticesTeclado[0], verticesTeclado[1], verticesTeclado[5], verticesTeclado[4] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesTeclado[2], verticesTeclado[3], verticesTeclado[7], verticesTeclado[6] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesTeclado[1], verticesTeclado[2], verticesTeclado[6], verticesTeclado[5] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesTeclado[0], verticesTeclado[3], verticesTeclado[7], verticesTeclado[4] }, Color4.LightGray),
        };

        List<Cara> carasCPU = new List<Cara>()
        {
            new Cara(new List<Vertice>() { verticesCPU[0], verticesCPU[1], verticesCPU[2], verticesCPU[3] }, Color4.DarkGray),
            new Cara(new List<Vertice>() { verticesCPU[4], verticesCPU[5], verticesCPU[6], verticesCPU[7] }, Color4.Gray),
            new Cara(new List<Vertice>() { verticesCPU[0], verticesCPU[1], verticesCPU[5], verticesCPU[4] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesCPU[2], verticesCPU[3], verticesCPU[7], verticesCPU[6] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesCPU[1], verticesCPU[2], verticesCPU[6], verticesCPU[5] }, Color4.LightGray),
            new Cara(new List<Vertice>() { verticesCPU[0], verticesCPU[3], verticesCPU[7], verticesCPU[4] }, Color4.LightGray),
        };

        List<Parte> partesComputadora = new List<Parte>()
        {
            new Parte(carasMonitor, Color4.SkyBlue),
            new Parte(carasTeclado, Color4.DarkGray),
            new Parte(carasCPU, Color4.Gray),
            new Parte(carasBaseMonitor, Color4.LightGray),
            new Parte(carasBaseMonitor2, Color4.DarkBlue),
        };

        computadora = new Objeto(partesComputadora);
    }


    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref camara!.Proyeccion);
        GL.MatrixMode(MatrixMode.Modelview);
        GL.LoadMatrix(ref camara.Vista);
        computadora.Dibujar();
        SwapBuffers();
    }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
        base.OnUpdateFrame(e);
        camara!.ProcesarMouse(Mouse.GetState(), _lastMouseState, (float)e.Time);
        camara.ActualizarMatrices(Width, Height);
        _lastMouseState = Mouse.GetState();
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, Width, Height);
        Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4, Width / (float)Height, 0.1f, 100f);
        GL.MatrixMode(MatrixMode.Projection);
        GL.LoadMatrix(ref projection);
    }
}

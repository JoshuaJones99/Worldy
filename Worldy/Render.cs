using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Input;
using OpenTK.Graphics.OpenGL;
using System.Drawing;

namespace Worldy
{
    public class Render : GameWindow
    {
        public List<Square> Coordinates;

        public Vector3 terrainLoc;
        public Vector3 rotation;
        public Vector3 previousRotation;
        public float rotationAmount = 3f;
        public int objSize = 5;

        public Render(List<Square> Coordinates) : base(1280, 720, OpenTK.Graphics.GraphicsMode.Default, ("Terrain Generation " + Terrain.seed), GameWindowFlags.Default, DisplayDevice.Default, 3, 0, OpenTK.Graphics.GraphicsContextFlags.ForwardCompatible)
        {
            this.Coordinates = Coordinates;
            rotation = Vector3.Zero;
            previousRotation = Vector3.Zero;
            CursorVisible = false;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.Black);
            GL.Enable(EnableCap.DepthTest);
            GL.Scale(0.002f, 0.002f, 0.002f);
            GL.Translate(-Terrain.gridSize / 2, 0f, -Terrain.gridSize / 2);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Width, Height);
        }

        public void drawTerrain()
        {
            GL.Begin(PrimitiveType.Quads);
            foreach (Square currentSquare in Coordinates)
            {

                GL.Color3(DetermineColour(currentSquare));
                GL.Vertex3(currentSquare.NW[0], currentSquare.NW[2], currentSquare.NW[1]);
                GL.Vertex3(currentSquare.SW[0], currentSquare.SW[2], currentSquare.SW[1]);
                GL.Vertex3(currentSquare.SE[0], currentSquare.SE[2], currentSquare.SE[1]);
                GL.Vertex3(currentSquare.NE[0], currentSquare.NE[2], currentSquare.NE[1]);

                //if (currentSquare.obj != null) { drawObject(currentSquare); }
            }
            GL.End();
        }

        public void drawObject(Square square)
        {
            GL.Color3(Color.Green);
            float height = (float)(square.NW[2] + square.SW[2] + square.SE[2] + square.NE[2]) / 4;  //Average height of square.
            Vector3 midLocation = new Vector3((float)square.midpoint[0], height, (float)square.midpoint[1]);

            string objType = square.obj.Type;
            //Experiment with actual size of objects. Simple object should just be a cube. (8 points)
            //Cube coordinates stored as an array of size 8 holding Vector3s of coordinates
            Vector3[] objCoordinates = new Vector3[8];  //First 4 values are top square coordinates, last 4 are bottom square coordinates.
            float topY = midLocation.Y + objSize;
            float bottomY = midLocation.Y;

            objCoordinates[0] = (new Vector3((midLocation.X - objSize / 2), topY, (midLocation.Z + objSize / 2)));
            objCoordinates[1] = (new Vector3((midLocation.X - objSize / 2), topY, (midLocation.Z - objSize / 2)));
            objCoordinates[2] = (new Vector3((midLocation.X + objSize / 2), topY, (midLocation.Z - objSize / 2)));
            objCoordinates[3] = (new Vector3((midLocation.X + objSize / 2), topY, (midLocation.Z + objSize / 2)));
            objCoordinates[4] = (new Vector3((midLocation.X + objSize / 2), bottomY, (midLocation.Z + objSize / 2)));
            objCoordinates[5] = (new Vector3((midLocation.X - objSize / 2), bottomY, (midLocation.Z - objSize / 2)));
            objCoordinates[6] = (new Vector3((midLocation.X + objSize / 2), bottomY, (midLocation.Z - objSize / 2)));
            objCoordinates[7] = (new Vector3((midLocation.X + objSize / 2), bottomY, (midLocation.Z + objSize / 2)));
            //Actually drawing the cube

            GL.Vertex3(objCoordinates[0]); GL.Vertex3(objCoordinates[1]); GL.Vertex3(objCoordinates[2]); GL.Vertex3(objCoordinates[3]); //Top square
            GL.Vertex3(objCoordinates[4]); GL.Vertex3(objCoordinates[5]); GL.Vertex3(objCoordinates[6]); GL.Vertex3(objCoordinates[7]); //Bottom square
            GL.Vertex3(objCoordinates[0]); GL.Vertex3(objCoordinates[4]); GL.Vertex3(objCoordinates[5]); GL.Vertex3(objCoordinates[1]); //Left square
            GL.Vertex3(objCoordinates[2]); GL.Vertex3(objCoordinates[6]); GL.Vertex3(objCoordinates[7]); GL.Vertex3(objCoordinates[3]); //Right square
            GL.Color3(Color.White);
        }

        public Color DetermineColour(Square square)
        {
            Color colour = new Color();
            if (square.biomeType == "Forest") { colour = Color.ForestGreen; }
            else if (square.biomeType == "Plains") { colour = Color.GreenYellow; }
            else if (square.biomeType == "Desert") { colour = Color.SandyBrown; }
            else if (square.biomeType == "Tundra") { colour = Color.LightBlue; }
            else { colour = Color.White; }

            return colour;
        }

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            SetZero();

            if (e.Delta > 0) { GL.Scale(1.1f, 1.1f, 1.1f); }
            if (e.Delta < 0) { GL.Scale(0.9f, 0.9f, 0.9f); }

            SetBack();
        }

        protected override void OnMouseMove(MouseMoveEventArgs e)
        {
            base.OnMouseMove(e);
            SetZero();
            GL.Rotate(e.XDelta, Vector3.UnitY);
            rotation.X += e.XDelta;

            SetBack();
        }

        protected override void OnKeyDown(KeyboardKeyEventArgs e)
        {
            base.OnKeyDown(e);
            SetZero();
            if (e.Key == Key.Escape)
            {
                GUI ui = new GUI();
                ui.Show();
                Exit();
            }
            if (e.Key == Key.D)
            {
                GL.Translate(5, 0, 0);
            }
            if (e.Key == Key.A)
            {
                GL.Translate(-5, 0, 0);
            }
            if (e.Key == Key.W)
            {
                GL.Translate(0, 5, 0);
            }
            if (e.Key == Key.S)
            {
                GL.Translate(0, -5, 0);
            }
            if (e.Key == Key.Enter)
            {
                Continue();
            }
            SetBack();
        }

        public void Continue()
        {
            Terrain.renderTime = true;
            Exit();
        }
        public void SetZero()
        {
            //This function sets the rotation and the position of the terrain to default.
            GL.Translate(Terrain.gridSize / 2, 0, Terrain.gridSize / 2);
            previousRotation = rotation;
            GL.Rotate(-rotation.X, Vector3.UnitY);  //Resets rotation to 0
            rotation = Vector3.Zero;
        }

        public void SetBack()
        {
            //This function undoes SetZero for after all transformations have been applied
            GL.Rotate(previousRotation.X, Vector3.UnitY);
            rotation += previousRotation;
            GL.Translate(-Terrain.gridSize / 2, 0, -Terrain.gridSize / 2);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            //Rendering stuff below
            drawTerrain();

            //leave this
            GL.Flush();
            SwapBuffers();
        }
    }
}

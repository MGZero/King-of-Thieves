using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_Thieves.Graphics
{
    class CRenderable
    {

        private Effect _shader;
        public VertexPositionColor[] vertices;
        private VertexBuffer _vertexBuffer;
        public float aspectRatio = (float)CGraphics.GPU.Viewport.Width / (float)CGraphics.GPU.Viewport.Height;

        public CRenderable(Effect shader, params VertexPositionColor[] vertices)
        {
            _shader = shader;
            this.vertices = vertices;
            _vertexBuffer = new VertexBuffer(CGraphics.GPU, VertexPositionColor.VertexDeclaration, vertices.Length, BufferUsage.WriteOnly);
        }

        public void draw(GraphicsDevice graphics)
        {

            foreach (EffectPass pass in _shader.CurrentTechnique.Passes)
            {
                pass.Apply();
                CGraphics.GPU.SetVertexBuffer(_vertexBuffer);
                graphics.DrawIndexedPrimitives(PrimitiveType.LineList, 0, 0, vertices.Length, 0, 1);
            }
        }

        public void swapTechnique(string name)
        {
            _shader.CurrentTechnique = _shader.Techniques[name];
        }

        public void swapTechnique(int index)
        {
            _shader.CurrentTechnique = _shader.Techniques[index];
        }

        
    }
}

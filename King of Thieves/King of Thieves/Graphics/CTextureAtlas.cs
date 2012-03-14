using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_Thieves.Graphics
{
    /* TODO: Refactor to utilize 2D array-like structure.
     * Due: Tomorrow
     */
        class CTextureAtlas
        {
            public int Width, Height, CellSpacing, FrameRate, Cell;
            public List<Rectangle> Cells;
            public Texture2D Tex;

            public CTextureAtlas(Texture2D tex, int width, int height, int cellspacing, List<Rectangle> cell)
            {
                Width = width;
                Height = height;
                CellSpacing = cellspacing;
                Cells = cell;
                Tex = tex;
            }

            public CTextureAtlas(Texture2D tex, int width, int height, int cellspacing, List<Rectangle> cells, int frameRate)
            {
                Width = width;
                Height = height;
                CellSpacing = cellspacing;
                Cells = cells;
                Tex = tex;
                FrameRate = frameRate;
            }

            private int _frameWidth, _frameHeight;
            private int _frameRate;
            private Texture2D _sourceImage;
            private List<Rectangle> _cells;

            private void AssembleTextureAtlas(CTextureAtlas textureAtlas)
            {
                for (int y = 0; y <= (textureAtlas.Tex.Bounds.Height / textureAtlas.Height); y++)
                {
                    for (int x = 0; x <= (textureAtlas.Tex.Bounds.Width / textureAtlas.Width); x++)
                    {
                        textureAtlas.Cells.Add(new Rectangle(textureAtlas.Width * x, textureAtlas.Height * y, textureAtlas.Width + textureAtlas.CellSpacing, textureAtlas.Height + textureAtlas.CellSpacing));
                    }
                }
        }

            public void UpdateFrames(GameTime gameTime, int _frameRate)
            {
                float _timeElapsed = 0;
                if (FrameRate != _frameRate)
                    FrameRate = _frameRate;

                _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_timeElapsed > (1 / (float)FrameRate))
                {
                    Cell++;
                    Cell = Cell % Cells.Count;
                    _timeElapsed -= (1 / (float)FrameRate);
                }
            }

            public void UpdateFrames(GameTime gameTime, int StartingFrame, int EndingFrame, int _frameRate)
            {
                float _timeElapsed = 0;
                if (Cell < StartingFrame)
                    Cell = StartingFrame;

                if (FrameRate != _frameRate)
                    FrameRate = _frameRate;

                _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (_timeElapsed > (1 / (float)FrameRate))
                {
                    Cell++;
                    Cell = Cell % Cells.Count;
                    _timeElapsed -= (1 / (float)FrameRate);
                }
                if (Cell > EndingFrame)
                    Cell = StartingFrame;
            }
        /*
            public void DrawFrames(SpriteBatch sb, Vector2 position, Color color, SpriteFont spriteFont)
            {
#if DEBUG
                sb.DrawString(spriteFont, "Current Frame: " + _currFrame.ToString(), Vector2.Zero, color);
#endif
                sb.Draw(_sprite.Tex, position, _sprite.Cells[_currFrame], color);
            }
        */
            ~CTextureAtlas()
            {

            }
        }
    }

}

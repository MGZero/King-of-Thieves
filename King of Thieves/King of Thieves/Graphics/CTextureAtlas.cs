using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_Thieves.Graphics
{
        struct texAtlas
        {
            public int Width, Height, CellSpacing;
            public List<Rectangle> Cells;
            public Texture2D Tex;

            public texAtlas(Texture2D tex, int width, int height, int cellspacing, List<Rectangle> cell)
            {
                Width = width;
                Height = height;
                CellSpacing = cellspacing;
                Cells = cell;
                Tex = tex;
            }
        }

        class CTextureAtlas
        {
            private int _frameWidth, _frameHeight;
            private int _frameRate;
            private Texture2D _sourceImage;
            private List<Rectangle> _cells;

            private void AssembleTextureAtlas(texAtlas textureAtlas)
            {
                for (int y = 0; y <= (textureAtlas.Tex.Bounds.Height / textureAtlas.Height); y++)
                {
                    for (int x = 0; x <= (textureAtlas.Tex.Bounds.Width / textureAtlas.Width); x++)
                    {
                        textureAtlas.Cells.Add(new Rectangle(textureAtlas.Width * x, textureAtlas.Height * y, textureAtlas.Width + textureAtlas.CellSpacing, textureAtlas.Height + textureAtlas.CellSpacing));
                    }
                }
            }

            public class Sprite : CTextureAtlas
            {
                private texAtlas _sprite;
                private int _currFrame = 0;
                private float _timeElapsed = 0;
                private int _frameCount = 0;

                public Sprite(int FrameWidth, int FrameHeight, int FrameRate, int CellSpacing, Texture2D SourceImage)
                {
                    _frameWidth = FrameWidth;
                    _frameHeight = FrameHeight;
                    _frameRate = FrameRate;
                    _sourceImage = SourceImage;
                    _cells = new List<Rectangle>();
                    _sprite = new texAtlas(SourceImage, _frameWidth, _frameHeight, CellSpacing, _cells);

                    AssembleTextureAtlas(_sprite);
                    _frameCount = _sprite.Cells.Count;
                }

                public void UpdateFrames(GameTime gameTime, int FrameRate)
                {
                    if (_frameRate != FrameRate)
                        _frameRate = FrameRate;

                    _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (_timeElapsed > (1 / (float)_frameRate))
                    {
                        _currFrame++;
                        _currFrame = _currFrame % _frameCount;
                        _timeElapsed -= (1 / (float)_frameRate);
                    }
                }

                public void UpdateFrames(GameTime gameTime, int StartingFrame, int EndingFrame, int FrameRate)
                {
                    if (_currFrame < StartingFrame)
                        _currFrame = StartingFrame;

                    if (_frameRate != FrameRate)
                        _frameRate = FrameRate;

                    _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
                    if (_timeElapsed > (1 / (float)_frameRate))
                    {
                        _currFrame++;
                        _currFrame = _currFrame % _frameCount;
                        _timeElapsed -= (1 / (float)_frameRate);
                    }
                    if (_currFrame > EndingFrame)
                        _currFrame = StartingFrame;
                }

                public void DrawFrames(SpriteBatch sb, Vector2 position, Color color, SpriteFont spriteFont)
                {
#if DEBUG
                    sb.DrawString(spriteFont, "Current Frame: " + _currFrame.ToString(), Vector2.Zero, color);
#endif
                    sb.Draw(_sprite.Tex, position, _sprite.Cells[_currFrame], color);
                }


                ~Sprite()
                {

                }
            }

            ~CTextureAtlas()
            {

            }
        }
    }

}

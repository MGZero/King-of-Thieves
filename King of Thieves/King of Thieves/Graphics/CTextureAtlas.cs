using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace King_of_Thieves.Graphics
{
    class CTextureAtlas
    {
        public int FrameWidth = 0, FrameHeight = 0, FrameRate = 1, CellSpacing = 0, Column = 0, Row = 0, CurrentCell = 0;
        private Rectangle[,] _textureAtlas;
        private Texture2D SourceImage;

        public CTextureAtlas(Texture2D _sourceImage, int _frameWidth, int _frameHeight, int _cellSpacing)
        {
            FrameWidth = _frameWidth;
            FrameHeight = _frameHeight;
            CellSpacing = _cellSpacing;
            SourceImage = _sourceImage;
            _textureAtlas = new Rectangle[(_sourceImage.Bounds.Width / _frameWidth), (_sourceImage.Bounds.Height / _frameHeight)];
            _assembleTextureAtlas(this);
        }

        public CTextureAtlas(Texture2D _sourceImage, int _frameWidth, int _frameHeight, int _cellSpacing, int frameRate)
        {
            FrameWidth = _frameWidth;
            FrameHeight = _frameHeight;
            CellSpacing = _cellSpacing;
            SourceImage = _sourceImage;
            FrameRate = frameRate;
            _textureAtlas = new Rectangle[(_sourceImage.Bounds.Width / _frameWidth),(_sourceImage.Bounds.Height / _frameHeight)];
            _assembleTextureAtlas(this);
        }

        /*
            * x == row
            * y == column
            */
        private void _assembleTextureAtlas(CTextureAtlas textureAtlas)
        {
            for (int y = 0; y <= (textureAtlas.SourceImage.Bounds.Height / textureAtlas.FrameHeight) - 1; y++)
            {
                for (int x = 0; x <= (textureAtlas.SourceImage.Bounds.Width / textureAtlas.FrameWidth) - 1; x++)
                {
                    textureAtlas._textureAtlas[x,y] = new Rectangle
                        (textureAtlas.FrameWidth * x, textureAtlas.FrameHeight * y,
                        textureAtlas.FrameWidth + textureAtlas.CellSpacing, 
                        textureAtlas.FrameHeight + textureAtlas.CellSpacing);
                }
            }
        }
/*
* Must refactor frame-cycle code now.
        public void UpdateFrames(GameTime gameTime, int _frameRate)
        {
            float _timeElapsed = 0;
            if (FrameRate != _frameRate)
                FrameRate = _frameRate;

            _timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (_timeElapsed > (1 / (float)FrameRate))
            {
                Cell++;
                Cell = Cell % TextureAtlas.Count();
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
                Cell = Cell % TextureAtlas.Count();
                _timeElapsed -= (1 / (float)FrameRate);
            }
            if (Cell > EndingFrame)
                Cell = StartingFrame;
        }
*/
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

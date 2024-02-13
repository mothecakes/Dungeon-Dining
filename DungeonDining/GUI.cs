using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;
using Rectangle = Microsoft.Xna.Framework.Rectangle;

namespace DungeonDining
{
    internal class GUI
    {
        private float _x;
        private float _y;
        private float _width;
        private float _height;
        private Rectangle _sourceRect;
        private Texture2D _texture;
        private static SpriteBatch _spriteBatch;

        public GUI(ref SpriteBatch spriteBatch, ref Texture2D source, Rectangle destRect, Rectangle sourceRect ) 
        {
            _spriteBatch = spriteBatch;
            _texture = source;
            _x = destRect.X;
            _y = destRect.Y;
            _width = destRect.Width;
            _height = destRect.Height;
            _sourceRect = sourceRect;


        }

        public bool Draw()
        {
            bool success = true;
            if (_sourceRect.Width <= 16 || _sourceRect.Height == 0)
            {
                Console.WriteLine("GUI source rect too small. Failed");
                return success = false;
            }
            float scaleX = _width/ _sourceRect.Width;
            float scaleY = _height/ _sourceRect.Height;
            float insideScale = (_width - (2f * (16 * scaleX))) / (_sourceRect.Width - 32);
            Rectangle first = new Rectangle(_sourceRect.X, _sourceRect.Y, 16, _sourceRect.Height);
            Rectangle middle = new Rectangle(_sourceRect.X + 16, _sourceRect.Y, _sourceRect.Width - 32, _sourceRect.Height );
            Rectangle end = new Rectangle(_sourceRect.X + _sourceRect.Width - 16, _sourceRect.Y, 16, _sourceRect.Height);

            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            //_spriteBatch.Draw(_texture, new Vector2(_x, _y), _sourceRect, Color.White, 0f, new Vector2(0, 0), new Vector2(scaleX, scaleY), 0, 0f);

            _spriteBatch.Draw(_texture, new Vector2(_x, _y), first, Color.White, 0f, new Vector2(0, 0), new Vector2(scaleX, scaleY), 0, 0f);
            float middleStart = 16 * scaleX;
            _spriteBatch.Draw(_texture, new Vector2(middleStart, _y), middle, Color.White, 0f, new Vector2(0, 0), new Vector2(insideScale, scaleY), 0, 0f);
            _spriteBatch.Draw(_texture, new Vector2(_x + _width - middleStart, _y), end, Color.White, 0f, new Vector2(0, 0), new Vector2(scaleX, scaleY), 0, 0f);

            _spriteBatch.End();

            return success;
        }
        
    }
}

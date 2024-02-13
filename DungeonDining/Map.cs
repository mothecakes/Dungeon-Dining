using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonDining
{
    internal class Map
    {
        private static int _width = 10;
        private static int _height = 10;
        private Tile[,] _map;
        private Rectangle _view;
        private float _horizontalScale;
        private float _verticalScale;
        private Texture2D _tilesheet;
        private SpriteBatch _spriteBatch;
        private float _scale;
        private RenderTarget2D _target;
        private static int _resX = 16 * _width;
        private static int _resY = 16 * _height;

        public Map(ref SpriteBatch spriteBatch, ref Texture2D tilesheet, Rectangle view) 
        {
            _view = view;
            _map = new Tile[_width, _height];
            generateMap();
            //_horizontalScale = (float)Math.Floor((_view.Width / (float)_width) / 16 );
            _horizontalScale = (_view.Width / (float)_width) / 16 ;
            _verticalScale = (_view.Height / (float)_height) / 16 ;
            _scale = Math.Min(_horizontalScale,_verticalScale);
            //_verticalScale = (float)Math.Floor((_view.Height / (float)_height) / 16);

            _tilesheet = tilesheet;
            _spriteBatch = spriteBatch;
        }

        public void Draw() 
        {
            _spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);
            for(int i = 0; i < _width; i++)
            {
                for(int j = 0; j < _height; j++)
                {
                    // if is ground
                    if (!_map[i, j].getWall())
                    {
                        //  draw ground
                        // TODO : implement rendertarget
                        Vector2 pos = new Vector2(i * (16 * _scale) + _view.X , (j * (16 * _scale)) + _view.Y);
                        _spriteBatch.Draw(_tilesheet, pos, new Rectangle(16, 0, 16, 16), Color.White, 0f, new Vector2(0, 0),
                            new Vector2(_scale, _scale), 0, 0);
                    }
                    // if floor
                    else
                    {
                        // draw floor
                        Vector2 pos = new Vector2((i * (16 * _scale)) + _view.X, (j * (16 * _scale)) + _view.Y);
                        _spriteBatch.Draw(_tilesheet, pos, new Rectangle(0, 0, 16, 16), Color.White, 0f, new Vector2(0, 0),
                           new Vector2(_scale, _scale), 0, 0);
                    }
                }
            }
            _spriteBatch.End();
        }
        private void generateMap() 
        {
            // Populates array
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    _map[i, j] = new Tile();
                }
            }

            // Sets outer edges to walls
            for (int i = 0; i < _width; i++)
            {
                _map[i, 0].setWall();
                _map[i, _height - 1].setWall();
            }
            for (int i = 1; i < _height - 1; i++) 
            {
                _map[0, i].setWall();
                _map[_width - 1, i].setWall();
            }
        }







    }
}

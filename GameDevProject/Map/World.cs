using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GameDevProject.Map
{
    class World : Interfaces.IDrawable //op betere locatie zetten?
    {
        #region Properties
        private string name;
        private int id;

        private string[,] worldTemplate;

        private List<Rectangle> tileRectangles; //List of all rectangles

        private Tile[,] tiles; //The actual world tiles

        private Texture2D tilesheet;
        #endregion

        #region Constructor
        public World(Texture2D tileset, string[,] worldTemplate)
        {
            this.worldTemplate = worldTemplate;

            this.tilesheet = tileset;

            this.tileRectangles = new List<Rectangle>();

            this.tiles = new Tile[worldTemplate.GetLength(0), worldTemplate.GetLength(1)];

            CreateRectangles(136, 136, 8, 8);
            AddTiles();

            foreach (Tile tile in GetTiles())
            {
                if (tile.isFloor)
                {
                    Debug.WriteLine($"tile {tile.identifier} is a floor");
                }
                if (tile.isCeiling)
                {
                    Debug.WriteLine($"tile {tile.identifier} is a ceiling");
                }
                if (tile.isBackground)
                {
                    Debug.WriteLine($"tile {tile.identifier} is a background");
                }
            }
            foreach(Tile tile in GetTiles())
            {
                Debug.WriteLine($"{tile.SourceRectangle.X}, {tile.SourceRectangle.Y}");
            }
        }
        #endregion

        #region Methods
        public int GetWorldWidth()
        {
            int width = tiles.GetLength(1) * 16;

            return width;
        }

        public int GetWorldHeight()
        {
            int height = tiles.GetLength(0) * 16;

            return height;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in tiles)
            {
                spriteBatch.Draw(tilesheet, tile.Position, tile.SourceRectangle, Color.White);
                //spriteBatch.Draw(tilesheet, tile.Position, tile.SourceRectangle, Color.White, 0f, Vector2.Zero, 5.0f, SpriteEffects.None, 0f);
            }
        }

        private void CreateRectangles(int width, int height, int numberOfWidthTiles, int numberOfHeightTiles)
        {
            int widthOfFrame = width / numberOfWidthTiles; //17
            int heightOfFrame = height / numberOfHeightTiles; //17

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    tileRectangles.Add(new Rectangle(x, y, 16, 16));
                    //tileTextures.Add(new Texture2D());
                }
            }            
        }
        private void AddTiles()
        {
            for (int y = 0; y < worldTemplate.GetLength(0); y++)
            {
                for (int x = 0; x < worldTemplate.GetLength(1); x++)
                {
                    int index = (worldTemplate[y, x].ToCharArray()[0] - 'A') * 8 + (worldTemplate[y, x].ToCharArray()[1] - '1');
                    tiles[y, x] = new Tile(tileRectangles[index], new Vector2(x * 16, y * 16), index);
                }
            }
        }
        public List<Tile> GetTiles()
        {
            List<Tile> tileList = new List<Tile>();
            foreach (Tile tile in tiles)
            {
                tileList.Add(tile);
            }
            return tileList;
        }
        #endregion
    }
}

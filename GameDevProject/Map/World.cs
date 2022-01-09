using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Map
{
    class World : Interfaces.IDrawable
    {
        #region Properties
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

            this.CreateRectangles(136, 136, 8, 8);
            this.AddTiles();
        }
        #endregion

        #region Public methods
        public List<Tile> GetTiles()
        {
            List<Tile> tileList = new List<Tile>();
            foreach (Tile tile in this.tiles)
            {
                tileList.Add(tile);
            }
            return tileList;
        }
        public int GetWorldWidth()
        {
            int width = this.tiles.GetLength(1) * 16;

            return width;
        }

        public int GetWorldHeight()
        {
            int height = this.tiles.GetLength(0) * 16;

            return height;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Tile tile in this.tiles)
            {
                spriteBatch.Draw(tilesheet, tile.Position, tile.SourceRectangle, Color.White);
            }
        }
        #endregion

        #region Private methods
        private void CreateRectangles(int width, int height, int numberOfWidthTiles, int numberOfHeightTiles)
        {
            int widthOfFrame = width / numberOfWidthTiles; //17
            int heightOfFrame = height / numberOfHeightTiles; //17

            for (int y = 0; y <= height - heightOfFrame; y += heightOfFrame)
            {
                for (int x = 0; x <= width - widthOfFrame; x += widthOfFrame)
                {
                    this.tileRectangles.Add(new Rectangle(x, y, 16, 16));
                }
            }            
        }
        private void AddTiles()
        {
            for (int y = 0; y < this.worldTemplate.GetLength(0); y++)
            {
                for (int x = 0; x < this.worldTemplate.GetLength(1); x++)
                {
                    int index = (this.worldTemplate[y, x].ToCharArray()[0] - 'A') * 8 + (this.worldTemplate[y, x].ToCharArray()[1] - '1');
                    this.tiles[y, x] = new Tile(this.tileRectangles[index], new Vector2(x * 16, y * 16), index);
                }
            }
        }
        #endregion
    }
}

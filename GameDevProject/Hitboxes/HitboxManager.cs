using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;

namespace GameDevProject.Hitboxes
{
    class HitboxManager
    {
        #region Properties
        public List<IHitbox> Items;
        public List<Hitbox> Hitboxes;
        private List<Texture2D> textures;
        #endregion

        #region Public Methods
        public void DrawHitboxes(SpriteBatch spriteBatch)
        {
            foreach (Hitbox hitbox in Hitboxes)
            {
                spriteBatch.Draw(hitbox.Texture, hitbox.Position, Color.White);
            }
        }

        public void AddWantedHitboxes(List<Entity> entities, World world, GraphicsDeviceManager graphics)
        {
            this.Hitboxes = new List<Hitbox>();
            this.Items = new List<IHitbox>();
            this.CreateNewTextures();

            if (entities != null)
            {
                foreach (IHitbox entity in entities)
                {
                    Items.Add(entity);
                }
                foreach (IHitbox tile in world.GetTiles())
                {
                    Tile Tile = (Tile)tile;
                    if (Tile.IsTopCollide || Tile.IsRightCollide || Tile.IsLeftCollide || Tile.IsBottomCollide || Tile.IsFinishCollide)
                    {
                        Items.Add(tile);
                    }
                }
            }

            this.CreateHitboxes(graphics);
        }
        #endregion

        #region Private Methods
        private void CreateHitboxes(GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                int itemWidth = Items[i].HitboxRectangle.Width;
                int itemHeight = Items[i].HitboxRectangle.Height;
                Vector2 position = new Vector2(Items[i].HitboxRectangle.X, Items[i].HitboxRectangle.Y);

                this.textures.Add(new Texture2D(graphics.GraphicsDevice, itemWidth, itemHeight));
                int pixels = itemWidth * itemHeight;
                Color[] outline = new Color[pixels];

                for (int j = 0; j < pixels; j++)
                {
                    if (j < itemWidth || j % itemWidth == 0 || j % itemWidth == itemWidth - 1 || j > pixels - itemWidth)
                    {
                        outline[j] = Color.White;
                    }
                    else
                    {
                        outline[j] = Color.Transparent;
                    }
                }

                textures[i].SetData(outline);

                Hitboxes.Add(new Hitbox(textures[i], position));
            }
        }        

        private void CreateNewTextures()
        {
            if(textures != null)
            {
                foreach (Texture2D texture in textures)
                {
                    texture.Dispose();
                }
            }
            this.textures = new List<Texture2D>();
        }
        #endregion
    }
}

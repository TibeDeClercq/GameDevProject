using Microsoft.Xna.Framework;

namespace Blob.MenuItems
{
    class Button
    {
        #region Properties
        public Vector2 Position { get; set; }
        public Vector2 TextPosition { get; set; }
        public Vector2 Size { get; set; }
        public string Text { get; set; }
        #endregion

        #region Constructor
        public Button(Vector2 position, Vector2 size, string text)
        {
            this.Position = new Vector2(16 * (position.X - 1), 16 * (position.Y - 1));
            this.TextPosition = new Vector2(16 * (position.X - 0.5f), 16 * (position.Y - 0.5f));
            this.Size = new Vector2(16 * size.X, 16 * size.Y);
            this.Text = text;
        }
        #endregion
    }
}

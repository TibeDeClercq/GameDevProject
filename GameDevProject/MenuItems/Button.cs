using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace GameDevProject.MenuItems
{
    class Button
    {
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public string Text { get; set; }

        public Button(Vector2 position, Vector2 size, String text)
        {
            this.Position = position;
            this.Size = size;
            this.Text = text;
        }
    }
}

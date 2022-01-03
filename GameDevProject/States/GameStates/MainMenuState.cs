using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.MainMenu;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject.States.GameStates
{
    class MainMenuState : IGameState
    {
        private SpriteFont font;

        private List<SelectLevelButton> buttons;

        public MainMenuState(SpriteFont font)
        {
            this.font = font;

            this.buttons = new List<SelectLevelButton>();
            this.buttons.Add(new SelectLevelButton(new Vector2(20, 50), new Vector2(20, 10), "Level 1"));
            this.buttons.Add(new SelectLevelButton(new Vector2(120, 50), new Vector2(20, 10), "Level 2"));

            
        }
        public void Update(List<Level> levels, GameTime gameTime)
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Enter))
            {
                Game1.State = State.Level1;
            }
            //throw new NotImplementedException();
        }

        public void Draw(List<Level> levels, SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(this.font, "Main menu", new Vector2(70, 10), Color.Black);

            foreach (SelectLevelButton button in buttons)
            {
                spriteBatch.DrawString(this.font, button.Text, button.Position, Color.Black);
            }
        }

        public int GetWindowHeight(List<Level> levels)
        {
            return 100;
        }

        public int GetWindowWidth(List<Level> levels)
        {
            return 200;
        }
    }
}

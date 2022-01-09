using Microsoft.Xna.Framework;

namespace GameDevProject.Entities.Animations
{
    class AnimationFrame
    {
        public Rectangle SourceRectangle { get; set; }

        public AnimationFrame(Rectangle sourceRectangle)
        {
            this.SourceRectangle = sourceRectangle;
        }

    }
}

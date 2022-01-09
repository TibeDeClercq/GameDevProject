using Microsoft.Xna.Framework;

namespace Blob.Entities.Animations
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Nez;

namespace Game2
{
    public class ProjectileController : Component, IUpdatable
    {
        public Vector2 velocity;

        ProjectileMover _mover;


        public ProjectileController(Vector2 velocity)
        {
            this.velocity = velocity;
        }


        public override void onAddedToEntity()
        {
            _mover = entity.getComponent<ProjectileMover>();
        }


        void IUpdatable.update()
        {
            if (_mover.move(velocity * Time.deltaTime))
                entity.destroy();
        }
    }
}

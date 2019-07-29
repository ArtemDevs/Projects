using Nez;
using Nez.Sprites;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game2
{
    /// <summary>
	/// simple component that detects if it has been hit by a projectile. When hit, it flashes red and destroys itself after being hit
	/// a certain number of times.
	/// </summary>
	public class ProjectileHitDetector : Component, ITriggerListener
    {
        public int hitsUntilDead = 10;

        int _hitCounter;
        Sprite _sprite;


        public override void onAddedToEntity()
        {
            _sprite = entity.getComponent<Sprite>();
        }


        void ITriggerListener.onTriggerEnter(Collider other, Collider self)
        {
            _hitCounter++;
            if (_hitCounter >= hitsUntilDead)
            {
                entity.destroy();
                return;
            }

            _sprite.color = Color.Red;
            Core.schedule(0.1f, timer => _sprite.color = Color.White);
        }


        void ITriggerListener.onTriggerExit(Collider other, Collider self)
        { }
    }
}

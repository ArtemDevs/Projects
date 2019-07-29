using Microsoft.Xna.Framework;
using Nez;
using Nez.Tiled;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nez.Sprites;
using Nez.Tweens;
using Microsoft.Xna.Framework.Graphics;

namespace Game2
{
    class SpaceZone : Scene
    {
        public override void initialize()
        {
            // render 
            clearColor = Color.LightGray;
            addRenderer(new DefaultRenderer());

            // define tilemap, object layer, spawn object
            var tiledMap = content.Load<TiledMap>("neztilemap");
            var objectlayer = tiledMap.getObjectGroup("objects");
            var spawn = objectlayer.objectWithName("spawn");

            //add playfeild
            var tiledEntity = createEntity("tiled-map");
            tiledEntity.addComponent(new TiledMapComponent(tiledMap, "Tile Layer 1"));

            // add player block
            var player = createEntity("player");
            player.transform.setPosition(spawn.x, spawn.y);
            player.addComponent(new PrototypeSprite(16, 32)).setColor(Color.Red);
            player.addComponent<SpacePlayerController>();
            player.addComponent(new TiledMapMover(tiledMap.getLayer<TiledTileLayer>("Tile Layer 1")));
            player.addComponent(new BoxCollider(-8, -16, 16, 32));

            // add follow camera
            camera.entity.addComponent(new FollowCamera(player));
            camera.entity.addComponent(new CameraShake());
        }
    }
}

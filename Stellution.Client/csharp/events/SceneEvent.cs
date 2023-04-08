using Easel.Entities;
using Easel.Entities.Components;
using Stellution.Client.csharp.registry;
using Stellution.Common.csharp.scenes;

namespace Stellution.Client.csharp.events; 

public class SceneEvent {

    public SceneEvent() {
        ModifiedScene.Initializing += (obj, args) => this.Event(args.Scene);
    }

    protected void Event(ModifiedScene scene) {
        switch (scene.Name) {
            
            case "earth":
                Camera.Main.Skybox = SkyboxRegistry.EarthSkybox;
                Camera.Main.AddComponent(new NoClipCamera() {
                    MouseSensitivity =  0.005F,
                }); 
                break;
        }
    }
}
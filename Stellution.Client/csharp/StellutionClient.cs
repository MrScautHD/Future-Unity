using Easel;
using Easel.Core;
using Easel.Scenes;
using Pie.Windowing;
using Stellution.Client.csharp.network;
using Stellution.Client.csharp.overlay;
using Stellution.Client.csharp.registry.types;
using Stellution.Common.csharp.file;
using Stellution.Common.csharp.registry;

namespace Stellution.Client.csharp; 

public class StellutionClient : EaselGame {
    
    public new static StellutionClient Instance { get; private set; }
    public static ClientNetworkManager NetworkManager { get; private set; }

    public StellutionClient(GameSettings settings, Scene scene) : base(settings, scene) {
        Instance = this;
        NetworkManager = new ClientNetworkManager();
        GameLogger.Initialize("logs", "log");
        Input.NewKeyDown += this.OnKeyDown;
        
        // REGISTER
        Registry.RegistryTypes.Add(new TranslationRegistry());
        Registry.RegistryTypes.Add(new FontRegistry());
        Registry.RegistryTypes.Add(new BitmapRegistry());
        Registry.RegistryTypes.Add(new TextureRegistry());
        Registry.RegistryTypes.Add(new ClientConfigRegistry());
        Registry.RegistryTypes.Add(new MaterialRegistry());
        Registry.RegistryTypes.Add(new ModelRegistry());
        Registry.RegistryTypes.Add(new SkyboxRegistry());
        Registry.RegistryTypes.Add(new OverlayRegistry());
        Registry.RegistryTypes.Add(new ClientEventRegistry());
    }

    protected override void Initialize() {
        Logger.Debug("Initializing Registries...");
        foreach (Registry registry in Registry.RegistryTypes) {
            registry.Initialize();
        }
        
        base.Initialize();
    }
    
    protected override void FixedUpdate() {
        base.FixedUpdate();
        NetworkManager.Update();
    }

    protected override void Update() {
        base.Update();
        
        foreach (Overlay overlay in OverlayRegistry.Overlays.Values) {
            if (overlay.Enabled) {
                overlay.Update();
            }
        }
    }

    protected override void Draw() {
        base.Draw();
        
        this.Graphics.SpriteRenderer.Begin();
        foreach (Overlay overlay in OverlayRegistry.Overlays.Values) {
            if (overlay.Enabled) {
                overlay.Draw();
            }
        }

        this.Graphics.SpriteRenderer.End();
    }

    protected void OnKeyDown(Key key) {
        if (key == Key.F11) {
            this.Window.SetFullscreen(!this.Window.Fullscreen, this.Window.Size);
        }
    }
}
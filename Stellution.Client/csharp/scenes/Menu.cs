using Easel.Graphics;
using Easel.GUI;
using Easel.Math;
using Stellution.Client.csharp.registry;
using Stellution.Client.csharp.ui.elements;
using Stellution.Common.csharp.scenes;

namespace Stellution.Client.csharp.scenes;

public class Menu : ModifiedScene {

    public Menu() : base("menu") {
        
    }

    protected override void Initialize() {
        base.Initialize();

        UI.DefaultStyle.Font = FontRegistry.Fontoe;
        UI.DefaultStyle.BackgroundTexture = TextureRegistry.CarBanner;
        
        UI.Add(new ImageElement("car_banner", TextureRegistry.CarBanner, new Position(Anchor.CenterCenter)));
        UI.Add(new ImageElement("black_shadow", Texture2D.Black, new Position(Anchor.CenterCenter), new Size<int>(1920, 1080), new Color(Color.Black, 200)));

        UI.Add(new ImageElement("banner", TextureRegistry.LogoBanner, new Position(Anchor.CenterCenter)));
        
        /*
        UI.Add(new ButtonElement("button", Texture2D.Missing, "BUTTON", 160, new Position(Anchor.CenterLeft), new Size<int>(400), true, null, Color.Aqua, 
            () => {
                Logger.Error("CLICKED");
                return true;
            }));*/
        
        //UI.Add(new LabelElement("label", Translation.Lang.Get("gui.button.singleplayer"), new Position(Anchor.CenterRight), 60, true, Color.Aqua));
    }
}
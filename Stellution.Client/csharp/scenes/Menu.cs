using Easel.GUI;
using Easel.Math;
using Stellution.Client.csharp.registry;
using Stellution.Common.csharp.scenes;

namespace Stellution.Client.csharp.scenes;

public class Menu : ModifiedScene {

    public Menu() : base("menu") {
        
    }

    protected override void Initialize() {
        base.Initialize();

        UI.DefaultStyle.Font = FontRegistry.Fontoe;

        UI.Add(new Panel("test", new Position(Anchor.CenterCenter), new Size<int>(90)));
        
        //UI.Add("logo", new Image(new Position(Anchor.TopRight), ClientTextureRegistry.Get(ClientTextureRegistry.LogoTexture), new Size<int>(250)));
        //UI.Add("label", new Label(new Position(Anchor.CenterCenter), "label", 20));

        //UI.Add("button", new Button(new Position(Anchor.CenterCenter), new Size<int>(200, 40), Translation.Lang.Get("gui.button.singleplayer")));
    }
}
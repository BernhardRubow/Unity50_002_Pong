using nvp.events;
using nvp.interfaces;
using Zenject;

public class DI_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventController>()
            .To<NvpEventController>()
            .AsSingle();

        Container.Bind<ISceneController>()
            .To<NvpSceneController>()
            .AsSingle();

        Container.Bind<IBallModel>()
            .To<NvpAdvanceBallModel>()
            .AsSingle();
    }
}

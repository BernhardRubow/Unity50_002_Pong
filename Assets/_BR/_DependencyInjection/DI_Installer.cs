using nvp.events;
using nvp.interfaces;
using Zenject;

public class DI_Installer : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<IEventController>()
            .To<NvpEventController>()
            .AsSingle()
            .NonLazy();

        Container.Bind<ISceneController>()
            .To<NvpSceneController>()
            .AsSingle()
            .NonLazy();
    }
}

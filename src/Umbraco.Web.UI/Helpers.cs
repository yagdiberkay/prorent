using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web.UI.Services;

namespace Umbraco.Web.UI
{
    public class MyTestHelperComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<IProrentService, ProrentService>(Lifetime.Singleton);
        }
    }

}

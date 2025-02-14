using Client.Model;
using Client.Model.Gameplay.StaticData;
using Il2CppToolkit.Runtime;

namespace Raid.Service
{
    public class ModelScope
    {
        public Il2CsRuntimeContext Context { get; }
        public AppModel AppModel { get; }
        public ClientStaticDataManager StaticDataManager { get; }
        public ModelScope(Il2CsRuntimeContext context)
        {
            Context = context;
            var statics = Client.App.SingleInstance<Client.Model.AppModel>.method_get_Instance.GetMethodInfo(Context).DeclaringClass.StaticFields
                .As<AppModelStaticFields>();
            AppModel = statics.Instance;
            StaticDataManager = AppModel.StaticDataManager as ClientStaticDataManager;
        }

        [Size(16)]
        private struct AppModelStaticFields
        {
            [Offset(8)]
#pragma warning disable 649
            public Client.Model.AppModel Instance;
#pragma warning restore 649
        }
    }
}
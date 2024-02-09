
using System.Globalization;
using System.Reflection;
using System.Resources;

using System.ComponentModel;


namespace LEDBOXMAUI
{
    // You exclude the 'Extension' suffix when using in XAML
    [ContentProperty(nameof(Text))]
    public class TranslateExtension : IMarkupExtension<BindingBase>
    {
        readonly CultureInfo ci = null;
        const string ResourceId = "LEDBOXMAUI.Resources.AppResources";

        static readonly Lazy<ResourceManager> ResMgr = new Lazy<ResourceManager>(() => new ResourceManager(ResourceId, IntrospectionExtensions.GetTypeInfo(typeof(TranslateExtension)).Assembly));

        public string Text { get; set; }

        public TranslateExtension()
        {
            //Text = text;
            if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
            {

                ci = new CultureInfo(Preferences.Get("language", "it-IT"), false);

                //ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            }
        }
        object IMarkupExtension.ProvideValue(IServiceProvider serviceProvider)
        {
            return ProvideValue(serviceProvider);
        }

        public BindingBase ProvideValue(IServiceProvider serviceProvider)
        {
            var binding = new Binding
            {
                Mode = BindingMode.OneWay,
                Path = $"[{Text}]",
                Source = Translator.Instance,
            };
            return binding;
        }
       
    }


    public class Translator : INotifyPropertyChanged
    {
        public string this[string text]
        {
            get
            {
                return Resources.AppResources.ResourceManager.GetString(text, Resources.AppResources.Culture);
            }
        }

        public static Translator Instance { get; } = new Translator();

        public event PropertyChangedEventHandler PropertyChanged;

        public void Invalidate()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(null));
        }
    }

}

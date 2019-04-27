using AttributesAndReflection;

namespace some
{    
    public class MyTesteClass : IPlugin
    {
        private int a = 0;
        private int b = 1;
        private string c = "c";
        public string Name => "The name";

        public string Description => "The description";
    }
}
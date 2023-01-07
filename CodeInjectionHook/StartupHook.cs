//No namespace allowed
//from https://www.youtube.com/watch?v=2qDULMdhN3Y
//Added to env with PS command $env:DOTNNET_STARTUP_HOOKS="[dll path]"

internal class StartupHook
    {
        public static void Initialize()
        {
            Console.WriteLine("Started from hook");
        }
    }
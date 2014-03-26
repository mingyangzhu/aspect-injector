﻿using Mono.Cecil;
using System.Collections.Generic;

namespace AspectInjector.BuildTask
{
    internal class AspectProcessor
    {
        private List<IModuleProcessor> processors = new List<IModuleProcessor>();

        public AspectProcessor()
        {
            processors.Add(new AdviceInterfaceProxyInjector());
            processors.Add(new AdviceInjector());
            processors.Add(new Janitor());
        }

        public void Process(AssemblyDefinition assembly)
        {
            foreach (var processor in processors)
            {
                processor.ProcessModule(assembly.MainModule);
            }
        }
    }
}
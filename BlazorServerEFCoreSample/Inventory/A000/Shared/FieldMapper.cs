
using System;
using System.Collections.Generic;



namespace DreamAITek.T001.Adapter.Shared
{
    public partial class FieldMapper
    {
        public FieldMapper() { }
        public FieldMapper(string id, string name)
        {
            Id = id;
            Name = name;
            Index = -1;
        }
        public string Id { get; set; }
        public string Name { get; set; }

        public int Index { get; set; }

    }
}
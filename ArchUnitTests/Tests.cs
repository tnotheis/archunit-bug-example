using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using ArchUnitNET.xUnit;
using AssemblyOfChild;
using AssemblyOfGrandchild;
using AssemblyOfParent;

namespace ArchUnitTests;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

public class Tests
{
    private static readonly Architecture Architecture = new ArchLoader()
            .LoadAssemblies(typeof(Parent).Assembly, typeof(Child).Assembly, typeof(Grandchild).Assembly)
            .Build();
    
    [Fact]
    public void Test()
    {
        Classes().That().Are(typeof(Grandchild))
            .Should().BeAssignableTo(typeof(Parent))
            .Check(Architecture);
    }
}


using System;

[Serializable]

public class Component1 : NPCComponent
{
    public Type type { get; protected set; }

    protected override void SetComponentDependency() => type = typeof(Component1);
}

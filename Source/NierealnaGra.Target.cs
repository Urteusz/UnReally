using UnrealBuildTool;
using System.Collections.Generic;

public class NierealnaGraTarget : TargetRules
{
    public NierealnaGraTarget(TargetInfo Target) : base(Target)
    {
        Type = TargetType.Game;

        DefaultBuildSettings = BuildSettingsVersion.V6; // [ZMIANA]

        IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_7; // [ZMIANA]

        ExtraModuleNames.AddRange(new string[] { "NierealnaGra" });
    }
}
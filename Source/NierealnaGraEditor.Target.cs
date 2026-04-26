using UnrealBuildTool;
using System.Collections.Generic;

public class NierealnaGraEditorTarget : TargetRules
{
    public NierealnaGraEditorTarget(TargetInfo Target) : base(Target)
    {
        Type = TargetType.Editor;

        DefaultBuildSettings = BuildSettingsVersion.V6; // [ZMIANA]

        IncludeOrderVersion = EngineIncludeOrderVersion.Unreal5_7; // [ZMIANA]

        ExtraModuleNames.AddRange(new string[] { "NierealnaGra" });
    }
}
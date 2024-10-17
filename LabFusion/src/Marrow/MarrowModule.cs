﻿using Il2CppSLZ.Marrow;

using LabFusion.SDK.Modules;

namespace LabFusion.Marrow;

public class MarrowModule : Module
{
    public override string Name => "Marrow";
    public override string Author => "Lakatrazz";
    public override string Version => MarrowSDK.SDKVersion.ToString();

    public override ConsoleColor Color => ConsoleColor.White;

    protected override void OnModuleRegistered()
    {
        
    }

    protected override void OnModuleUnregistered()
    {
        
    }
}
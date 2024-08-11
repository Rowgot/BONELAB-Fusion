﻿using HarmonyLib;

using LabFusion.Network;

using Il2CppSLZ.Marrow.SceneStreaming;
using Il2CppSLZ.Marrow.Warehouse;

namespace LabFusion.Patching;

[HarmonyPatch(typeof(SceneStreamer))]
public class SceneLoadPatch
{
    public static bool IgnorePatches = false;

    [HarmonyPatch(nameof(SceneStreamer.Reload))]
    [HarmonyPrefix]
    public static bool Reload()
    {
        // Check if we need to exit early
        if (!IgnorePatches && NetworkInfo.HasServer && !NetworkInfo.IsServer)
        {
            return false;
        }

        return true;
    }

    [HarmonyPatch(nameof(SceneStreamer.Load), typeof(Barcode), typeof(Barcode))]
    [HarmonyPrefix]
    public static bool BarcodeLoad(Barcode levelBarcode, Barcode loadLevelBarcode = null)
    {
        // Check if we need to exit early
        if (!IgnorePatches && NetworkInfo.HasServer && !NetworkInfo.IsServer)
        {
            return false;
        }

        return true;
    }

    [HarmonyPatch(nameof(SceneStreamer.Load), typeof(LevelCrateReference), typeof(LevelCrateReference))]
    [HarmonyPrefix]
    public static bool CrateLoad(LevelCrateReference level, LevelCrateReference loadLevel)
    {
        // Check if we need to exit early
        if (!IgnorePatches && NetworkInfo.HasServer && !NetworkInfo.IsServer)
        {
            return false;
        }

        return true;
    }
}
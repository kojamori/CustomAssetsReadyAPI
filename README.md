# CustomAssetsReadyAPI

A simple API mod for Spaceflight Simulator (SFS) that signals when all custom assets (parts, textures, etc.) are fully loaded and ready to use.
Custom assets are always loaded after SFS has loaded the default game assets as well, and therefore this mod should also be used if you're writing a mod that depends on not just custom assets, but also the base game assets to be fully loaded.

## What does it do?

- Waits for SFS to finish loading all custom assets.
- Fires a static event (`CustomAssetsReadyAPI.CustomAssetsReady.OnCustomAssetsReady`) that other mods can subscribe to.
- Lets your mod safely use custom assets without race conditions.

## Usage

1. Add `CustomAssetsReadyAPI` as a dependency in your mod.
2. Subscribe to the event in your mod's `Load()` method:

```csharp
CustomAssetsReadyAPI.CustomAssetsReady.OnCustomAssetsReady += () =>
{
    // Your code that needs custom assets
};
```

## Why do I need this?

SFS loads DLL mods before custom assets are finished loading. If your mod needs to access custom parts, textures, or other assets, you must wait for them to be ready. This API makes it easy and safe.

## License

GNU General Public License. See LICENSE file for details.

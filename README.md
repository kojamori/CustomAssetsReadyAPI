# CustomAssetsReadyAPI

A simple API mod for Spaceflight Simulator (SFS) that signals when all custom assets (parts, textures, solar systems.) are fully loaded and ready to use.
Custom assets are always loaded after SFS has loaded the default game assets as well, and therefore this mod should also be used if you're writing a mod that depends on not just custom assets, but also the base game assets to be fully loaded.

As of the 1.6.00.0 beta, custom solar systems are also considered custom assets, so this API is useful for mods that need to access custom planets as well.

## What does it do?

- Waits for SFS to finish loading all custom assets.
- Fires a static event (`CustomAssetsReadyAPI.CustomAssetsReady.OnCustomAssetsReady`) that other mods can subscribe to.
- Lets your mod safely use custom assets without race conditions.

## Usage

1. Add `CustomAssetsReadyAPI` as a dependency in your mod by overriding the `Dependencies` property in your `Mod` subclass:

```csharp
public override System.Collections.Generic.Dictionary<string, string> Dependencies => new System.Collections.Generic.Dictionary<string, string>
{
    { "customassetsreadyapi", "this value is not used by the mod loader :)" }
};
```

2. Subscribe to the event in your mod's `Load()` or `Early_Load()` method:
3. or check the `CustomAssetsReadyAPI.CustomAssetsReady.IsReady` property if you need to check if custom assets are already loaded.

```csharp
CustomAssetsReadyAPI.CustomAssetsReady.OnCustomAssetsReady += () =>
{
    // Your code that needs custom assets
};

// or

if (CustomAssetsReadyAPI.CustomAssetsReady.IsReady)
{
    // Your code that needs custom assets
}
```

## Why do I need this?

SFS loads DLL mods before custom assets are finished loading. If your mod needs to access custom parts, textures, or other assets, you must wait for them to be ready. This API makes it easy and safe.

## License

GNU General Public License. See LICENSE file for details.

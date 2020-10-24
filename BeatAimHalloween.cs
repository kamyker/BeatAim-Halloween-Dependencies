using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEditor.AddressableAssets.Settings;
using UnityEngine;
using UnityEngine.AddressableAssets;

public static class BeatAimHalloween
{
	[MenuItem( "BeatAim/Create Default Map" )]
	public static void CreateMap()
	{
		var scene = AssetDatabase.LoadAssetAtPath<Object>("Packages\\com.ks.beataim.modding.halloween.dependencies\\Map\\Halloween");
		Debug.Log( $"AssetDatabase.GetAssetPath( scene );: {AssetDatabase.GetAssetPath( scene )}" );
		Debug.Log( $"AssetDatabase.GetAssetPath( scene );: {AssetDatabase.AssetPathToGUID( AssetDatabase.GetAssetPath( scene ) )}" );
		AssetDatabase.CopyAsset( AssetDatabase.GetAssetPath( scene ), "Assets\\Scenes" );
	}

	[MenuItem( "BeatAim/Create Default Map2" )]
	public static void CreateMap2()
	{
		var scene = AssetDatabase.LoadAssetAtPath<Object>("Packages\\com.ks.beataim.modding.halloween.dependencies\\Map\\Halloween");
		string targetPath = "Assets\\Map\\Halloween";
		Directory.CreateDirectory( Path.GetDirectoryName( targetPath ) );
		AssetDatabase.CopyAsset( AssetDatabase.GetAssetPath( scene ), "Assets\\Map\\Halloween" );
		var settings = AssetDatabase.LoadAssetAtPath<AddressableAssetSettings>( "Assets\\AddressableAssetsData\\AddressableAssetSettings.asset");

		var group = settings.CreateGroup( "HalloweenCustom", false, false, true, null );

		var entriesAdded = new List<AddressableAssetEntry>();
		var entry = settings.CreateOrMoveEntry( AssetDatabase.AssetPathToGUID( "Assets\\Map\\Halloween\\SceneHalloween.unity") , group);
		entry.address = "MapScene";
		entriesAdded.Add( entry );

		var entry2 = settings.CreateOrMoveEntry( AssetDatabase.AssetPathToGUID( "Assets\\Map\\Halloween\\MapSettings 1.asset") , group);
		entry2.address = "MapSettings";
		entriesAdded.Add( entry2 );

		settings.SetDirty( AddressableAssetSettings.ModificationEvent.EntryMoved, entriesAdded, true );
		AssetDatabase.MoveAsset( AssetDatabase.GetAssetPath( group ), "Assets\\Map\\Halloween\\HalloweenCustom.asset" );
		AssetDatabase.DeleteAsset( "Assets\\Map\\Halloween\\HalloweenBuild.asset" );
	}

	[MenuItem( "BeatAim/Update Packages" )]
	public static void UpdatePackages()
	{
		UnityEditor.PackageManager.Client.Add( "https://github.com/kamyker/BeatAim-Modding-Package.git" );
		UnityEditor.PackageManager.Client.Add( "https://github.com/kamyker/BeatAim-Halloween-Dependencies.git" );
	}
}

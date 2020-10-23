using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AlwaysGenerateUVs : AssetPostprocessor
{
	private void OnPreprocessModel()
	{
		Debug.Log( $"name: {assetImporter.name}" );
		ModelImporter modelImporter = assetImporter as ModelImporter;
		if ( modelImporter != null )
		{
			modelImporter.generateSecondaryUV = true;
		}
	}
}
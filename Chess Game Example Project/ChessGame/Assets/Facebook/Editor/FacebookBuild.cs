/**
 * Copyright (c) 2014-present, Facebook, Inc. All rights reserved.
 *
 * You are hereby granted a non-exclusive, worldwide, royalty-free license to use,
 * copy, modify, and distribute this software in source code or binary form for use
 * in connection with the web services and APIs provided by Facebook.
 *
 * As with any software that integrates with the Facebook platform, your use of
 * this software is subject to the Facebook Developer Principles and Policies
 * [http://developers.facebook.com/policy/]. This copyright notice shall be
 * included in all copies or substantial portions of the software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS
 * FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR
 * COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER
 * IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN
 * CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 */

namespace Facebook.Unity.Editor
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using UnityEditor;
    using UnityEngine;

    public class FacebookBuild
    {
        private const string FacebookPath = "Assets/Facebook/";
        private const string ExamplesPath = "Assets/Examples/";
        private const string PluginsPath = "Assets/Plugins/";

        public enum Target
        {
            DEBUG,
            RELEASE
        }

        // Exporting the *.unityPackage for Asset store
        public static void ExportPackage()
        {
            Debug.Log("Exporting Facebook Unity Package...");

            var path = "FacebookSDK.unitypackage";

            try
            {
                if (!File.Exists(Path.Combine(Application.dataPath, "Temp")))
                {
                    AssetDatabase.CreateFolder("Assets", "Temp");
                }

                AssetDatabase.MoveAsset(FacebookPath + "Resources/FacebookSettings.asset", "Assets/Temp/FacebookSettings.asset");
                AssetDatabase.DeleteAsset(PluginsPath + "Android/AndroidManifest.xml");
                AssetDatabase.DeleteAsset(PluginsPath + "Android/AndroidManifest.xml.meta");

                string[] facebookFiles = (string[])Directory.GetFiles(FacebookPath, "*.*", SearchOption.AllDirectories);
                string[] exampleFiles = (string[])Directory.GetFiles(ExamplesPath, "*.*", SearchOption.AllDirectories);
                string[] pluginsFiles = (string[])Directory.GetFiles(PluginsPath, "*.*", SearchOption.AllDirectories);
                string[] files = new string[facebookFiles.Length + exampleFiles.Length + pluginsFiles.Length];
                facebookFiles.CopyTo(files, 0);
                exampleFiles.CopyTo(files, facebookFiles.Length);
                pluginsFiles.CopyTo(files, facebookFiles.Length + exampleFiles.Length);

                AssetDatabase.ExportPackage(
                    files,
                    path,
                    ExportPackageOptions.IncludeDependencies | ExportPackageOptions.Recurse);
            }
            finally
            {
                // Move files back no matter what
                AssetDatabase.MoveAsset("Assets/Temp/FacebookSettings.asset", FacebookPath + "Resources/FacebookSettings.asset");
                AssetDatabase.DeleteAsset("Assets/Temp");

                // regenerate the manifest
                UnityEditor.FacebookEditor.ManifestMod.GenerateManifest();
            }

            Debug.Log("Finished exporting!");
        }
    }
}

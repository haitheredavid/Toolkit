using System;
using System.Collections;
using System.IO;
using UnityEngine;

namespace ToolKit {
    public class ScreenRenderer : MonoBehaviour {

        public int resWidth;
        public int resHeight;

        public Camera renderCam;
        public string fileName;

        public string filePath = @"C:\Users\dmorgan\Desktop\CurrentDads\Pride\Renderings\";

        private int _counter;

        private string GetFilePath => string.IsNullOrEmpty( filePath ) ? "C:\\Desktop\\screen" : filePath;

        private string GetFileName => Path.Combine( new[ ] {GetFilePath, fileName + _counter++ + ".png"} );

        private readonly Action<float> RecordTime = f => Debug.Log( $"Rendering Completed in {f}" );

        private void Awake( )
            {
                _counter = 0;
            }

        public IEnumerator RenderShot( Camera cam )
            {
                if ( cam == null ) yield return null;

                float startTime = Time.time;

                RenderTexture rt = new RenderTexture( resWidth, resHeight, 24 ) {antiAliasing = 8};
                cam.targetTexture = rt;
                Texture2D screenShot = new Texture2D( resWidth, resHeight, TextureFormat.RGB24, false );

                cam.Render( );

                RenderTexture.active = rt;
                screenShot.ReadPixels( new Rect( 0, 0, resWidth, resHeight ), 0, 0 );

                cam.targetTexture = null;
                RenderTexture.active = null;

                Destroy( rt );

                var file = SaveTexture( screenShot );

                Debug.Log( "Screen shot " + file );
                RecordTime.Invoke( Time.time - startTime );
                yield return null;
            }

        private void LateUpdate( )
            {
                if ( Input.GetKeyDown( KeyCode.A ) )
                    StartCoroutine( RenderShot( renderCam ) );
            }

        private string SaveTexture( Texture2D screenShot )
            {
                var file = GetFileName;
                byte[ ] bytes = screenShot.EncodeToPNG( );
                if ( bytes != null ) {
                    File.WriteAllBytes( file, bytes );
                    return file;
                }
                Debug.Log( "Image Did not Write Correctly" );
                return "HaHa";
            }

    }
}
using System.Collections.Generic;
using UnityEngine;

namespace ToolKit {

public static class MeshHelper{

	 public static void SetMeshMaterial( GameObject obj, Material m, bool recursive = true )
            {
                var mesh = obj.GetComponent<MeshRenderer>( );
                if ( mesh != null )
                    mesh.material = m;

                if ( !recursive || obj.transform.childCount <= 0 ) return;

                foreach ( Transform child in obj.transform ) {
                    SetMeshMaterial( child.gameObject, m );
        	}
        }
	}
}
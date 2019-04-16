// Upgrade NOTE: replaced 'SeperateSpecular' with 'SeparateSpecular'

Shader "Custom/Visible"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
	   _OccludeColor("Occlusion Color", Color) = (0,0,1,1)
    }
    SubShader
    {
        Tags { "Queue"="Geometry+10" }
  

			  Pass {
			ZWrite Off
			Blend One Zero
			ZTest Greater
			Color[_OccludeColor]
		}
			
			Pass {
				Tags {"LightMode" = "Vertex"}
				ZWrite On
				Lighting On
				SeparateSpecular On
				Material {
					Diffuse[_Color]
					Ambient[_Color]
		
		}
		SetTexture[_MainTex] {
			ConstantColor[_Color]
			Combine texture * primary DOUBLE, texture * constant
			}

        }
       
    }
    FallBack "Diffuse" , 1
}

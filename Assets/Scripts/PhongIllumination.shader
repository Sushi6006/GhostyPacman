Shader "Unlit/PhongIllumination"
{
    //original properties are set
	Properties
	{   
		
	}
    
	SubShader
	{   
        Tags{"Queue" = "Background"}
        
		Pass
		{
			CGPROGRAM

			#include "Lighting.cginc"
			#pragma vertex vert
			#pragma fragment frag

			//the struct of data which will be inputed into vertex shader
			struct vertIn
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 color : COLOR;
			};
 
			//the struct of data which will be outputted from vertex shader
			struct vertOut
			{
				float4 vertex : SV_POSITION;
				float3 worldNormal : TEXCOORD0;
				float4 worldVertex : TEXCOORD1;
				float4 color : COLOR;
			};
        
			//vertex shader
			vertOut vert(vertIn v)
			{
				
				vertOut o;
				
                //tranform inputed data into clip coordinates
				o.vertex = UnityObjectToClipPos(v.vertex);

                //convert Vertex position and corresponding normal into world coords.
				o.worldVertex = mul(unity_ObjectToWorld, v.vertex);
				o.worldNormal = normalize(mul(transpose((float3x3)unity_WorldToObject), v.normal.xyz));
				o.color = v.color;
				return o;
			}

			//fragment shader
			fixed4 frag(vertOut v) : SV_Target
			{		

					float fAtt = 1;
					float3 L = _WorldSpaceLightPos0;
					//ambient part
					//Ka is the ambient light constant
					float Ka = 1;
					//ambient = ambient lightIntensity * constant * surface color
					float3 ambient = UNITY_LIGHTMODEL_AMBIENT.rgb * Ka * v.color.rgb;


					//diffuse part
					//Kd is the coefficient of diffuse reflection (reflectivity)
					float Kd = 1;
					//intercetAngel is the cos(angel) b/w normal and light
					float intercetAngel = dot(L, normalize(v.worldNormal));
					//diffuse = fatt * lightIntensity * kd * color * cos(angel)
					float3 diffuse = fAtt * _LightColor0 * Kd * v.color.rgb * saturate(intercetAngel);

					
					//specular part
					//ks is the Specular constant
					float Ks = 1;
					//shininess represents how shine the surface is
					int shininess = 2;
					//R is the reflection directionV
					//float3 R = 2 * dot(v.worldNormal, L) * v.worldNormal + (-L);
                	float3 R = normalize(reflect(-L, normalize(v.worldNormal)));
					//V is the view Direction
					float3 V = normalize(_WorldSpaceCameraPos.xyz - v.worldVertex.xyz);
					//specularFactor is (cos α)^n
					float3 specularFactor = pow(saturate(dot(R, V)), shininess);
					//specular = fAtt * lightIntensity * specularColor * factor
					float3 specular = fAtt * _LightColor0 * Ks * specularFactor;
					
					//combine Phong illumination model components
					float4 finalColor = float4(0.0f, 0.0f, 0.0f, 0.0f);
					finalColor.rgb = ambient.rgb + diffuse.rgb + specular.rgb;

					return finalColor;
			}
			ENDCG
		}
	}
	FallBack "diffuse"
}
